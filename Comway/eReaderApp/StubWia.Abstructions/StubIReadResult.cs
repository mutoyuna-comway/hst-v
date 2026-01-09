using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIReadResult : IReadResult
    {

        public StubIReadResult() { }
        public MarkType Mark { get; }
        public string ReadString { get; }
        public double Score { get; }
        public double MinScore { get; }
        public double ElapsedTime { get; }
        public int ConfigID { get; }
        public IRegion ROI { get; }
        public ICharacterSize CharSize { get; }
        public bool Pass { get; }
        public bool IsTimeout { get; }
        public string ConfusionString { get; }
        public bool IsCorrectConfChecksum { get; }
        public IReadOcrResult[] OcrResults { get; }
        public double GetAddedScore(ScoreRange sr) { return 0; }
    }

    public class StubIReadOcrResult : IReadOcrResult
    {
        public StubIReadOcrResult() { }
        public char Character { get; }
        public int Value { get; }
        public double Row { get; }
        public double Col { get; }
        public bool PassCharTh { get; }
        public bool FoundChecksumFirst { get; }
        public bool IsSymbol { get; }
        public bool IsFound { get; }
        public bool IsConfusion { get; }
        public int LSError { get; }
    }
}
