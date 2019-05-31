module Logic 
    open System.Collections
    open System.Threading

    type LockQueue() =

        let mutable que = Queue()        

        let event = new AutoResetEvent(false)

        member this.IsEmpty =
            lock this (fun _ -> que.Count = 0)

        member this.Enqueue x =
            lock this (fun _ -> if (Interlocked.CompareExchange(ref que.Count, 0, 0) = 0) then 
                                    event.Set() |> ignore 
                                    que.Enqueue(x))

        member this.Dequeue =
            if (Interlocked.CompareExchange(ref que.Count, 0, 0) = 0) then 
                event.WaitOne() |> ignore
                que.Dequeue()
            else 
                lock this (fun _ -> que.Dequeue())