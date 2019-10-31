using System;

namespace SpansExamples.StringJoinAndConcat
{
    public class AllocationFree
    {
        public static int CalculateRequiredLength(string[] array)
        {
            if (array.Length == 0)
            {
                return 0;
            }

            // is required to know in front the length of the string that we want to create
            var length = 0;

            for (var i = 0; i < array.Length; i++)
            {
                // sum of the length of all strings plus the comma
                // plus one extra in the last iteration
                length += array[i].Length + 1;
            }

            // plus one for the last bracket
            return length + 1;
        }

        public static void JoinAndConcatBrackets(string[] array, ref Span<char> buffer)
        {
            buffer[0] = '[';
            var position = 0;

            for (var i = 0; i < array.Length; i++)
            {
                position++;
                ReadOnlySpan<char> current = array[i];
                current.CopyTo(buffer.Slice(position));
                position += current.Length;
                buffer[position] = ',';
            }

            buffer[position] = ']';
        }
    }
}