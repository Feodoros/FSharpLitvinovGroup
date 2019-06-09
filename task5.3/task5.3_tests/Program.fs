module Tests 

    open NUnit.Framework
    open FsUnit
    open Logic 
    open System.Linq

    [<Test>]
    let ``Check adding to book.`` () =

        let contact'0 = {userName = "Fedor"; userNumber = "777"}
        let contact'1 = {userName = "Alex"; userNumber = "665"}

        let book = Book()
        book.Add(contact'0)
        book.Add(contact'1)

        (book.GetUserList).Exists (fun i -> i.userName = contact'0.userName && i.userNumber = contact'0.userNumber) 
        |> should equal true

        (book.GetUserList).Exists(fun i -> i.userName = contact'1.userName && i.userNumber = contact'1.userNumber) 
        |> should equal true
   
    [<Test>]
    let ``Search number by name and search name by number.`` () =
        let contact'0 = {userName = "Fedor"; userNumber = "777"}
        let contact'1 = {userName = "Alex"; userNumber = "665"}

        let book = Book()
        book.Add(contact'0)
        book.Add(contact'1)

        book.SearchNumber("Alex") 
        |> should equal "665"

        book.SearchName("777") 
        |> should equal "Fedor"
        
    
    [<Test>]
    let ``Check read and write data.`` () =
        let contact'0 = {userName = "Fedor"; userNumber = "777"}
        let contact'1 = {userName = "Alex"; userNumber = "665"}

        let book = Book()
        book.Add(contact'0)
        book.Add(contact'1)

        book.CreateFile (book.GetUserList)

        let book1 = Book()
        book1.ReadData (book.GetUserList)

        book.GetUserList.SequenceEqual(book1.GetUserList)  
        |> should equal true

        
