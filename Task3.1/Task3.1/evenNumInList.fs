module Logic 

    ///Делаем из четных нечетные, берем остаток от деления по модулю (1) и суммируем.
    let evenNumWithMapSumBy list = 
        List.sumBy (fun x -> abs ((x + 1) % 2)) list

    ///Четные берем в новый список и получаем его длину.
    let evenNumWithFilter list =
        List.length (List.filter (fun x -> x % 2 = 0) list)

    ///Объявляем acc как длину исходного списка, далее вычитаем из нее единицу, когда встречаем нечет по аналогии с 1ым методом.
    let evenNumWithFold list =
        List.fold (fun acc x -> acc - abs (x % 2)) (List.length list) list
