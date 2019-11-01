module Tests 
    
    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Check GoogleDisk``() = 
        let site = "http://hwproj.me/courses/31"
        let links = getLinks(site)
        let ans = Seq.length links
        ans |> should equal 17 

