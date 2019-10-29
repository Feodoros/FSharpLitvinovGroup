module Logic 
    
    open System

    type StringMathFlow() =
        member StringMathFlow.Bind (n : string, func) =
            let intFromString = Int32.TryParse(n)
            match intFromString with
            | false, _ -> None
            | true, x -> func x

        member StringMathFlow.Return(x) =
            Some(x) 
