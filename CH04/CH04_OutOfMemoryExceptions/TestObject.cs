using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH04_OutOfMemoryExceptions
{
    internal class TestObject
    {
        private List<object> Objects = new List<object>();

        public float Float { get; set; } = float.MaxValue;
        public double Double { get; set; } = double.MaxValue;
        public long Long { get; set; } = long.MaxValue;
        public decimal Money { get; set; } = decimal.MaxValue;
        public string Message { get; set; } = "The quick brown foxed jumped over the lazy dog.";
        public decimal[] Price { get; set; } = new decimal[10000];

        public TestObject()
        {
            Console.WriteLine();
            Console.WriteLine("Initializing test object:");
            using Process proc = Process.GetCurrentProcess();
            // The proc.PrivateMemorySize64 will returns the private memory usage in byte.
            // Would like to Convert it to Megabyte? divide it by 2^20
            double memory = proc.PrivateMemorySize64 / (1024 * 1024);
            Console.WriteLine($"Private Memory Usage: {memory}MB");
        }
    }
}
