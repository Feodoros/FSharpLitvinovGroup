module Test

    open NUnit.Framework
    open FsUnit
    open Logic 

     [<Test>]
    let ``Check seq with prime num 13.`` () = 
        Seq.exists ((=) 13) <| makeSequenceOfPrimes () |> should equal true

    [<Test>]
    let ``Check seq with prime num 239.`` () = 
        Seq.exists ((=) 239) <| makeSequenceOfPrimes () |> should equal true

    [<Test>]
    let ``Let's see 42th prime number.`` () = 
        makeSequenceOfPrimes () |> Seq.skip 41 |> Seq.take 1 |> Seq.toArray |> should equal [|181|]