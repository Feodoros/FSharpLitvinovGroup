module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``With op. Map -> Count of even num in list [-10..10] should be equal 11`` () =
        evenNumWithMapSumBy [-10..10] |> should equal 11

    [<Test>]
    let ``With op. Map -> Count of even num in list [0..10] should be equal 6`` () =
        evenNumWithMapSumBy [0..10] |> should equal 6

    [<Test>]
    let ``With op. Map -> Count of even num in empty list should be equal 0`` () =
        evenNumWithMapSumBy [] |> should equal 0

    [<Test>]
    let ``With op. Filter -> Count of even num in list [-10..10] should be equal 11`` () =
        evenNumWithFilter [-10..10] |> should equal 11

    [<Test>]
    let ``With op. Filter -> Count of even num in list [0..10] should be equal 6`` () =
        evenNumWithFilter [0..10] |> should equal 6

    [<Test>]
    let ``With op. Filter -> Count of even num in empty list should be equal 0`` () =
        evenNumWithFilter [] |> should equal 0

    [<Test>]
    let ``With op. Fold -> Count of even num in list [-10..10] should be equal 11`` () =
        evenNumWithFold [-10..10] |> should equal 11

    [<Test>]
    let ``With op. Fold -> Count of even num in list [0..10] should be equal 6`` () =
        evenNumWithFold [0..10] |> should equal 6

    [<Test>]
    let ``With op. Fold -> Count of even num in empty list should be equal 0`` () =
        evenNumWithFold [] |> should equal 0
            