using System;

namespace SpansExamples.StringJoinAndConcat
{
    public class OverheadFree
    {
        private OverheadFree()
        {
        }

        /// <summary>
        ///     Equivalent to string.Concat('[', string.Join(',', array), ']')
        ///     But without overhead
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string JoinAndConcatBrackets(string[] array)
        {
            if (array.Length == 0)
            {
                return string.Empty;
            }

            // is required to know in front the length of the string that we want to create
            var resultLength = 0;

            for (var i = 0; i < array.Length; i++)
            {
                // sum of the length of all strings plus the comma
                // plus one extra in the last iteration
                resultLength += array[i].Length + 1;
            }

            // plus one for the last bracket
            resultLength++;

            // creates a new string with a specific length and initializes it
            // after creation by using the specified callback.
            return string.Create(resultLength, array, (outChars, inArray) =>
            {
                outChars[0] = '[';

                var position = 0;
                for (var i = 0; i < inArray.Length; i++)
                {
                    position++;
                    ReadOnlySpan<char> current = inArray[i];
                    current.CopyTo(outChars.Slice(position));
                    position += current.Length;
                    outChars[position] = ',';
                }

                outChars[position] = ']';
            });
        }
    }
}