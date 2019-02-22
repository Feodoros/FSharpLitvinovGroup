
let rec fib n =
    if n > 3 then fib (n-1) + fib (n-2)
    else 1

let Answer = fib 5