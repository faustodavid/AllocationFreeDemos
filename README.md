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
|                           Method |                content |         Mean |         Error |        StdDev |       Median | Ratio | RatioSD |  Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------------------- |----------------------- |-------------:|--------------:|--------------:|-------------:|------:|--------:|-------:|-------:|------:|----------:|
| AllocationFreeCommaParser_SumVal |                      0 |     21.11 ns |     0.4402 ns |     0.4118 ns |     21.26 ns |  0.45 |    0.02 |      - |      - |     - |         - |
|    TraditionalCommaParser_SumVal |                      0 |     47.30 ns |     0.9632 ns |     1.7121 ns |     46.50 ns |  1.00 |    0.00 | 0.0068 |      - |     - |      32 B |
|           LinqCommaParser_SumVal |                      0 |     75.41 ns |     1.5203 ns |     2.5816 ns |     76.19 ns |  1.59 |    0.09 | 0.0136 |      - |     - |      64 B |
|                                  |                        |              |               |               |              |       |         |        |        |       |           |
| AllocationFreeCommaParser_SumVal |  0,1,2(...)98,99 [289] |  1,628.34 ns |    32.4146 ns |    71.1508 ns |  1,635.89 ns |  0.50 |    0.03 |      - |      - |     - |         - |
|    TraditionalCommaParser_SumVal |  0,1,2(...)98,99 [289] |  3,203.87 ns |    61.0188 ns |    57.0770 ns |  3,183.66 ns |  1.00 |    0.00 | 0.8354 | 0.0114 |     - |    3944 B |
|           LinqCommaParser_SumVal |  0,1,2(...)98,99 [289] |  4,151.62 ns |    92.5658 ns |    86.5861 ns |  4,136.03 ns |  1.30 |    0.03 | 0.8392 | 0.0076 |     - |    3976 B |
|                                  |                        |              |               |               |              |       |         |        |        |       |           |
| AllocationFreeCommaParser_SumVal | 0,1,2(...)8,999 [3889] | 16,101.32 ns |   315.7897 ns |   432.2565 ns | 16,299.01 ns |  0.48 |    0.03 |      - |      - |     - |         - |
|    TraditionalCommaParser_SumVal | 0,1,2(...)8,999 [3889] | 33,068.29 ns |   656.0960 ns | 1,369.5167 ns | 32,656.81 ns |  1.00 |    0.00 | 8.4229 | 1.0376 |     - |   39944 B |
|           LinqCommaParser_SumVal | 0,1,2(...)8,999 [3889] | 42,705.93 ns | 1,598.8495 ns | 1,641.9007 ns | 41,923.92 ns |  1.27 |    0.07 | 8.4839 | 0.4883 |     - |   39976 B |
