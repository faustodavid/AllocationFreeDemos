using SpansExamples.Parsers;
using Xunit;

namespace SpansExamples.Tests.Parser
{
    public class TraditionalCommaParserTests : ParserBaseTest
    {
        public override void SumCommaSeparatedValues(string valueToParse, int expectedResult)
        {
            Assert.Equal(expectedResult, TraditionalForeach.SumCommaSeparatedValues(valueToParse));
        }
    }
}