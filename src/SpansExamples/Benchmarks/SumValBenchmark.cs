using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using SpansExamples.Parsers;

namespace SpansExamples.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class SumValBenchmark
    {
        [Params(1, 100, 1000)]
        public int Params;

        private readonly Dictionary<int, string> values = new Dictionary<int, string>(3);

        [GlobalSetup]
        public void GlobalSetup()
        {
            var value = string.Join(',', Enumerable.Range(0, Params));
            values.Add(Params, value);
        }

        [Benchmark(Baseline = true)]
        public int TraditionalCommaParser_SumVal()
        {
            return TraditionalCommaParser.SumVal(values[Params]);
        }

        [Benchmark]
        public int AllocationFreeCommaParser_SumVal()
        {
            return AllocationFreeCommaParser.SumVal(values[Params]);
        }

        [Benchmark]
        public int LinqCommaParser_SumVal()
        {
            return LinqCommaParser.SumVal(values[Params]);
        }
    }
}