module logic  

//Вычитаем из полного количества элементов количество нечетных элементов (нечет % 2 по модулю = 1, складываем эти единицы)
    let evenNumWithMap list = 
        List.length list - List.sum (List.map (fun x -> abs (x % 2)) list)

//Четные берем в новый список и получаем его длину.
    let evenNumWithFilter list =
        List.length (List.filter (fun x -> x % 2 = 0) list)

//Объявляем acc как длину исходного списка, далее вычитаем из нее единицу, когда встречаем нечет по аналогии с 1ым методом.
    let evenNumWithFold list =
        List.fold (fun acc x -> acc - abs (x % 2)) (List.length list) list
