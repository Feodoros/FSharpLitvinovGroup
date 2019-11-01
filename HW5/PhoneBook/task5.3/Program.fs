module Logic 
    
open System.IO
open System
open System.Runtime.Serialization.Formatters.Binary
open System.Collections.Generic
        
/// Класс Book сделан для тестирования
type Book () =
    /// key -- number, value -- name, так как номер должен быть уникальным -- 
    /// у одного пользователя может быть несколько номеров, но у одного номера только один пользователь
    member Book.Add (contactList, name, number) =
        Map.add number name contactList 

    member Book.FindByName (contactList, name) = 
      
        let rec takeOne dList list = 
            match dList with
            | head::tail -> takeOne tail ((fst head)::list)
            |_ -> list
        takeOne (Map.toList <| Map.filter (fun key value -> value = name) contactList) List.Empty


    member Book.FindByNumber (contactList, number) = 
        let rec takeOne dList list = 
            match dList with
            | head::tail -> takeOne tail ((snd head)::list)
            |_ -> list
        takeOne (Map.toList <| Map.filter (fun key value -> key = number) contactList) List.Empty

    member Book.WriteFile (contactList) = 
        let writeValue outputStream (x: 'a) =
                let bf = BinaryFormatter()
                bf.Serialize(outputStream, box x)

        use fsOut = new FileStream("handbook.txt", FileMode.Create)
        writeValue fsOut contactList
        fsOut.Close()           

    /// Добавляем в книгу только те конакты из текстового файла, номера которых
    /// не встречаются в уже имеющейся книге
    member Book.ReadFile (contactList) = 

        let rec removeCopy map1 map2 = 
            match map1 with
            | head::tail -> let newMap = Map.filter (fun key value -> key <> (fst head)) map2
                            removeCopy tail newMap 
                            
            |_ -> map2 

        let toTuple (kvp : KeyValuePair<_,_>) =
            kvp.Key, kvp.Value

        /// Concatenate all the input maps. Where there are duplicate input keys, 
        /// the last mapping is preserved.
        let concat maps = 
            maps
            |> Seq.concat
            |> Seq.map toTuple
            |> Map.ofSeq

        let readValue inputStream =
            let bf = BinaryFormatter()
            let res = bf.Deserialize(inputStream)
            unbox res

        try
            use fsIn = new FileStream("handbook.txt", FileMode.Open)
            let res : Map<string, string> = readValue fsIn            
            fsIn.Close()
            let newRes = removeCopy (Map.toList contactList) res
            concat [|newRes; contactList|] 
        with
            | :? System.IO.FileNotFoundException -> 
                                                    printfn "Had not found file!";
                                                    contactList

let book = Book()
let contactList = Map.empty

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
        Environment.Exit(0)

    ///Добавляем только уникальные номера и имена в телефонный справочник.    
    |"2" -> 
        printfn "Name: "
        let name = Console.ReadLine()   
              
        printfn "Number: "
        let number = Console.ReadLine()

        if (Map.exists (fun key value -> key = number) contactList) then
            printfn "This name has already used."  
             
        loop <| book.Add(contactList, name, number)                

    |"3" ->
         printfn "Write name: "                 
         let name = Console.ReadLine()      
         
         if  book.FindByName(contactList, name).IsEmpty then 
            printfn "This name is not used"
         else
            printfn "Found numbers: "
            List.iter (fun i -> printfn "%A" i ) <| book.FindByName(contactList, name)

         loop contactList

    |"4" -> 
        printfn "Write number: "
        let number = Console.ReadLine()

        if  book.FindByNumber(contactList, number).IsEmpty then 
            printfn "This number is not used"
        else
            printfn "Found name: "
            List.iter (fun i -> printfn "%A" i ) <| book.FindByNumber(contactList, number)

        loop contactList

    |"5" -> 
        if (contactList.IsEmpty) then printfn "Add something to handbook."
        else Map.iter (fun key value -> printfn " Name: %A \n Phone: %A \n" value key) <| contactList               
        loop contactList

    |"6" -> 
        book.WriteFile(contactList)
        printfn("Successfully writed data.")
        loop contactList
        
    |"7" -> 
        printfn "Successfully loaded phonebook!"
        loop <| book.ReadFile(contactList)            
            
    |_ -> 
        printfn "This command is not defined." 
        loop contactList

loop contactList

