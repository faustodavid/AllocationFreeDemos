using System;

namespace SpansExamples.StringJoinAndConcat.Benchmarks
{
    public struct MeaningfulStructure
    {
        public string Val1 { get; }
        public string Val2 { get; }
        public string Val3 { get; }
        public string Val4 { get; }
        public string Val5 { get; }
        public string Val6 { get; }
        public string Val7 { get; }
        public string Val8 { get; }

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