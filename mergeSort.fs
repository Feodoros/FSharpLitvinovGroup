let rec sortMerge leftPart rightPart result =
        match leftPart, rightPart with
            | [], [] -> List.rev result
            | leftPartHead::leftPartTail, [] -> sortMerge leftPartTail [] (leftPartHead::result)
            | [], rightPartHead::rightPartTail ->  sortMerge rightPartTail [] (rightPartHead::result)
            | leftPartHead::leftPartTail, rightPartHead::rightPartTail -> 
                if leftPartHead <= rightPartHead then sortMerge leftPartTail rightPart (leftPartHead::result)
                else sortMerge leftPart rightPartTail (rightPartHead::result)

let rec checkListAndStartSorting list =     
    match list with
        | [] -> []
        | h::[] -> [h]
        | _ -> let leftPart, rightPart = List.splitAt(List.length list / 2) list
               sortMerge (checkListAndStartSorting leftPart) (checkListAndStartSorting rightPart) []

let list = [1; 3; 7; 2; 5; 6; 239; 314; 16]

printfn "Sorted: %A" <| checkListAndStartSorting list