using System.Text;

namespace SpansExamples.StringJoinAndConcat
{
    public class TraditionalStringBuilder
    {
        private TraditionalStringBuilder()
        {
        }

        public static string JoinAndConcatBrackets(string[] array, int capacity = 0)
        {
            if (array.Length == 0)
            {
                return string.Empty;
            }

            var buffer = capacity == 0 ? new StringBuilder() : new StringBuilder(capacity);

            buffer.Append('[');
            buffer.AppendJoin(',', array);
            buffer.Append(']');

            return buffer.ToString();
        }
    }
}