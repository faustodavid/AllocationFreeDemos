using BenchmarkDotNet.Running;
using SpansExamples.Benchmarks;

namespace SpansExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<SumValBenchmark>();
        }
    }
}