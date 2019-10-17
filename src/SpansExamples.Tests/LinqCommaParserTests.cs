using SpansExamples.Parsers;
using Xunit;

namespace SpansExamples.Tests
{
    public class LinqCommaParserTests : ParserBaseTest
    {
        public override void SumValBenchmark(string valueToParse, int expectedResult)
        {
            Assert.Equal(expectedResult, LinqCommaParser.SumVal(valueToParse));
        }
    }
}