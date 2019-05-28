module Tests

    open NUnit.Framework
    open FsUnit
    open Logic


    [<Test>]
    let ``GetSummaryValue`` () =
        let lightCar1 = LightCar("Explorer", "White", "Ford", 2500000)
        let lightCar2 = LightCar("T", "Black", "Tesla", 8000000)
        let lightCar3 = LightCar("Hover H3", "Gray", "GREAT WALL", 1100000)

        let lightCars = [lightCar1; lightCar2; lightCar3]

        let heavyCar1 = HeavyCar(7000, "Ford", 5000000)
        let heavyCar2 = HeavyCar(10000, "Hyuindai", 3000000)
        let heavyCar3 = HeavyCar(7000, "BMW", 20000000)

        let heavyCars = [heavyCar1; heavyCar2; heavyCar3]

        let autoShowInfo = AutoShowInfo(lightCars, heavyCars)
 
        autoShowInfo.getSummaryValue() |> should equal 39600000


    [<Test>]
    let ``getAllBrends`` () =
        let lightCar1 = LightCar("Explorer", "White", "Ford", 2500000)
        let lightCar2 = LightCar("T", "Black", "Tesla", 8000000)
        let lightCar3 = LightCar("Hover H3", "Gray", "GREAT WALL", 1100000)

        let lightCars = [lightCar1; lightCar2; lightCar3]

        let heavyCar1 = HeavyCar(7000, "Ford", 5000000)
        let heavyCar2 = HeavyCar(10000, "Hyuindai", 3000000)
        let heavyCar3 = HeavyCar(7000, "BMW", 20000000)

        let heavyCars = [heavyCar1; heavyCar2; heavyCar3]

        let autoShowInfo = AutoShowInfo(lightCars, heavyCars)

        autoShowInfo.getAllBrends() |> should equal ["GREAT WALL"; "Tesla"; "Ford"; "BMW"; "Hyuindai"]