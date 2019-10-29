module Logic
    
    open System.Threading

    /// - Первый вызов Get() вызывает вычисление и возвращает результат
    /// - Повторные вызовы Get() возвращают тот же объект, что и первый вызов
    /// - В однопоточном режиме вычисление должно запускаться не более одного раза, в многопоточном — как получится
    type ILazy<'a> = abstract member Get: unit -> 'a


    /// - Простая версия с гарантией корректной работы в однопоточном режиме (без синхронизации)
    type SingleMode<'a> (supplier) =         
        let mutable res = None
        interface ILazy<'a> with
            member __.Get() = 
                if res.IsSome then 
                    res.Value
                else 
                    res <- Some(supplier())
                    supplier()


    /// - Гарантия корректной работы в многопоточном режиме; вычисление не должно производиться более одного раза
    type MultiplyMode<'a> (supplier) =   
        let tempObj = obj() 
        let mutable res = None        
        interface ILazy<'a> with
            member __.Get() =
                if res.IsSome then 
                    res.Value
                else 
                    lock tempObj (fun () -> 
                    if res.IsSome then 
                        res.Value
                    else
                        res <- Some(supplier())
                        supplier())

             
    /// - То же, что и предыдущее, но lock-free; вычисление может производиться более одного раза, но при этом Lazy.Get
    /// всегда должен возвращать один и тот же объект 
    type MultiplyLockMode<'a> (supplier) = 
        let mutable res = None
        interface ILazy<'a> with
            member __.Get() = 
                if res.IsSome then 
                    res.Value
                else 
                    let a = Interlocked.CompareExchange(&res, Some(supplier()), None) 
                    Option.get res
