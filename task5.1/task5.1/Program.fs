module Logic 
    
    ///Оставляем от нашей строки только строку из скобок.
    let transformString (line : string) =
        let brackets = ['('; ')'; '['; ']'; '{'; '}']

        ///Из строки делаем массив charов; из массива делаем список; фильтруем список, чтобы остались только скобки.
        let charList = (List.filter(fun x -> List.contains(x) brackets) (Array.toList <| line.ToCharArray()))

        ///Строка только из скобок.
        let onlyBrackets = String.concat "" <| List.map string charList
        onlyBrackets  
        
    let isBalanced (line : string) =        
        let onlyBrackets = transformString line
        
        ///Удаляем из строки (),{},[] пока не выйдем из цикла. Если все ок, то результат - пустая строка.
        let rec deleteAndCheck (str : string) (n : int) = 
            if (str.Length = 0) then true
            elif (str.Length = n) then false
            else 
                let prevLength = str.Length 
                let changedString = str.Replace("()","").Replace("{}","").Replace("[]","")
                deleteAndCheck changedString prevLength
        deleteAndCheck onlyBrackets -1            
        


    