﻿module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Compute one num.`` () = 
        makeSomeOperation <| Number(241) |> should equal 241

    [<Test>]
    let ``Divide by zero.`` () = 
      (fun () ->  makeSomeOperation <| Divide (Number(241), Number 0) |> ignore) |> should throw typeof<ZeroException> 

    [<Test>]
    let ``Сompute next: (2+2)*2.`` () = 
        makeSomeOperation <| Multiply(Plus(Number 2, Number 2), Number 2) |> should equal 8

    [<Test>]
    let ``Compute next: 2*(600/3) - 161.`` () = 
        makeSomeOperation <| Minus(Multiply(Number 2, Divide(Number 600, Number 3)), Number 161) |> should equal 239
