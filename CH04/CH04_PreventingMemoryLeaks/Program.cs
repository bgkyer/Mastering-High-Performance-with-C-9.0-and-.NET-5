namespace CH04_PreventingMemoryLeaks
{
    using System;

    class Program
    {
        private static Product _product;

        static void Main(string[] _)
        {
            InstantiateObject();
            PrintObjectData();
            RemoveObjectReference();
            RunGarbageCollector();
        }

        private static void InstantiateObject()
        {
            Console.WriteLine("Instantiating Product.");
            _product = new Product()
            {
                Id = 1,
                Name = "Polly Parrot",
                Description = "Cudly child's toy.",
                UnitPrice = 7.99M
            };
        }

        private static void PrintObjectData()
        {
            Console.WriteLine(_product.ToString());
        }

        private static void RemoveObjectReference()
        {
            _product = null;
        }

        private static void RunGarbageCollector()
        {
            GC.Collect();
        }
    }
}
