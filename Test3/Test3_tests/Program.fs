module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    ///В тестах тестируем сразу Dequeue, Enqueue, IsEmpty
    [<Test>]
    let ``Test 1`` () =       
        let que = LockQueue()

        let testLoop = 
            async {
                for i in [1..100] do
                    que.Enqueue i                                           
                do! Async.Sleep 10  
                printfn "..after"
                }
        Async.RunSynchronously testLoop
        que.IsEmpty |> should equal false

    [<Test>]
    let ``Test 2`` () =       
        let que = LockQueue()

        let enqueue = async {
            que.Enqueue 1
            do! Async.Sleep 2
        }

        let dequeue = async {
            let que1 = que.Dequeue 
            do! Async.Sleep 2
            que1 |> ignore
        }

        let enq = enqueue
        let deq = dequeue

        [enq; deq] 
        |> Async.Parallel
        |> Async.RunSynchronously  |> ignore

        que.IsEmpty |> should equal true    
        
        
   