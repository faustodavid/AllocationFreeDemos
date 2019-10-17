﻿using System.Linq;

namespace SpansExamples.Parsers
{
    public class LinqCommaParser
    {
        private LinqCommaParser()
        {
        }

        public static int SumVal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            return value.Split(",").Sum(v => v == string.Empty ? 0 : int.Parse(v));
        }
    }
}