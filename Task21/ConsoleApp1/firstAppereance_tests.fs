module tests

open NUnit.Framework
open FsUnit
open logic



[<Test>]
let ``When getting sum of multiples of 3 and 5 to a max number of 10 it should return a sum of 23`` () =
    firstAppearance [1..10] 5 |> should equal (Some(4))

[<Test>]
let ``asd`` () =
    firstAppearance [1..3] 4 |> should equal (None)

[<Test>]
let ``asdd`` () =
    firstAppearance [] 5 |> should equal None