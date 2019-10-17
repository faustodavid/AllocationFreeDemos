namespace SpansExamples.Parsers
{
    public class TraditionalCommaParser
    {
        private TraditionalCommaParser()
        {
        }

        public static int SumVal(string value)
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