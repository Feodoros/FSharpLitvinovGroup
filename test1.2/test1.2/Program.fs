module Logic = 

    type Stack<'a>() =

        let mutable stack = []

        ///Push
        member __.Push x = stack <- (x :: stack)

        ///Pop
        member __.Pop = 
            match stack with
            |h::t -> 
                stack <- t
                h
            |[] -> failwith "Empty stack"

        ///Empty
        member __.IsEmpty = (List.isEmpty stack)

        ///Lenght
        member __.Length = stack.Length
