module tests 
    
    open NUnit.Framework
    open FsUnit
    open logic

    [<Test>]
    let ``String "assa" is palindrome that is why result should be true`` () =
        isPalindrome "assa" |> should equal true

    [<Test>]
    let ``String "Result" is not palindrome that is why result should be false`` () =
        isPalindrome "Result" |> should equal false

    [<Test>]
    let ``Empty string is palindrome that is why result should be true`` () =
        isPalindrome "" |> should equal true 