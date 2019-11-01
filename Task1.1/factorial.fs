
let rec readInteger() = 
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | false, _ -> printfn "Waiting for integer number."; readInteger()
    | _, x -> x 

let x = readInteger()

let rec fact n =  
  if n = 0 then 1
  else n * fact(n - 1)

let answer  = 
    if x >= 0 then (fact x).ToString()
    else "Error. Your num < 0, sorry."
   
