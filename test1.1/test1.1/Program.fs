module Logic 

    open System
    let avgOfSin list =
        let rec loop list acc n =
            match list with
            | [] -> acc
            | head::tail -> 
                            let sum = acc + Math.Sin(head)/(float(List.length list + n)) 
                            let counter = n + 1                       
                            loop tail sum counter
        loop list 0.0 0

    let ans = Math.Round(avgOfSin [Math.Asin(1.0); Math.Asin(Math.PI/4.0); Math.Asin(Math.PI/8.0)], 3)
    printfn "%A" ans