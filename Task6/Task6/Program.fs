module Logic
open System.Collections.Generic
open System

    type TypeOS = 
        {   
            Name: string; 
            ProbabilityOfInf: int 
        }

    type TypeComp = 
        { 
            OS: TypeOS;
            mutable Inf: bool 
        }

    ///Модель заражения компьютеров в лок сети 
    type Network(newNetwork : list<TypeComp>, matrix : bool[,])=
        let r = Random()
        let mutable computersInNetwork = newNetwork
        let mutable matrixOfLink = matrix

        member Network.Computers = computersInNetwork

        member Network.OneStepVirus() =
                let computersInfectedNow = List<TypeComp>()
                for i in 0 .. (List.length Network.Computers) - 1 do
                    if (Network.Computers.[i].Inf) then
                        for j in 0 .. (List.length Network.Computers) - 1 do
                            if (matrixOfLink.[i,j] && (not Network.Computers.[j].Inf) && (not (computersInfectedNow.Contains(Network.Computers.[j])))) then
                                if (r.Next(1, 100) <= Network.Computers.[j].OS.ProbabilityOfInf) then
                                    Network.Computers.[j].Inf <- true
                                    computersInfectedNow.Add(Network.Computers.[j])

        ///Статус компьютеров в локальной сети
        member Network.StatusInfectedNow() =
               for computer in Network.Computers do
                   Console.WriteLine("OS:" + computer.OS.Name + " " + "Infection:" + computer.Inf.ToString())

        ///Проверяем зараженны ли все компы
        member Network.CheckToInfected() =
               let check = List.filter (fun x -> not x.Inf) Network.Computers
               check.Length = 0
        
        ///Начинаем заражение
        member Network.StartVirus() =
               let mutable i = 1;
               Console.WriteLine("Step 0");
               Network.StatusInfectedNow();
               while (not <| Network.CheckToInfected()) do
                   Network.OneStepVirus();
                   Console.WriteLine("Step " + i.ToString())
                   Network.StatusInfectedNow()
                   System.Threading.Thread.Sleep(800)
                   i <- 1 + i
               Console.ForegroundColor = ConsoleColor.Red
               Console.WriteLine("Oh, OVERALL infection!!!")
               