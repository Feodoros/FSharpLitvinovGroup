module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Check adding to book.`` () =
        
        let emptyList = Map.empty
        let contactList = emptyList.Add("322", "Fedor").Add("321", "Ilya").Add("123", "Alex")

        let book = Book()
        
        let updatedList = book.Add(book.Add(contactList, "SomeOne", "322"), "Roman", "998") 

        let check1 = Map.filter(fun key value -> key = "998" && value = "Roman") updatedList
        let check2 = Map.filter(fun key value -> key = "322" && value = "Fedor") updatedList

        check1 = Map.empty |> should equal false       
        check2 = Map.empty |> should equal true
   
    [<Test>]
    let ``Search number by name and search name by number.`` () =
        
        let book = Book()

        let emptyList = Map.empty
        let contactList = emptyList.Add("322", "Fedor").Add("321", "Fedor").Add("123", "Alex")
        
        let foundNames = book.FindByNumber(contactList, "123")
        let foundNumbers = book.FindByName(contactList, "Fedor")

        let check = List.exists(fun i -> i = "321") <| foundNumbers && 
                    List.exists(fun i -> i = "322") <| foundNumbers &&
                    List.length foundNumbers = 2                    &&
                    List.length foundNames = 1                      &&
                    List.exists(fun i -> i = "Alex") <| foundNames
        check |> should equal true        
    
    [<Test>]
    let ``Check read and write data.`` () =
        
        let book = Book()

        let emptyList = Map.empty
        let contactList1 = emptyList.Add("322", "Fedor").Add("123", "Alex")


        book.WriteFile(contactList1)

        let contactList2 =  book.ReadFile(Map.empty)       
        let check = List.exists(fun i -> i = ("322", "Fedor")) <| Map.toList contactList2 &&
                    List.exists(fun i -> i = ("123", "Alex")) <| Map.toList contactList2  &&
                    List.length <| Map.toList contactList2 = 2
        check |> should equal true

                                                                            
      

        
