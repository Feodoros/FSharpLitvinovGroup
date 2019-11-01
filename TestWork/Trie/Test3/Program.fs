module Trie

////////////////////////////////
///        (s)               ///
///       /  \               ///  
///      (o)  (h)            ///
///      |    |     3        ///
///     (r)    (e)-(r)-(r) 4 ///
///     |       1    |       ///
///     (r) 2        (t) 5   ///
///      ...         ...     ///
////////////////////////////////


type Trie(node : Option<char>, words : string seq) =
    let childs = words |> Seq.filter(fun w -> w.Length > 0) |> Seq.groupBy(fun word -> word.[0]) |> Seq.map(fun (child, words) -> 
                       (child, Trie(Option.Some(child), words |> Seq.map (fun word -> word.Substring(1))))) |> Map.ofSeq

    new(words:string seq) = Trie(Option.None, words)

    member this.Value = node
    member this.ExistsEmptyword = this.Value.IsSome && words |> Seq.exists (fun word -> word.Length = 0)
    member this.Children = childs

    /// Спускаемся по дереву и ищем последний элемент с данным префиксом
    member private this.GoDown prefix =
        let rec getTrie (curr:Trie, currVal:string) =
            if currVal.Length = 0 then Option.Some(curr)
            else if not(curr.Children.ContainsKey(currVal.[0])) then Option.None
            else getTrie(curr.Children.Item(currVal.[0]), currVal.Substring(1))
    
        getTrie(this, prefix)

    ///Добавление слова в дерево
    member this.AddWord word =
        if this.Value.IsSome then invalidOp "Cannot add a word to a non-root Trie node"
        else            
            Trie(Option.None, word :: (List.ofSeq words)) |> ignore
            this.Contains(word)

    ///Получаем все слова из дерева
    member this.GetWords() =
        let rec getWordsInternal(trie : Trie, substring) : string seq =
            seq {
                if trie.Children.Count = 0 then yield substring
                else
                    if trie.ExistsEmptyword then yield substring
                    yield! trie.Children |> Map.toSeq |> Seq.collect(fun (c, t) -> getWordsInternal(t, substring + c.ToString()))
            }

        getWordsInternal(this, "")

    ///Количество элементов дерева
    member this.Size() =
        let size = this.GetWords()
        Seq.length size    
    
    ///Слова, начинающиеся с префикса
    member this.GetWordsPrefixedBy(value:string) =
        let t = this.GoDown(value)
        match t with
        | Option.None -> Seq.empty
        | _ -> t.Value.GetWords() |> Seq.map (fun w -> value + w)

    ///Количество слов в дереве с префиксом
    member this.CountPrefixedWords(value : string) =
        let count = Seq.length <| this.GetWordsPrefixedBy(value)    
        count

    ///Contains
    member this.Contains(word : string) =
        let endTrie = this.GoDown(word);
        let result = endTrie.IsSome && endTrie.Value.ExistsEmptyword
        result


type TrieBor() =
    let trie = Trie([""])
    member this.Add (word : string) = trie.AddWord(word)
    member this.Contains (word : string) = trie.Contains(word)
    member this.HowManyStartsWithPrefix (value : string) = trie.CountPrefixedWords(value)
    member this.Size() = trie.Size()


    





