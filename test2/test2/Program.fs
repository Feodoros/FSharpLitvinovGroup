module Logic

    // Тип для хранения легкового автомобиля.
    type LightCar(model: string, color: string, brend: string, value: int) =
        member this.model = model
        member this.color = color
        member this.brend = brend
        member this.value = value

    // Тип для хранения грузового автомобиля.
    type HeavyCar(weight: int, brend: string, value: int) =
        member this.weight = weight
        member this.brend = brend
        member this.value = value
    
    // Тип для хранения информации об автомобилях.
    type AutoShowInfo(lightCars: list<LightCar>, heavyCars: list<HeavyCar>) =
        member this.lightCars = lightCars
        member this.heavyCars = heavyCars

        // Общая сумма всех автомобилей.
        member this.getSummaryValue() =

            // Общая сумма легковых автомобилей.
            let rec loop1 (list: list<LightCar>, acc) = 
                match list with
                |head::tail -> loop1 (tail, (acc + head.value))
                |[] -> acc

            // Общая сумма грузовых автомобилей.
            let rec loop2 (list: list<HeavyCar>, acc) = 
                match list with
                |head::tail -> loop2 (tail, (acc + head.value))
                |[] -> acc

            (loop1 (lightCars, 0) + loop2 (heavyCars, 0))

        // Все марки продаваемых автомобилей.
        member this.getAllBrends() =

            // Все марки легковых автомобилей.
            let rec loop1 (list: list<LightCar>, acc: list<string>) = 
                match list with
                |head::tail -> loop1 (tail, (head.brend :: acc))
                |[] -> acc

            // Все марки грузовых автомобилей.
            let rec loop2 (list: list<HeavyCar>, acc) = 
                match list with
                |head::tail -> loop2 (tail, (head.brend :: acc))
                |[] -> acc

            (loop1 (lightCars, [])) @ (loop2 (heavyCars, [])) |> List.distinct