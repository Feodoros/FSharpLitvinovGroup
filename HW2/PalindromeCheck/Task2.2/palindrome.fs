module logic 

    open System

    let isPalindrome (s: string) = String.Compare(s, String(Array.rev (s.ToCharArray())), false) = 0 

    let answer = isPalindrome "FSSF"

    printfn "String is palindrome: %b" <| answer 