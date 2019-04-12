module Logic 

    ///По сути переписанная функция из первой домки. 
    ///Индекс взят любой больше 40 (посмотрел список чисел на википедии). Я взял 42.
    let sumNum () =
        let rec loop counter secondPrevious firstPrevious sum =               
                let sumOfTwo = secondPrevious  + firstPrevious
                let decreasedCounter = counter - 1
                if (secondPrevious < 1000000) then
                    if ((secondPrevious  % 2) = 0) then
                        let helpingIncSum = sum + secondPrevious 
                        loop decreasedCounter firstPrevious sumOfTwo helpingIncSum                    
                    else 
                        loop decreasedCounter firstPrevious sumOfTwo sum
                else sum
        loop 42 0 1 0 
