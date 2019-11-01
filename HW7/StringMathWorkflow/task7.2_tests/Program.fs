module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Test StringMathFlow 1``() = 

        let l = StringMathFlow() {
                let! a = "2"
                let! b = "3"
                return a + b
            }

        l |> should equal <| Some(5) 

    [<Test>]
    let ``Test StringMathFlow 2``() = 

        let l = StringMathFlow() {
                let! a = "2"
                let! b = "ъ"
                return a + b
            }

        l |> should equal None 