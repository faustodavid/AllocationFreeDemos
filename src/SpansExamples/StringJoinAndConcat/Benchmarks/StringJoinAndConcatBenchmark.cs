using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
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
        private readonly string serializedStructure;

        public StringJoinAndConcatBenchmark()
        {
            var meaningfulStructure = MeaningfulStructure.CreateStub();
            serializedStructure = JsonSerializer.Serialize(meaningfulStructure);
        }

        [Benchmark(Baseline = true)]
        [ArgumentsSource(nameof(Data))]
        public void Traditional_JoinAndConcatBrackets(string[] content, int n)
        {
            Traditional.JoinAndConcatBrackets(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void OverheadFree_JoinAndConcatBrackets(string[] content, int n)
        {
            OverheadFree.JoinAndConcatBrackets(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void StringBuilder_JoinAndConcatBrackets(string[] content, int n)
        {
            TraditionalStringBuilder.JoinAndConcatBrackets(content);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void StringBuilder_WithInitialCapacitySet_JoinAndConcatBrackets(string[] content, int n)
        {
            var length = AllocationFree.CalculateRequiredLength(content);
            TraditionalStringBuilder.JoinAndConcatBrackets(content, length);
        }

        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public void AllocationFree_JoinAndConcatBrackets(string[] content, int n)
        {
            var length = AllocationFree.CalculateRequiredLength(content);
            if (length > 1024)
            {
                var largeBuffer = ArrayPool<char>.Shared.Rent(length);
                Span<char> bufferSpan = largeBuffer;
                AllocationFree.JoinAndConcatBrackets(content, bufferSpan);
                ArrayPool<char>.Shared.Return(largeBuffer);
                return;
            }

            Span<char> buffer = stackalloc char[length];
            AllocationFree.JoinAndConcatBrackets(content, buffer);
        }

        public IEnumerable<object[]> Data()
        {
            yield return new object[] { Enumerable.Range(0, 1).Select(n => serializedStructure).ToArray(), 1 };
            yield return new object[] { Enumerable.Range(0, 10).Select(n => serializedStructure).ToArray(), 10 };
            yield return new object[] { Enumerable.Range(0, 100).Select(n => serializedStructure).ToArray(), 100 };
            yield return new object[] { Enumerable.Range(0, 1000).Select(n => serializedStructure).ToArray(), 1000 };
        }
    }
}