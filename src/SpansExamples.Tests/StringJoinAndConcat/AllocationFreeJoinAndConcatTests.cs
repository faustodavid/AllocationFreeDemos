using System;
using SpansExamples.StringJoinAndConcat;
using Xunit;

namespace SpansExamples.Tests.StringJoinAndConcat
{
    public class AllocationFreeJoinAndConcatTests : StringJoinAndConcatBaseTest
    {
        public override void Join(string[] array, string expectedResult)
        {
            var length = AllocationFree.CalculateRequiredLength(array);
            Span<char> buffer = stackalloc char[length];

            AllocationFree.JoinAndConcatBrackets(array, ref buffer);

            Assert.Equal(expectedResult, buffer.ToString());
        }
    }
}