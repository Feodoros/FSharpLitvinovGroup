module Tests

    open System
    open NUnit.Framework
    open FsUnit    
    open System.Threading
    open System.Threading.Tasks
    open Logic
    open LazyFactory
    

    let rand() =
        let rndGen = Random(int DateTime.Now.Ticks)
        rndGen.Next(20, 60)


    [<Test>]
    let ``Check SingleMode``() =

        let object = LazyFactory.CreateSingleThreadedLazy(fun () -> 344)
        let a = object :> ILazy<int>  
        a.Get() |> should equal 344


    [<Test>]
    let ``Check operations in SingleMode``() =

        let mutable counter : int64 = (int64) 0
        let object = LazyFactory.CreateSingleThreadedLazy(fun () -> 
            ignore <| Interlocked.Increment &counter  
            (Interlocked.Read &counter) |> should equal 1)             
        for i in 1..rand() do
             ignore <| Task.Run(fun () -> (object :> ILazy<unit>).Get()) 


    [<Test>]
    let ``Check values in MultiplyMode``() =

        let object = LazyFactory.CreateMultiplyThreadedLazy(fun () -> new obj())
        let a = (object :> ILazy<obj>).Get()
        ignore <| Seq.map(fun x -> ((object :> ILazy<obj>).Get ()).Equals(a) |> should be True) [|1..rand()|] 


    [<Test>]
    let ``Check operations in MultiplyMode``() =

        let mutable counter : int64 = (int64) 0
        let object = LazyFactory.CreateMultiplyThreadedLazy(fun () -> 
            ignore <| Interlocked.Increment &counter  
            (Interlocked.Read &counter) |> should equal 1)             
        for i in 1..rand() do
             ignore <| Task.Run(fun () -> (object :> ILazy<unit>).Get()) 



    [<Test>]
    let ``Check values in MultiplyLockMode``() =
    
        let object = LazyFactory.CreateMultiplyLockThreadedLazy(fun () -> new obj())
        let a = (object :> ILazy<obj>).Get()
        ignore <| Seq.map(fun x -> ((object :> ILazy<obj>).Get ()).Equals(a) |> should be True) [|1..rand()|] 


    [<Test>]
    let ``Check operations in MultiplyLockMode``() =

        let mutable counter : int64 = (int64) 0
        let object = LazyFactory.CreateMultiplyLockThreadedLazy(fun () -> 
            ignore <| Interlocked.Increment &counter  
            (Interlocked.Read &counter) |> should equal 1)             
        for i in 1..rand() do
             ignore <| Task.Run(fun () -> (object :> ILazy<unit>).Get()) 