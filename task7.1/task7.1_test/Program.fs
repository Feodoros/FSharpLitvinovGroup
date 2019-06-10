module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Test WorkFlow 1``() = 

        let l = MathFlow 3 {
                let! a = 2.0 / 12.0
                let! b = 3.5
                return a / b
            }

        l |> should equal 0.048

    [<Test>]
    let ``Test WorkFlow 2``() = 

        let l = MathFlow 2 {
                let! a = 4.0 / 12.0
                let! b = 3.0
                return a / b
            }

        l |> should equal 0.11
