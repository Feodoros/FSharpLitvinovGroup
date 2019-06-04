module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Proof II = I``() = 
        betaReduction (FullExp(Exp('a', Letter 'a'), Exp('a', Letter 'a'))) |> should equal 
            (Exp('a', Letter 'a'))

    [<Test>]
    let ``K a b``() = 
        betaReduction (FullExp(FullExp(Exp('x', Exp('y', Letter 'x')), Letter 'a'), Letter 'b')) |> should equal
            (Letter 'a') 

    [<Test>]
    let ``KI = K_*``() = 
        betaReduction (FullExp(Exp('a', Exp('b', Letter 'a')), Exp('a', Letter 'a'))) |> should equal
            (Exp('b', Exp('a', Letter 'a')))
