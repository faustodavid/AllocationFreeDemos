using Xunit;

namespace SpansExamples.Tests.StringJoinAndConcat
{
    public abstract class StringJoinAndConcatBaseTest
    {
        [InlineData(new[] { "1" }, "[1]")]
        [InlineData(new[] { "1", "2", "12" }, "[1,2,12]")]
        [InlineData(new[] { "hello", "world", "!" }, "[hello,world,!]")]
        [Theory]
        public abstract void Join(string[] array, string expectedResult);
    }
}
