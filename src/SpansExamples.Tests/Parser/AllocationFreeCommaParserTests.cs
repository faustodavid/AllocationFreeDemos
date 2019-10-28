using SpansExamples.Parsers;
using Xunit;

namespace SpansExamples.Tests.Parser
{
    public class AllocationFreeCommaParserTests : ParserBaseTest
    {
        public override void SumCommaSeparatedValues(string valueToParse, int expectedResult)
        {
            Assert.Equal(expectedResult, AllocationFree.SumCommaSeparatedValues(valueToParse));
        }
    }
}