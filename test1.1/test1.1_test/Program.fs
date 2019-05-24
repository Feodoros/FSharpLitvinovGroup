module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Test list`` () =
        let f x = x + 1
        let g x = x + 3
        supermap [1;2;3] (fun x -> [f x; g x]) |> should equal [4; 6; 3; 5; 2; 4] 