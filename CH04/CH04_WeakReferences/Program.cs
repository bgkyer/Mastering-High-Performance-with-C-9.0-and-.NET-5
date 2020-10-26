namespace CH04_WeakReferences
{
    using System;
    using System.Threading;

    class Program
    {
        private static readonly StrongReferenceObjectManager StrongReferences = new StrongReferenceObjectManager();
        private static readonly WeakReferenceObjectManager WeakReferences = new WeakReferenceObjectManager();

        static void Main(string[] _)
        {
            TestStrongReferences();
            TestWeakReferences();
            ProcessReferences();
        }

        private static void TestStrongReferences()
        {
            var o1 = new ReferenceObject() { Id = 1, Name = "Object 1" };
            var o2 = new ReferenceObject() { Id = 2, Name = "Object 2" };
            var o3 = new ReferenceObject() { Id = 3, Name = "Object 3" };

            StrongReferences.Add(o1);
            StrongReferences.Add(o2);
            StrongReferences.Add(o3);

            o1 = null;
            o2 = null;
            o3 = null;
        }

        private static void TestWeakReferences()
        {
            var o1 = new ReferenceObject() { Id = 1, Name = "Object 4" };
            var o2 = new ReferenceObject() { Id = 2, Name = "Object 5" };
            var o3 = new ReferenceObject() { Id = 3, Name = "Object 6" };

            WeakReferences.Add(o1);
            WeakReferences.Add(o2);
            WeakReferences.Add(o3);

            o1 = null;
            o2 = null;
            o3 = null;
        }

        private static void ProcessReferences()
        {
            int x = 0;

            while(x < 10)
            {
                StrongReferences.ListObjects();
                WeakReferences.ListObjects();
                Thread.Sleep(2000);
                GC.Collect();
                x++;
            }
        }
    }
}
