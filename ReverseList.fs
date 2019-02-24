
let reverse list =
    let rec loop list acc =
        match list with
        | [] -> acc
        | head::tail -> loop tail (head::acc)
    loop list []


let TestList = [0..7]

let ReversedList = reverse TestList