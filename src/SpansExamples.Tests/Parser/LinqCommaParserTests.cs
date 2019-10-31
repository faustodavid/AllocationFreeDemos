using SpansExamples.Parsers;
using Xunit;

namespace SpansExamples.Tests.Parser
{
    public class LinqCommaParserTests : ParserBaseTest
    {
        public override void SumCommaSeparatedValues(string valueToParse, int expectedResult)
        {
            Assert.Equal(expectedResult, Linq.SumCommaSeparatedValues(valueToParse));
        }
    }
}