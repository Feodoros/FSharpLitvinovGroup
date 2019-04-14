module Logic 
    
    ///Match type of our phrase: it may be +, -, /, * or just a number.
    type Phrase =
        | Number of int
        | Plus of Phrase * Phrase
        | Minus of Phrase * Phrase
        | Divide of Phrase * Phrase
        | Multiply of Phrase * Phrase

    
    ///Now we'r looking on our tree and detect type of our phrase then make some arithmetic operations one by one,
    ///step by step, descending from our tree.
    exception ZeroException of string
    let rec makeSomeOperation phrase =
        match phrase with 
        | Number number -> number
        | Plus(phrase1, phrase2) -> (makeSomeOperation phrase1) + (makeSomeOperation phrase2)
        | Minus(phrase1, phrase2) -> (makeSomeOperation phrase1) - (makeSomeOperation phrase2);
        | Multiply(phrase1, phrase2) -> (makeSomeOperation phrase1) * (makeSomeOperation phrase2)
        | Divide(phrase1, phrase2) -> 
            if (phrase2 = Number 0) then raise (ZeroException("Divisor cannot be zero!"))
            else
                (makeSomeOperation phrase1) / (makeSomeOperation phrase2)
        
   