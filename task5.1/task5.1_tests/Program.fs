module Test

    open NUnit.Framework
    open FsUnit
    open Logic 

     [<Test>]
    let ``Check correctness 1 with correct string.`` () = 
        isBalanced "(string{[hello]})" |> should equal true

    [<Test>]
    let ``Check correctness 2 with correct string.`` () = 
        isBalanced "({[]} ({check this}))" |> should equal true

    [<Test>]
    let ``Check correctness 3 with wrong string.`` () = 
        isBalanced "{1[0[1]]" |> should equal false