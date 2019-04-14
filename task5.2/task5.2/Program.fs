module Logic 

    let funcStart x l = List.map (fun y -> y * x) l
   
    ///Избавляемся от fun y -> y * x.
    let func1 x l =  List.map ((*) x) l
    
    ///Избавляемся от l.
    let func2 x = List.map ((*) x)

    ///Пытаемся избавиться от аргумента х криво.
    let func3 = fun x -> List.map ((*) x)

    ///Избавились от аргумента, применили композицию.
    let funcFinal = (|>) List.map ((>>) (*))