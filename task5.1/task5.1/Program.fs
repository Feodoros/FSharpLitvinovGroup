module Logic 
    open System.Collections
    open System
    
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
        let stack = Stack()

        ///Работаем со стеком. Открывающие добавляем, закрывающие проверяем.
        let rec checkWithStack list (stack : Stack) =                 
                match list with
                | [] ->                 
                    stack.Count = 0
                | h :: t ->             
                    match h with
                    | '(' | '{' | '[' -> 
                        stack.Push(h)
                        checkWithStack t stack

                    | ')' -> if stack.Count = 0 || Convert.ToChar(stack.Pop()) <> '(' then false  
                             else checkWithStack t stack                     
                                               
                    | '}' -> if stack.Count = 0 || Convert.ToChar(stack.Pop()) <> '{' then false  
                             else checkWithStack t stack                         
                
                    | ']' -> if stack.Count = 0 || Convert.ToChar(stack.Pop()) <> '[' then false  
                             else checkWithStack t stack                                 

                    | _ -> failwith "very interesting..."

        checkWithStack charList stack   
          
        


    