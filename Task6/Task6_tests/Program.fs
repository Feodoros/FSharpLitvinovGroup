module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Test local Net of 3 computers``() = 
        let windows = {Name = "Windows"; ProbabilityOfInf = 70 }
        let mac = {Name = "MacOS"; ProbabilityOfInf = 15 }        
        let unix = {Name = "Solaris"; ProbabilityOfInf = 48 }        

        let listComputers = [{ OS = windows;  Inf = false }; { OS = unix;  Inf = false }; { OS = mac;  Inf = true }]

        let matrix : bool[,] = Array2D.zeroCreate 3 3
        let makeMatrix (matrix : bool[,]) = 
            matrix.[0,0] <- true;
            matrix.[0,1] <- true;
            matrix.[0,2] <- false;
            matrix.[1,0] <- false;
            matrix.[1,1] <- false;
            matrix.[1,2] <- true;
            matrix.[2,0] <- true;
            matrix.[2,1] <- false;
            matrix.[2,2] <- false;
            matrix

        let newNetwork = Network(listComputers, makeMatrix matrix)
        newNetwork.OneStepVirus()
        let list = List.filter (fun x -> x.Inf) newNetwork.Computers
        list.Length <> listComputers.Length |> should equal true
        newNetwork.StartVirus()
        newNetwork.CheckToInfected() |> should equal true