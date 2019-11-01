module Tests

    open System
    open NUnit.Framework
    open FsUnit    
    open System.Threading
    open System.Threading.Tasks
    open Logic
    open LazyFactory
    

    let rand() =
        let rndGen = Random(int DateTime.Now.Ticks)
        rndGen.Next(20, 60)


    [<Test>]
    let ``Check SingleMode``() =
        
        let object = LazyFactory.CreateSingleThreadedLazy(fun () -> 344)
        let a = object :> ILazy<int> 
        let check (x : ILazy<int>) = x.Get()                         

        object.IsDone |> should equal false
        check object |> ignore
        object.IsDone |> should equal true
        a.Get() |> should equal 344


    [<Test>]
    let ``Check MultiplyMode``() =

        let object = LazyFactory.CreateMultiplyThreadedLazy(fun () -> 344)            
        
        let check (x : ILazy<int>) = x.Get ()                  

        object.IsDone |> should equal false
        let first = check object
        let second = check object
        object.IsDone |> should equal true
        first.Equals(second) |> should equal true


    [<Test>]
    let ``Check values in MultiplyMode``() =

        let object = LazyFactory.CreateMultiplyThreadedLazy(fun () -> new obj())
        let a = (object :> ILazy<obj>).Get()
        ignore <| Seq.map(fun x -> ((object :> ILazy<obj>).Get ()).Equals(a) |> should be True) [|1..rand()|] 


    [<Test>]
    let ``Check race in MultiplyMode``() =

        let check (x : ILazy<int>) = x.Get ()
        let object = LazyFactory.CreateMultiplyThreadedLazy (fun () -> 28)       

        let testSeq = seq { for i in 1..rand() -> object }
        testSeq |> Seq.map (fun x ->
                            async {
                                let otherRes = check x
                                (check object).Equals(otherRes) |> should equal true
                            }) |> Async.Parallel |> Async.RunSynchronously |> ignore


    [<Test>]
    let ``Check values in MultiplyLockMode``() =
    
        let object = LazyFactory.CreateMultiplyLockThreadedLazy(fun () -> new obj())
        let a = (object :> ILazy<obj>).Get()
        ignore <| Seq.map(fun x -> ((object :> ILazy<obj>).Get ()).Equals(a) |> should be True) [|1..rand()|] 
     

    [<Test>]
    let ``Check race in MultiplyLockMode``() =

        let check (x : ILazy<int>) = x.Get ()
        let object = LazyFactory.CreateMultiplyLockThreadedLazy (fun () -> 28)       
    
        let first = check object

        let testSeq = seq { for i in 1..rand() -> object }
        testSeq |> Seq.map (fun x ->
                            async {
                                let otherRes = check x
                                first.Equals(otherRes) |> should equal true
                            }) |> Async.Parallel |> Async.RunSynchronously |> ignore