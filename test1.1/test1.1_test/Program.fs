module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Sum of even elements less than 1000000 in fib seq should be 1089154`` () =
        sumNum ()|> should equal 1089154 