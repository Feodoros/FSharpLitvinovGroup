module logic 
    
    let checkBrackets (line : string)  = 

        let brackets = ['('; ')'; '['; ']'; '{'; '}']

        //Из строки делаем массив charов; из массива делаем список; фильтруем список, чтобы остались только скобки.
        let charList = (List.filter(fun x -> List.contains(x) brackets) (Array.toList <| line.ToCharArray()))

        //Строка только из скобок.
        let mutable onlyBrackets = String.concat "" <| List.map string charList

        //Удаляем из строки (),{},[] пока не выйдем из цикла. Если все ок, то результат - пустая строка.
        let mutable n = - 1
        let delete = 
            while (onlyBrackets.Length <> n) do
                n <- onlyBrackets.Length
                onlyBrackets <- onlyBrackets.Replace("()","").Replace("{}","").Replace("[]","")
        onlyBrackets = ""   

    