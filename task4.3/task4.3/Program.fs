module Logic  

open System.Numerics

    ///Переменная, абстракция, аппликаиця 
    type Term =
        | Var of char
        | Abstraction of char * Term
        | Application of Term * Term

    let chars = ['a'..'z'] 

    ///Образуется ли коллизия в выражении
    let rec collision x k =
        match x with
        | Var(s) when (s = k) -> true
        | Abstraction(s, p) when (s = k) || collision p k -> true  
        | Application(s, p) when (collision s k) || (collision p k) -> true      
        | _ -> false

    ///Переименование переменных
    let checkToRename a b c = 
        if (a = b) then 
            List.head (List.filter (fun x -> not (collision c x)) chars) 
        else a

    ///Альфа-преобразование
    let rec alphaСonversion check x y =
        match x with
        | Var(o) -> Var(checkToRename o check y)
        | Abstraction(s, p) -> Abstraction(checkToRename s check y, alphaСonversion check p y)
        | Application(s, p) -> Application(alphaСonversion check s y, alphaСonversion check p y)
    
    ///Разбираем и проверяем терм 
    let rec reductionOfAbstr check k y =
       match k with
       | Var(t) when (t = check) -> y
       | Var(t) -> Var(t)
       | Abstraction(m, n) -> Abstraction(m, reductionOfAbstr check n y)
       | Application(m, n) -> Application(reductionOfAbstr check m y, reductionOfAbstr check n y)

    ///Бета-редукция
    let rec betaReduction x =     
        match x with   
        | Var(t) -> Var(t) 

        | Application(Var(y), s) -> Application (Var(y), betaReduction s) 

        | Abstraction(t, s) -> Abstraction(t, betaReduction s)                
        
        | Application(Abstraction(t, u), y) -> 
            match y with
            | Var(o) when (collision x o) -> betaReduction (reductionOfAbstr (checkToRename t o x) (alphaСonversion o u x) y)     
            | _ ->  betaReduction (reductionOfAbstr t u y)

        | Application(s, y) -> Application(betaReduction s, betaReduction y)

