let firstAppearance list number = 
    let rec loop list index =
        match list with
        |[] -> None
        |_ when List.head list = number -> Some(index)
        |_::_ -> loop (List.tail list) (index + 1)
    loop list 0

let num = 7
let list = [1..10]

let answer = firstAppearance list num

printfn "First appearance of %i in list = %O" num answer