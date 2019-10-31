using BenchmarkDotNet.Running;
using SpansExamples.Parsers.Benchmarks;
using SpansExamples.StringJoinAndConcat.Benchmarks;

namespace SpansExamples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<SumCommaSeparatedValuesBenchmark>();
            BenchmarkRunner.Run<StringJoinAndConcatBenchmark>();
        }
    }
}