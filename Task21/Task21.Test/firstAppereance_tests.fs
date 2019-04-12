module tests

open NUnit.Framework
open FsUnit
open Logic

[<Test>]
let ``First appereance of 5 in list should be equal 4.`` () =
    firstAppearance [1..10] 5 |> should equal (Some(4))

[<Test>]
let ``First appereance of 4 in list should be equal None.`` () =
    firstAppearance [1..3] 4 |> should equal (None)

[<Test>]
let ``First appereance of 5 in empty list should be equal None.`` () =
    firstAppearance [] 5 |> should equal None