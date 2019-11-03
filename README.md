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

```
## Join and concat brackets
Receive an array of string and perform a join with commas and concat brackets at the beginning and end.

Equivalent to: `string.Concat('[', string.Join(',', array), ']')`


### Benchmarks

```
|                                                     Method |         content |    n |          Mean |        Error |       StdDev |        Median | Ratio | RatioSD |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|----------------------------------------------------------- |---------------- |----- |--------------:|-------------:|-------------:|--------------:|------:|--------:|---------:|---------:|---------:|----------:|
|                       AllocationFree_JoinAndConcatBrackets | System.String[] |    1 |      46.86 ns |     0.951 ns |     1.665 ns |      45.98 ns |  0.52 |    0.01 |        - |        - |        - |         - |
|                         OverheadFree_JoinAndConcatBrackets | System.String[] |    1 |      63.65 ns |     1.292 ns |     1.327 ns |      63.45 ns |  0.67 |    0.02 |   0.1632 |        - |        - |     768 B |
|                          Traditional_JoinAndConcatBrackets | System.String[] |    1 |      94.35 ns |     0.910 ns |     0.851 ns |      94.11 ns |  1.00 |    0.00 |   0.1836 |        - |        - |     864 B |
| StringBuilder_WithInitialCapacitySet_JoinAndConcatBrackets | System.String[] |    1 |     139.53 ns |     1.670 ns |     1.480 ns |     139.26 ns |  1.48 |    0.02 |   0.3364 |   0.0010 |        - |    1584 B |
|                        StringBuilder_JoinAndConcatBrackets | System.String[] |    1 |     221.61 ns |     1.510 ns |     1.412 ns |     221.34 ns |  2.35 |    0.03 |   0.5252 |   0.0033 |        - |    2472 B |
|                                                            |                 |      |               |              |              |               |       |         |          |          |          |           |
|                       AllocationFree_JoinAndConcatBrackets | System.String[] |   10 |     198.70 ns |     0.625 ns |     0.585 ns |     198.44 ns |  0.16 |    0.00 |        - |        - |        - |         - |
|                         OverheadFree_JoinAndConcatBrackets | System.String[] |   10 |     617.46 ns |    11.804 ns |    12.630 ns |     618.58 ns |  0.50 |    0.01 |   1.5764 |        - |        - |    7424 B |
|                          Traditional_JoinAndConcatBrackets | System.String[] |   10 |   1,241.93 ns |     8.232 ns |     7.701 ns |   1,241.73 ns |  1.00 |    0.00 |   3.1738 |        - |        - |   14944 B |
| StringBuilder_WithInitialCapacitySet_JoinAndConcatBrackets | System.String[] |   10 |   1,281.34 ns |    18.210 ns |    15.206 ns |   1,281.49 ns |  1.03 |    0.01 |   3.1643 |   0.0839 |        - |   14904 B |
|                        StringBuilder_JoinAndConcatBrackets | System.String[] |   10 |   1,688.54 ns |    28.273 ns |    26.447 ns |   1,681.02 ns |  1.36 |    0.02 |   4.1828 |   0.1812 |        - |   19704 B |
|                                                            |                 |      |               |              |              |               |       |         |          |          |          |           |
|                       AllocationFree_JoinAndConcatBrackets | System.String[] |  100 |   2,519.36 ns |    17.756 ns |    15.740 ns |   2,517.83 ns |  0.21 |    0.01 |        - |        - |        - |         - |
|                         OverheadFree_JoinAndConcatBrackets | System.String[] |  100 |   5,768.20 ns |    68.021 ns |    63.627 ns |   5,764.48 ns |  0.47 |    0.03 |  15.6174 |        - |        - |   74024 B |
|                          Traditional_JoinAndConcatBrackets | System.String[] |  100 |  11,673.02 ns |   315.953 ns |   593.436 ns |  11,485.74 ns |  1.00 |    0.00 |  31.2347 |        - |        - |  148144 B |
| StringBuilder_WithInitialCapacitySet_JoinAndConcatBrackets | System.String[] |  100 |  12,610.42 ns |   111.927 ns |   104.696 ns |  12,595.62 ns |  1.03 |    0.06 |  31.2347 |   6.2408 |        - |  148104 B |
|                        StringBuilder_JoinAndConcatBrackets | System.String[] |  100 |  14,522.56 ns |   250.203 ns |   208.930 ns |  14,591.18 ns |  1.19 |    0.08 |  34.4696 |   8.6060 |        - |  162504 B |
|                                                            |                 |      |               |              |              |               |       |         |          |          |          |           |
|                       AllocationFree_JoinAndConcatBrackets | System.String[] | 1000 |  29,771.21 ns |   407.182 ns |   380.879 ns |  29,927.12 ns |  0.12 |    0.01 |        - |        - |        - |         - |
| StringBuilder_WithInitialCapacitySet_JoinAndConcatBrackets | System.String[] | 1000 | 236,090.88 ns | 4,675.611 ns | 7,140.152 ns | 235,344.82 ns |  0.95 |    0.05 | 257.3242 | 256.8359 | 256.8359 | 1480836 B |
|                          Traditional_JoinAndConcatBrackets | System.String[] | 1000 | 248,251.62 ns | 4,935.587 ns | 7,828.364 ns | 248,191.50 ns |  1.00 |    0.00 | 240.7227 | 240.2344 | 240.2344 | 1481994 B |
|                         OverheadFree_JoinAndConcatBrackets | System.String[] | 1000 | 281,314.26 ns | 1,195.323 ns | 1,118.106 ns | 281,088.67 ns |  1.14 |    0.05 | 199.7070 | 199.7070 | 199.7070 |  740025 B |
|                        StringBuilder_JoinAndConcatBrackets | System.String[] | 1000 | 413,722.76 ns | 3,862.279 ns | 3,225.178 ns | 414,828.96 ns |  1.67 |    0.07 | 199.7070 | 199.7070 | 199.7070 | 1487456 B |
