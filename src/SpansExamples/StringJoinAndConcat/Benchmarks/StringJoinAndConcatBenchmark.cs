using System;
using System.Buffers;
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
        public void Traditional_JoinAndConcatBrackets(string[] content)
        {
            Traditional.JoinAndConcatBrackets(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void OverheadFree_JoinAndConcatBrackets(string[] content)
        {
            OverheadFree.JoinAndConcatBrackets(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void AllocationFree_JoinAndConcatBrackets(string[] content)
        {
            var length = AllocationFree.CalculateRequiredLength(content);
            if (length > 1024)
            {
                var largeBuffer = ArrayPool<char>.Shared.Rent(length);
                Span<char> bufferSpan = largeBuffer;
                AllocationFree.JoinAndConcatBrackets(content, ref bufferSpan);
                ArrayPool<char>.Shared.Return(largeBuffer);
                return;
            }

            Span<char> buffer = stackalloc char[length];
            AllocationFree.JoinAndConcatBrackets(content, ref buffer);
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