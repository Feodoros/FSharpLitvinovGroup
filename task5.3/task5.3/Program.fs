module Logic 
    open System.IO
    open System
    open System.Collections.Generic
    
    type User =
        {
            userName : string; 
            userNumber : string;             
        }

    type Book () = 

        let list = List<User>()  

        member Book.GetUserList = list

        member Book.Add (user : User) = list.Add(user)

        member Book.SearchNumber (name : string) =             
            list.Find(fun i -> i.userName = name).userNumber
               
        member Book.SearchName (number : string) =
            list.Find(fun i -> i.userNumber = number).userName
                
        member Book.Print (list : List<User>) =             
            list.ForEach(fun i -> printfn " Name: %A \n Phone: %A \n" i.userName i.userNumber )         

        member Book.CreateFile (list : List<User>) = 

            let rec reformList (list: List<User>) (list1: List<String>) = 
                if list.Count = 0 then list1
                else list1.Add(list.Item(0).userName + " " + list.Item(0).userNumber)
                     list.RemoveAt(0)  
                     reformList list list1
                
            let listx = List<String>()    
            let fileFromBook = (reformList list listx).ToArray()  
            File.WriteAllLines("handbook.txt", fileFromBook)   

        member Book.ReadData newlist  =                 
                let rec readDataFromFile (contactList : List<User>) listFromTextFileBook =
                    match listFromTextFileBook with
                    |[] -> contactList
                    | (h : string) :: (t : string list) -> 
                        let textBook = Seq.toList (h.Split (' ', '\n'))  
                        let name = List.head textBook 
                        let number = List.head (List.tail textBook)
                        let user = {userName = name; userNumber = number }
                        contactList.Add(user)
                        readDataFromFile contactList t
                list.Clear() 
                list.AddRange(readDataFromFile newlist (Seq.toList (File.ReadLines("handbook.txt"))))
        
    let contactList = List<User>()    
    let book = Book()
    ///Запускаем телефонный справочник в интерактивном режиме.
    let rec loop contactList =            
        printfn "1 -> Exit"
        printfn "2 -> New contact"
        printfn "3 -> Search number"
        printfn "4 -> Search name"
        printfn "5 -> See all contacts"
        printfn "6 -> New text file"
        printfn "7 -> Read text file"
        
        let x = System.Console.ReadLine()
        match x with
        |"1" -> 
            printfn "You've left handbook."
        ///Добавляем только уникальные номера и имена в телефонный справочник.    
        |"2" -> 
            printfn "Name: "
            let name = Console.ReadLine()              
            if (book.GetUserList.Exists (fun i -> i.userName = name)) then 
                printfn "This name has already used."
            else               
                printfn "Number: "
                let number = Console.ReadLine()
                if (book.GetUserList.Exists(fun i -> i.userNumber = number)) then 
                    printfn "This number has already used." 
                else                   
                    let user = {userName = name; userNumber = number}            
                    book.Add(user)
            loop book.GetUserList
        |"3" ->
             printfn "Write name: "                 
             let name = Console.ReadLine()               
             printfn "%s" <| book.SearchNumber(name)
             loop contactList
        |"4" -> 
            printfn "Write number: "
            let number = Console.ReadLine()
            printfn "%s" <| book.SearchName(number) 
            loop contactList
        |"5" -> 
            if (contactList.Count = 0) then printfn "Add something to handbook."
            else book.Print contactList                
            loop contactList
        |"6" -> 
            book.CreateFile(contactList)
            printfn "Successfully."
            loop contactList
        |"7" -> 
            if (File.Exists("handbook.txt")) then         
                book.ReadData contactList
                printfn "Successfully" 
                loop (book.GetUserList)
            else 
                printfn "Nothing found." 
                loop contactList
        |_ -> 
            printfn "This command is not defined." 
            loop contactList
            
