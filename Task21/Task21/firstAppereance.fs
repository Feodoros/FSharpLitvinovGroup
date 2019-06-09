    let rec fibs = Seq.append [0;1] (Seq.delay (fun () -> Seq.map2 (+) fibs (Seq.skip 1 fibs))) 
    let list = Seq.toList fibs 
    let func = List.sum (List.filter (fun x -> x % 2 = 0) (List.filter(fun x -> x < 1000000) list))

printf "%A" func