using System;

namespace SpansExamples.Parsers
{
    public class AllocationFreeCommaParser
    {
        private AllocationFreeCommaParser()
        {
        }

        /// <summary>
        ///     Returns the sum of the comma separated values in a given string
        ///     Example: "2,4,5" returns 11
        ///     This method is not production ready, it is meant for learning purposes.
        /// </summary>
        /// <param name="content">Comma separated integers</param>
        /// <returns>Sum of all comma separated integers</returns>
        public static int SumVal(ReadOnlySpan<char> content)
        {
            if (content == null || content.Length == 0)
            {
                return 0;
            }

            // Indicates the position of the next comma left to right
            var currentCommaIndex = content.IndexOf(',');
            var result = 0;

            // CurrentCommaIndex can be -1 if nothing was found or any index value until
            // the (length - 1) of the content
            // Length is 1 base and index is 0 base
            while (currentCommaIndex > -1)
            {
                // Parse the view from 0 to the comma and add it to results
                // ReadOnlySpan Slice method return a view of the requested segment
                // the return type is also ReadOnlySpan, meaning 0 allocation
                result += int.Parse(content.Slice(0, currentCommaIndex));

                // Exclude the previous processed value from the content
                content = content.Slice(currentCommaIndex + 1);

                // Gets new comma index for the new view
                currentCommaIndex = content.IndexOf(',');
            }

            // add the reminding value from the content to result
            return result + int.Parse(content.Slice(currentCommaIndex + 1));
        }
    }
}