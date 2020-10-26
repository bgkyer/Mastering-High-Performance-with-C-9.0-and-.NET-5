namespace CH03_DynamicPerformance
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    class Program
    {
        dynamic _dynamicType;

        static void Main(string[] _)
        {
            BenchmarkRunner.Run<BenchmarkTests>();
        }
    }
}
