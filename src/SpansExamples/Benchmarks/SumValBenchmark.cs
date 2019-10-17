using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using SpansExamples.Parsers;

namespace SpansExamples.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MarkdownExporterAttribute.GitHub]
    public class SumValBenchmark
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public int TraditionalCommaParser_SumVal(string content)
        {
            return TraditionalCommaParser.SumVal(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int AllocationFreeCommaParser_SumVal(string content)
        {
            return AllocationFreeCommaParser.SumVal(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int LinqCommaParser_SumVal(string content)
        {
            return LinqCommaParser.SumVal(content);
        }

        public IEnumerable<object> Data()
        {
            yield return string.Join(',', Enumerable.Range(0, 1));
            yield return string.Join(',', Enumerable.Range(0, 100));
            yield return string.Join(',', Enumerable.Range(0, 1000));
        }
    }
}