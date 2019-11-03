using SpansExamples.StringJoinAndConcat;
using Xunit;

namespace SpansExamples.Tests.StringJoinAndConcat
{
    public class TraditionalStringBuilderJoinAndConcatTests : StringJoinAndConcatBaseTest
    {
        public override void Join(string[] array, string expectedResult)
        {
            var actualResult = TraditionalStringBuilder.JoinAndConcatBrackets(array);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}