using System;

namespace CH03_PassByValueAndReference
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            Console.WriteLine("Chapter 3: Pass by value and reference");
            Console.WriteLine($"=====================================");
            Console.WriteLine($"int x = 0;");
            AddByValue(x);
            Console.WriteLine($"    AddByValue(x): {x}");
            AddByReference(ref x);
            Console.WriteLine($"AddByReference(x): {x}");
        }

        public static void AddByValue(int x)
        {
            x++;
        }

        public static void AddByReference(ref int x)
        {
            x++;
        }
    }
}
