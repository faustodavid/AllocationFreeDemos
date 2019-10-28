using Xunit;

namespace SpansExamples.Tests.Parser
{
    public abstract class ParserBaseTest
    {
        [InlineData("1,2,3,4,10", 20)]
        [InlineData("1", 1)]
        [InlineData("10,30,5", 45)]
        [InlineData("20,60", 80)]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [Theory]
        public abstract void SumCommaSeparatedValues(string valueToParse, int expectedResult);
    }
}