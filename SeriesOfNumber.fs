//Additional Methods
let reverse list =
    let rec loop list acc =
        match list with
        | [] -> acc
        | head::tail -> loop tail (head::acc)
    loop list []

let rec MathPow Number Power =
    if Power = 1 then Number
    else Number * MathPow Number (Power - 1)

let rec readInteger() = 
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | false, _ -> printfn "Waiting for integer number."; readInteger()
    | _, x -> x 


//Main programm
let PowersSeriesOfNum OurNumber StartPower NumberOfMembers  =
    let rec loop StartPower NumberOfMembers (list:list<int>) acc =
        match list.Length with
        | index when index = NumberOfMembers + 1 -> reverse list
        | 0 -> loop StartPower NumberOfMembers (MathPow OurNumber (list.Length + StartPower)::list) (MathPow OurNumber (list.Length + StartPower))
        | _ -> loop StartPower NumberOfMembers (OurNumber * acc::list) (OurNumber * acc)
    loop StartPower (NumberOfMembers - 1) [] OurNumber
        

printf("Start with power ")
let PowerStart = readInteger()

printf("Number of members ")
let NumberMembers = readInteger()

printf("Number to make series ")
let OurNumber = readInteger()

let Answer = PowersSeriesOfNum OurNumber PowerStart NumberMembers 