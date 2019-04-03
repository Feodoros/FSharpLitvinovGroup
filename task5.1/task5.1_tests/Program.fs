module test

    open NUnit.Framework
    open FsUnit
    open logic 

     [<Test>]
    let ``Check correctness 1 with correct string.`` () = 
        checkBrackets "(string{[hello]})" |> should equal true

    [<Test>]
    let ``Check correctness 2 with correct string.`` () = 
        checkBrackets "({[]} ({check this}))" |> should equal true

    [<Test>]
    let ``Check correctness 3 with wrong string.`` () = 
        checkBrackets "{1[0[1]]" |> should equal false