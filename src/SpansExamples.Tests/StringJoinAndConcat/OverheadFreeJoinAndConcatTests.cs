using SpansExamples.StringJoinAndConcat;
using Xunit;

namespace SpansExamples.Tests.StringJoinAndConcat
{
    public class OverheadFreeJoinAndConcatTests : StringJoinAndConcatBaseTest
    {
        public override void Join(string[] array, string expectedResult)
        {
            var actualResult = OverheadFree.JoinAndConcatBrackets(array);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}