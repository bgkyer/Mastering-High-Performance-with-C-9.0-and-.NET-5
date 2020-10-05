namespace CH03_BoxingAndUnboxing
{
    using System;
    using System.Diagnostics;

    class Program
    {
        static void Main(string[] _)
        {
            Console.WriteLine("Chapter 3: Boxing and unboxing example.");

            int a = 1, b = 2;
            object x = 4, y = 4;
            int z;
            var stopwatch = new Stopwatch();

            for (var i = 0; i <= 9; i++)
            {
                Console.WriteLine("======================================================================");
                stopwatch.Restart();
                z = a + b;
                stopwatch.Stop();
                Console.WriteLine($"Adding ints {a} and {b} together to produce the value {z} took {stopwatch.ElapsedTicks} ticks.");
                stopwatch.Restart();
                z = (int)x + (int)y;
                stopwatch.Stop();
                Console.WriteLine($"Adding objects {a} and {b} together to produce the value {z} took {stopwatch.ElapsedTicks} ticks.");
            }
        }
    }
}
