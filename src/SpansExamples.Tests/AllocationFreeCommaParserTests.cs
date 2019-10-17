using SpansExamples.Parsers;
using Xunit;

namespace SpansExamples.Tests
{
    public class AllocationFreeCommaParserTests : ParserBaseTest
    {
        public override void SumValBenchmark(string valueToParse, int expectedResult)
        {
            Assert.Equal(expectedResult, AllocationFreeCommaParser.SumVal(valueToParse));
        }
    }
}