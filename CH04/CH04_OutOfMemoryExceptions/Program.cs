namespace CH04_OutOfMemoryExceptions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime;

    class Program
    {
        static void Main(string[] args)
        {
            GenerateOutOfMemoryException();
            PredictOutOfMemoryException();
            Console.ReadKey();
        }

        private static void GenerateOutOfMemoryException()
        {
            try
            {
                string value = new string('a', int.MaxValue);
            }
            catch (OutOfMemoryException ofmex)
            {
                Console.WriteLine($"Exception: {ofmex.GetBaseException().Message}");
            }
        }

        private static void PredictOutOfMemoryException()
        {
            try
            {
                List<byte[]> arrays = new List<byte[]>();
                const int size = int.MaxValue / 2;
                const int sizeMB = size / 1024 / 1024;
                for (int step = 0; step < 10000; step++)
                {
                    using (new MemoryFailPoint(sizeMB))
                    {
                        arrays.Add(new byte[size]);
                    }
                }
            }
            catch(InsufficientMemoryException imex)
            {
                Console.WriteLine($"Exception: {imex.GetBaseException().Message}");
            }
        }
    }
}
