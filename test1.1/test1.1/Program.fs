module Logic 
  
    let supermap list functions =
        let rec loop list func temp =
            match list with
            | [last] -> loop [] func (List.append(func last) temp)        
            | h::t -> loop t func (List.append(func h) temp)
            | [] -> temp  
        loop list functions [] 

    let f x = x + 1
    let g x = x + 3

    let ans = supermap [1;2;3] (fun x -> [f x; g x])      
    printf("%A") ans  