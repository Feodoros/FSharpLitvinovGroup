module logic 

	//Create tree
    type Tree<'a> =
        |Tree of 'a * Tree<'a> * Tree<'a>
        |Tip of 'a
	
	//Описываем функцию, которая будет применять определенную функцию к элементу (Tip) дерева либо, если дальше можем спуститься, то применяем функцию к корню и спускаемся вглубь. 
    let rec mapFuncForBinTree someFunction tree =
        match tree with
        |Tree(node, leftChild, rightChild) -> Tree(someFunction node, mapFuncForBinTree someFunction leftChild, mapFuncForBinTree someFunction rightChild)
        |Tip(node) -> Tip(someFunction node)
