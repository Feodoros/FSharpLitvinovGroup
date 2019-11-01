module Logic 

    open System

    type MathFlow(delta : int) =

        member mathFlow.Bind (n : float, func) =
            func (Math.Round(n, delta))

        member mathFlow.Return (n : float) =
            Math.Round(n, delta)