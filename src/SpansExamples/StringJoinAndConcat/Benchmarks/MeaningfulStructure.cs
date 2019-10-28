using System;

namespace SpansExamples.StringJoinAndConcat
{
    public readonly struct MeaningfulStructure
    {
        public readonly string Val1;
        public readonly string Val2;
        public readonly string Val3;
        public readonly string Val4;
        public readonly string Val5;
        public readonly string Val6;
        public readonly string Val7;
        public readonly string Val8;

        public MeaningfulStructure(string val1, string val2, string val3, string val4, string val5,
                                   string val6, string val7, string val8)
        {
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
            Val4 = val4;
            Val5 = val5;
            Val6 = val6;
            Val7 = val7;
            Val8 = val8;
        }

        public static MeaningfulStructure CreateStub()
        {
            return new MeaningfulStructure(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString());
        }
    }
}