module LazyFactory

    open Logic

    type LazyFactory() =
        
        /// - Однопоточный режим без синхронизации
        static member CreateSingleThreadedLazy (supplier) = SingleMode<'a>(supplier)

        /// - Многопоточный режим
        static member CreateMultiplyThreadedLazy (supplier) = MultiplyMode<'a>(supplier) 

        /// - Многопоточный режим + lock-free
        static member CreateMultiplyLockThreadedLazy (supplier) = MultiplyLockMode<'a>(supplier)