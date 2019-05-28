module Logic 
  
    let makeseq x = Seq.take(x) <| Seq.initInfinite(fun n -> x)
    let make () =
        let rec seqTask seq n = 
            let seq1 = Seq.append seq <| makeseq (n) 
            seqTask seq1 (n + 1) 
        seqTask (Seq.empty<int>) 1


    printfn "%A" (make())  