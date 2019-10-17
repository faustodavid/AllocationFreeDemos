# AllocationFreeDemos
Allocation free examples for high-performance code. 

> **Note:** Following code, examples are not production-ready. They are meant for educational purposes

## String parser
Receive a string of integers separated by commas and sum all of them.

Example:
Input: "2,4,5"
Output: 11

### Benchmarks

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT


```
|                           Method | Params |         Mean |       Error |        StdDev |       Median | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------------------- |------- |-------------:|------------:|--------------:|-------------:|------:|--------:|-------:|-------:|------:|----------:|
| AllocationFreeCommaParser_SumVal |      1 |     29.89 ns |   0.6256 ns |     0.8351 ns |     30.10 ns |  0.54 |    0.03 |      - |      - |     - |         - |
|    TraditionalCommaParser_SumVal |      1 |     55.27 ns |   1.1235 ns |     1.8142 ns |     54.33 ns |  1.00 |    0.00 | 0.0068 |      - |     - |      32 B |
|           LinqCommaParser_SumVal |      1 |     83.42 ns |   1.6722 ns |     2.3982 ns |     82.26 ns |  1.51 |    0.06 | 0.0136 |      - |     - |      64 B |
|                                  |        |              |             |               |              |       |         |        |        |       |           |
| AllocationFreeCommaParser_SumVal |    100 |  1,592.86 ns |  31.7862 ns |    71.7468 ns |  1,575.90 ns |  0.48 |    0.02 |      - |      - |     - |         - |
|    TraditionalCommaParser_SumVal |    100 |  3,222.01 ns |  64.1432 ns |    83.4042 ns |  3,186.12 ns |  1.00 |    0.00 | 0.8354 | 0.0114 |     - |    3944 B |
|           LinqCommaParser_SumVal |    100 |  4,202.27 ns |  85.7287 ns |    75.9962 ns |  4,198.67 ns |  1.31 |    0.04 | 0.8392 | 0.0076 |     - |    3976 B |
|                                  |        |              |             |               |              |       |         |        |        |       |           |
| AllocationFreeCommaParser_SumVal |   1000 | 16,021.36 ns | 244.0295 ns |   216.3258 ns | 16,073.88 ns |  0.48 |    0.01 |      - |      - |     - |         - |
|    TraditionalCommaParser_SumVal |   1000 | 33,702.45 ns | 468.8789 ns |   415.6489 ns | 33,780.81 ns |  1.00 |    0.00 | 8.4229 | 1.0376 |     - |   39944 B |
|           LinqCommaParser_SumVal |   1000 | 44,353.86 ns | 882.1225 ns | 1,879.8749 ns | 44,377.95 ns |  1.31 |    0.04 | 8.4839 | 1.0376 |     - |   39976 B |
