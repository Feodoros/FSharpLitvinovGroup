open System

//Additional Methods
let reverse list =
    let rec loop list acc =
        match list with
        | [] -> acc
        | head::tail -> loop tail (head::acc)
    loop list []

let rec mathPow Number Power =
    if Power = 1 then Number
    else Number * mathPow Number (Power - 1)

let rec readInteger() = 
    match Int32.TryParse(Console.ReadLine()) with
    | false, _ -> printfn "Waiting for integer number."
                  readInteger()
    | _, x -> x 


//Main programm
let powersSeriesOfTwo startPower numberOfMembers  =
    let rec loop startPower numberOfMembers (list:list<int>) acc =
        match list.Length with
        | index when index = numberOfMembers + 1 -> reverse list
        | 0 -> loop startPower numberOfMembers (mathPow 2 (list.Length + startPower)::list) (mathPow 2 (list.Length + startPower))
        | _ -> loop startPower numberOfMembers (2 * acc::list) (2 * acc)
    loop startPower (numberOfMembers - 1) [] 2
        

printf "Start with power "
let powerStart = readInteger()

printf "Number of members "
let numberMembers = readInteger()


let answer = powersSeriesOfTwo powerStart numberMembers 