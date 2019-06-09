module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Proof II = I``() = 
        betaReduction (Application(Abstraction('a', Var 'a'), Abstraction('a', Var 'a'))) |> should equal 
            (Abstraction('a', Var 'a'))

    [<Test>]
    let ``K a b``() = 
        betaReduction (Application(Application(Abstraction('x', Abstraction('y', Var 'x')), Var 'a'), Var 'b')) |> should equal
            (Var 'a') 

    [<Test>]
    let ``KI = K_*``() = 
        betaReduction (Application(Abstraction('a', Abstraction('b', Var 'a')), Abstraction('a', Var 'a'))) |> should equal
            (Abstraction('b', Abstraction('a', Var 'a')))
