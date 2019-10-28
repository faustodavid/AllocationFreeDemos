namespace SpansExamples.Parsers
{
    public class TraditionalForeach
    {
        private TraditionalForeach()
        {
        }

        public static int SumCommaSeparatedValues(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            var splitValues = value.Split(",");
            var result = 0;
            foreach (var splitValue in splitValues)
            {
                result += int.Parse(splitValue);
            }

            return result;
        }
    }
}