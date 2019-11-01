
module Tests 

    open NUnit.Framework
    open FsUnit
    open Trie

    [<Test>]
    let ``Check Contains``() = 
        let word = "abc"
        let t = TrieBor()
        let t2 = t.Add(word)
        let ans = t.Contains(word)
        ans |> should equal false
        
    [<Test>]
        let ``Check prefix``() = 
            let t = TrieBor()
            let t2 = t.Add("abc")
            let t3 = t.Add("ab")
            let result = t.HowManyStartsWithPrefix("a") 
            result |> should equal 0



