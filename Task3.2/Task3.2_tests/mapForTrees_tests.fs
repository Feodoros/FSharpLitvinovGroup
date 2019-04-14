module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    ///Converter to binSys. Жду комментариев по стайлгайду куда его лучше пихнуть сюда или в logic,
    ///ну а идея веселая сделать бинарная дерево, элементы которого переведены в 2-чную сс :)
    let rec to_Binary value =
        if value < 2u then value.ToString()
        else 
          let divisor = value / 2u
          let remainder = (value % 2u)
          to_Binary (divisor) + remainder.ToString() 


    [<Test>]
    let ``Make binary number from each element of binary tree to make super binary tree.`` () =
        mapFuncForBinTree (fun x -> to_Binary x) <| Tree (2u, Tree (3u, Tip 9u, Tree (1u, Tip 1u, Tip 8u )), Tree (2u, Tip 4u, Tip 1u))
        |> should equal 
        <| Tree ("10", Tree ("11", Tip "1001", Tree ("1", Tip "1", Tip "1000")), Tree ("10", Tip "100", Tip "1"))

    [<Test>]
    let ``Simple Increase for each element of tree.`` () =
        mapFuncForBinTree (fun x -> x + 1) <| Tree (2, Tree (3, Tip 9, Tree (1, Tip 1, Tip 8 )), Tree (2, Tip 4, Tip 1)) 
        |> should equal 
        <| Tree (3, Tree (4, Tip 10, Tree (2, Tip 2, Tip 9 )), Tree (3, Tip 5, Tip 2))

    [<Test>]
    let ``Get square of each element of tree.`` () =
        mapFuncForBinTree (fun x -> x * x) <| Tree (2, Tree (3, Tip 9, Tree (1, Tip 1, Tip 8 )), Tree (2, Tip 4, Tip 1)) 
        |> should equal 
        <| Tree (4, Tree (9, Tip 81, Tree (1, Tip 1, Tip 64 )), Tree (4, Tip 16, Tip 1))
