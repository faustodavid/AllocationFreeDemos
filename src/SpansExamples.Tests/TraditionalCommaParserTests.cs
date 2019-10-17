using SpansExamples.Parsers;
using Xunit;

namespace SpansExamples.Tests
{
    public class TraditionalCommaParserTests : ParserBaseTest
    {
        public override void SumValBenchmark(string valueToParse, int expectedResult)
        {
            Assert.Equal(expectedResult, TraditionalCommaParser.SumVal(valueToParse));
        }
    }
}