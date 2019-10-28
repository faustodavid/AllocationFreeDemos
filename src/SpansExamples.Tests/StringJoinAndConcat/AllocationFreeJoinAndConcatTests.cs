using SpansExamples.StringJoinAndConcat;
using Xunit;

namespace SpansExamples.Tests.StringJoinAndConcat
{
    public class AllocationFreeJoinAndConcatTests : StringJoinAndConcatBaseTest
    {
        public override void Join(string[] array, string expectedResult)
        {
            var actualResult = AllocationFree.JoinAndConcatBrackets(array);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}