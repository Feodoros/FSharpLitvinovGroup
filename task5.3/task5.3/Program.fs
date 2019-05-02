module Logic 
open System.IO
open System
    
    type User =
        {
            userName : string; 
            userNumber : string;             
        }

    type Book () = 

        let mutable list = []  

        member Book.GetUserList = list

        member Book.Add (user : User) = list <- (user :: list)

        member Book.SearchNumber (name : string) = 
            if (List.exists (fun i -> i.userName = name) list) then 
                (List.find (fun i -> i.userName = name) list).userNumber
            else "Contact with this name doesn't exist."  
               
        member Book.SearchName (number : string) =
            if (List.exists (fun i -> i.userNumber = number) list) then 
                (List.find (fun i -> i.userNumber = number) list).userName
            else "Contact with this number doesn't exist."                  

        member Book.Print list = 
            List.iter (fun i -> printfn " Name: %A \n Phone: %A \n" i.userName i.userNumber ) list         

        member Book.CreateFile list = File.WriteAllLines("handbook.txt", List.map (fun i -> i.userName + " " + i.userNumber) list)   

        member Book.ReadData newlist  = 

                let rec readDataFromFile contactList listFromTextFileBook =
                    match listFromTextFileBook with
                    |[] -> contactList
                    | (h : string) :: (t : string list) -> 
                        let textBook = Seq.toList (h.Split (' ', '\n'))  
                        let name = List.head textBook 
                        let number = List.head (List.tail textBook)
                        let user = {userName = name; userNumber = number }
                        readDataFromFile (user :: contactList) t

                list <- readDataFromFile newlist (Seq.toList (File.ReadLines("handbook.txt")))
        

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
            if (List.exists (fun i -> i.userName = name) book.GetUserList ) then 
                printfn "This name has already used."
            else               
                printfn "Number: "
                let number = Console.ReadLine()
                if (List.exists (fun i -> i.userNumber = number) book.GetUserList ) then 
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
            if (contactList.IsEmpty) then printfn "Add something to handbook."
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
                loop book.GetUserList
            else 
                printfn "Nothing found." 
                loop contactList
        |_ -> 
            printfn "This command is not defined." 
            loop contactList



    