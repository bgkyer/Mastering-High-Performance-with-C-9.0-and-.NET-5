namespace CH04_WeakReferences
{
    using System;
    using System.Collections.Generic;

    internal class StrongReferenceObjectManager
    {
        private readonly List<ReferenceObject> Objects = new List<ReferenceObject>();

        public void Add(ReferenceObject o)
        {
            Objects.Add(o);
        }

        public void ListObjects()
        {
            Console.WriteLine("Strong Reference Objects: ");
            foreach (var reference in Objects)
                Console.WriteLine($"- {reference.Name}");
        }
    }
}
