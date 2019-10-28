using System.Collections.Generic;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace SpansExamples.StringJoinAndConcat.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MarkdownExporterAttribute.GitHub]
    public class StringJoinAndConcatBenchmark
    {
        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public string TraditionalStringJoin_Join(string[] content)
        {
            return Traditional.JoinAndConcatBrackets(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public string AllocationFreeStringJoin_Join(string[] content)
        {
            return AllocationFree.JoinAndConcatBrackets(content);
        }

        public IEnumerable<string[]> Data()
        {
            var meaningfulStructure = MeaningfulStructure.CreateStub();
            var serializedStructure = JsonSerializer.Serialize(meaningfulStructure);

            yield return new[] {serializedStructure};
            yield return DuplicateString(serializedStructure, 10);
            yield return DuplicateString(serializedStructure, 100);
            yield return DuplicateString(serializedStructure, 1000);
        }

        public string[] DuplicateString(string content, int times)
        {
            var array = new string[times];
            for (var i = 0; i < times; i++)
            {
                array[i] = content;
            }

            return array;
        }
    }
}