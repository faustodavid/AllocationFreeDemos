using BenchmarkDotNet.Running;
using SpansExamples.StringJoinAndConcat;
using SpansExamples.StringJoinAndConcat.Benchmarks;

namespace SpansExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringJoinAndConcatBenchmark>();
        }
    }
}