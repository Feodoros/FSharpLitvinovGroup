module logic 
    
    //Match type of our phrase: it may be +, -, /, * or just a number.
    type Phrase =
        | Number of int
        | Plus of Phrase * Phrase
        | Minus of Phrase * Phrase
        | Divide of Phrase * Phrase
        | Multiply of Phrase * Phrase

    //Now we'r looking on our tree and detect type of our phrase then make some arithmetic operations one by one, step by step, descending from our tree
    let rec makeSomeOperation phrase =
        match phrase with 
        | Number number -> number
        | Plus(phrase1, phrase2) -> (makeSomeOperation phrase1) + (makeSomeOperation phrase2)
        | Minus(phrase1, phrase2) -> (makeSomeOperation phrase1) - (makeSomeOperation phrase2);
        | Multiply(phrase1, phrase2) -> (makeSomeOperation phrase1) * (makeSomeOperation phrase2)
        | Divide(phrase1, phrase2) -> 
            try (makeSomeOperation phrase1) / (makeSomeOperation phrase2)
            with
                | Failure(msg) -> printfn "%s" msg; 0
 