using System;

namespace CH04_Finalization
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
            InstantiateLocalObject();
            RunGarbageCollector();
            DisplayGeneration(_product);
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

        private static void InstantiateLocalObject()
        {
            var product = new Product()
            {
                Id = 2,
                Name = "Cute Kittie",
                Description = "Cudly child's toy.",
                UnitPrice = 5.75M
            };
            DisplayGeneration(product);
            _product = product;
            GC.Collect();
        }

        private static void DisplayGeneration(Product product)
        {
            Console.WriteLine($"local product: generation {GC.GetGeneration(product)}");
        }
    }
}
