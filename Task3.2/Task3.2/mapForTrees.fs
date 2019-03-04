module logic 

    type Tree<'a> =
        |Tree of 'a * Tree<'a> * Tree<'a>
        |Tip of 'a

    let rec mapFuncForBinTree someFunction tree =
        match tree with
        |Tree(node, leftChild, rightChild) -> Tree(someFunction node, mapFuncForBinTree someFunction leftChild, mapFuncForBinTree someFunction rightChild)
        |Tip(node) -> Tip(someFunction node)
