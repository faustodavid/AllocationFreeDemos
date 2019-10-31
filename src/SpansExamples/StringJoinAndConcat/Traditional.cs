namespace SpansExamples.StringJoinAndConcat
{
    public class Traditional
    {
        private Traditional()
        {
        }

        public static string JoinAndConcatBrackets(string[] array)
        {
            return string.Concat('[', string.Join(',', array), ']');
        }
    }
}