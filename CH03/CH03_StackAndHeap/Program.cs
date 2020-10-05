namespace CH03_StackAndHeap
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] _)
        {
            ProcessClassNoReferences();
            ProcessStructNoReferences();
            ProcessClassWithReferences();
            ProcessStructWithReferences();
        }

        private static void ProcessClassNoReferences()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            var _ = new ClassNoReferences()
            {
                Id = 1,
                PurchaseDate = DateTime.Now,
                Price = (1.50M * -1)
            };
            stopwatch.Stop();
            Console.WriteLine($"ProcessClassNoReferences: {stopwatch.ElapsedTicks} ticks");
        }

        private static void ProcessClassWithReferences()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            var _ = new ClassWithReferences()
            {
                Id = 1,
                Name = "Discard",
                Price = (1.50M * 2)
            };
            stopwatch.Stop();
            Console.WriteLine($"ProcessClassWithReferences: {stopwatch.ElapsedTicks} ticks");
        }

        private static void ProcessStructNoReferences()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            var _ = new StructNoReferences()
            {
                Id = 1,
                PurchaseDate = DateTime.Now,
                Price = 1.50M
            };
            stopwatch.Stop();
            Console.WriteLine($"ProcessStructNoReferences: {stopwatch.ElapsedTicks} ticks");
        }

        private static void ProcessStructWithReferences()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();
            var _ = new StructWithReferences()
            {
                Id = 1,
                Name = "Discard",
                Price = 1.50M
            };
            stopwatch.Stop();
            Console.WriteLine($"ProcessStructWithReferences: {stopwatch.ElapsedTicks} ticks");
        }
    }
}
