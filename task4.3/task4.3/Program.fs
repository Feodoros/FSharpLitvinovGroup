module Logic  

    ///Тип выражения -- буква, все выражение, лямбда-терм
    type Term =
        | Letter of char
        | Exp of char * Term
        | FullExp of Term * Term

    let chars = ['a'..'z'] 

    ///Образуется ли коллизия в выражении
    let rec collision x c =
        match x with
        | Letter(s) when (s = c) -> true
        | Exp(s, p) when (s = c) || collision p c -> true  
        | FullExp(s, p) when (collision s c) || (collision p c) -> true      
        | _ -> false

    ///Переименование переменных
    let checkToRename a b c = 
        if (a = b) then 
            List.head (List.filter (fun x -> not (collision c x)) chars) 
        else a

    ///Альфа-преобразование
    let rec alphaReduction check x y =
        match x with
        | Letter(o) -> Letter(checkToRename o check y)
        | Exp(s, p) -> Exp(checkToRename s check y, alphaReduction check p y)
        | FullExp(s, p) -> FullExp(alphaReduction check s y, alphaReduction check p y)
    
    let rec betaExp check x y =
       match x with
       | Letter(t) when (t = check) -> y
       | Letter(t) -> Letter(t)
       | Exp(m, n) -> Exp(m, betaExp check n y)
       | FullExp(m, n) -> FullExp(betaExp check m y, betaExp check n y)

    ///Бета-редукция
    let rec betaReduction x =     
        match x with   
        | Letter(t) -> Letter(t) 
        | Exp(t, s) -> 
            match s with
                | FullExp(m, n) -> Exp(t, betaReduction (FullExp(betaReduction m, betaReduction n)))
                | Exp(m, n) -> Exp(t, betaReduction s)
                | _ -> Exp(t, s)
        | FullExp(Letter(y), s) -> 
            match s with
            | FullExp(m, n) -> FullExp(Letter(y), betaReduction (FullExp(betaReduction m, betaReduction n)))
            | _ -> FullExp(Letter(y), s)
        | FullExp(Exp(t, u), y) -> 
            match y with
            | Letter(o) when (collision x o) -> betaReduction (betaExp (checkToRename t o x) (alphaReduction o u x) y)     
            | _ ->  betaReduction (betaExp t u y)
        | FullExp(s, y) -> betaReduction (FullExp(betaReduction s, betaReduction y))

