using SpansExamples.StringJoinAndConcat;
using Xunit;

namespace SpansExamples.Tests.StringJoinAndConcat
{
    public class TraditionalJoinAndConcatTests : StringJoinAndConcatBaseTest
    {
        public override void Join(string[] array, string expectedResult)
        {
            var actualResult = Traditional.JoinAndConcatBrackets(array);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}