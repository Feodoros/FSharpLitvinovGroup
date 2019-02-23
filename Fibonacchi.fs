
let rec readInteger() = 
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | false, _ -> printfn "Waiting for integer number."; readInteger()
    | _, x -> x 

let Fibonacci index =
    let rec loop counter secondPrevious firstPrevious =
        match counter with
        | 0 -> secondPrevious        
        | _ ->            
            let sum = secondPrevious + firstPrevious
            let decreaser = counter - 1
            loop decreaser firstPrevious sum
    loop index 0 1


let index = readInteger()

let answer  = 
    if index >= 0 then (Fibonacci index).ToString()
    else "Error. Your num < 0, sorry."