module Logic 
    
    //Проверяем число: если у него нет делитель от 2 до квадратного корня из этого же числа, то оно простое.
    let isPrime num = 
        let limit = int (sqrt(float num))
        seq {2..limit}
        |> Seq.exists (fun x -> num % x = 0) 
        |> not

    //Не успокаиваемся пока не найдем след простое число.
    let rec nextPrime n = 
        if isPrime (n + 1) then n + 1
        else nextPrime (n + 1)

    //Создаем последовательность с помощью Seq.unfold.
    //Начинаем с 2 и следующее число в последовательности -  результат работы метода nextPrime,
    //который берет крайний с права элемент последовательости
    //и ищет следующее число (простое) в последовательность. 
    let rec makeSequenceOfPrimes () =
         Seq.unfold(fun n -> Some(n, nextPrime n)) 2
