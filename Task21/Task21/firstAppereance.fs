module Logic 

    let firstAppearance list number = 
        let rec loop list index =
            match list with
            |[] -> None
            | h::t when h = number -> Some(index)
            | h::t -> loop t (index + 1)
        loop list 0

    