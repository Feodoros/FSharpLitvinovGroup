module tests 

    open NUnit.Framework
    open FsUnit
    open logic 

    [<Test>]
    let ``MergeSort 1 with list [3; 1; 2] should give out [1; 2; 3]`` () =
        checkListAndStartSorting [3; 1; 2] |> should equal [1; 2; 3]

    [<Test>]
    let ``MergeSort 2 with negative num should give out [-9; -1; 0]`` () =
        checkListAndStartSorting [0;-9;-1] |> should equal [-9; -1; 0]

    [<Test>]
    let ``MergeSort 3 with empty list should give out []`` () =
        checkListAndStartSorting [] |> should equal [] 