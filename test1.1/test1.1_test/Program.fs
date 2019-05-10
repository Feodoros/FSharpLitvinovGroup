module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Test ``Test list```` () =
        supermap [1;2;3] (fun x -> [x + 1; x + 3])  ()|> should equal [2; 3; 4; 6; 6; 9] 