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
        let charList = Array.toList <| onlyBrackets.ToCharArray() 

        ///Считаем open/closed скобки
        let rec bracketCounter list n1 n2 n3 = 
            if (n1 * n2 * n3 = 0) then false
            else     
                match list with
                | [] -> 
                    n1 + n2 + n3 = 3
                | h :: t ->             
                    match h with
                    | '(' -> bracketCounter t (n1 + 1) n2 n3
                    | ')' -> bracketCounter t (n1 - 1) n2 n3                          
                    | '{' -> bracketCounter t n1 (n2 + 1) n3                                   
                    | '}' -> bracketCounter t n1 (n2 - 1) n3                          
                    | '[' -> bracketCounter t n1 n2 (n3 + 1)
                    | ']' -> bracketCounter t n1 n2 (n3 - 1)                                 
                    | _ -> failwith "very interesting..."

        bracketCounter charList 1 1 1     
          
        


    