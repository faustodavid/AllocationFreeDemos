using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace SpansExamples.Parsers.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MarkdownExporterAttribute.GitHub]
    public class SumCommaSeparatedValuesBenchmark
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public int Traditional_SumCommaSeparatedValues(string content)
        {
            return TraditionalForeach.SumCommaSeparatedValues(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int AllocationFree_SumCommaSeparatedValues(string content)
        {
            return AllocationFree.SumCommaSeparatedValues(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int Linq_SumCommaSeparatedValues(string content)
        {
            return Linq.SumCommaSeparatedValues(content);
        }

        public IEnumerable<string> Data()
        {
            yield return string.Join(',', Enumerable.Range(0, 1));
            yield return string.Join(',', Enumerable.Range(0, 100));
            yield return string.Join(',', Enumerable.Range(0, 1000));
        }
    }
}