module Logic 

    open System
    open System.Net
    open HtmlAgilityPack
    open System.Linq
    open System.IO    

    ///Получаем все ссылки со страницы.
    let getLinks (site : string) =
        let doc = HtmlWeb().Load(site)
        let linkTags = doc.DocumentNode.Descendants("link");
        let linkedPages = doc.DocumentNode.Descendants("a")
                                          .Select(fun a -> a.GetAttributeValue("href", null))
                                          .Where(fun u -> not (String.IsNullOrEmpty(u)))
                                          .Where(fun x -> x.StartsWith("http"))
        linkedPages


    let weightOfAllLinksFromPage(url : string) =
        
        ///Тут читаем доктайп
        let getHTMLAsync(url : string) =
            async {
                let webRequest = WebRequest.Create(url)
                use response = webRequest.GetResponse()
                use responseStream = response.GetResponseStream()
                use reader = new StreamReader(responseStream)
                return reader.ReadToEnd()
            }

        ///Тут скачиваем доктайп страницы, считаем его и печатаем.
        let downloadHTMLAndPrint(url : string) =
            async {
                try
                    let html = Async.StartAsTask(getHTMLAsync(url))
                    let! htmlTask = Async.AwaitTask(html)
                    do printfn "%s ––– %d" url htmlTask.Length
                with
                    | ex -> printfn "%A" ex.Message
            }

        let links = getLinks(url)

        Seq.map (fun url -> downloadHTMLAndPrint url) <| links
        |> Async.Parallel 
        |> Async.RunSynchronously 
        |> ignore
