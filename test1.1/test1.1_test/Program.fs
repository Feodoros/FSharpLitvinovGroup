module Tests

    open NUnit.Framework
    open FsUnit
    open Logic
    open System

    [<Test>]
    let ``Test 1`` () =       
         Math.Round(avgOfSin [Math.Asin(1.0); Math.Asin(Math.PI/4.0); Math.Asin(Math.PI/8.0)], 3)   
         |> should equal 0.726
        
    [<Test>]
    let ``Test 2`` () = 
         let delta = 0.02  
         let avg = avgOfSin [1.0; 2.0; 3.0; 4.0]
         let ans = ((avg - delta) < avg && avg < (avg + delta))
         ans |> should equal true