module Tests

    open NUnit.Framework    
    open FsCheck.NUnit 
    open FsUnit

    [<Test>]
    let ``Test our finalFunc`` () =
        (|>) List.map ((>>) (*)) 10 [0..5] |> should equal [0; 10; 20; 30; 40; 50]

    [<Property>]
    let ``FsCheck testing.`` (num : int, list : list<int>) =        
        (List.map (fun y -> y * num) list) = (|>) List.map ((>>) (*)) num list