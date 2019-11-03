using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using SpansExamples.StringJoinAndConcat;
using SpansExamples.StringJoinAndConcat.Benchmarks;
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

    public class OverheadFreeJoinAndConcatStringBuilderTests : StringJoinAndConcatBaseTest
    {
        public override void Join(string[] array, string expectedResult)
        {
            var actualResult = OverheadFree.JoinAndConcatBrackets_StringBuilder(array);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}