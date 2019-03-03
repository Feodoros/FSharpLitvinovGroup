module logic  

    let evenNumWithMap list = 
        List.length list - List.sum (List.map (fun x -> abs (x % 2)) list)

    let evenNumWithFilter list =
        List.length (List.filter (fun x -> x % 2 = 0) list)

    let evenNumWithFold list =
        List.fold (fun acc x -> acc - abs (x % 2)) (List.length list) list
