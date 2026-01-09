using System;
using System.Collections.Generic;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIOCRParameters : IOCRParameters
    {
       
        public StubIOCRParameters() { }
        public string CustomFontIDString { get; set; }
        public OCROperationMode Operation { get; set; }
        public double ConfusionThreshold { get; set; }
        public bool UseConfusionChecksum { get; set; }
        public PreprocessType Preprocess { get; set; }
        public FilterType StrokeFilter { get; set; }
        public int StrokeFilterSize { get; set; }
        public double NominalPitchRatio { get; set; }
        public bool EnableWideRangeCharacter { get; set; }
        public ReadRetryMode ReadingRetry { get; set; }
        public ChecksumFirstType CheckSumFirst { get; set; }
        public OCRGridJudgeMode GridJudge { get; set; }
        public double SymbolAccept { get; set; }
        public bool SymbolReading { get; set; }
        public int CharacterThreshold { get; set; }
        public int BaseLineError { get; set; }
        public int SpaceError { get; set; }
        public InternalFilterType InternalFilter { get; set; }
        public void CopyFrom(IOCRParameters src) {
            this.CustomFontIDString = src.CustomFontIDString;
            this.Operation = src.Operation;
            this.ConfusionThreshold = src.ConfusionThreshold;
            this.UseConfusionChecksum = src.UseConfusionChecksum;
            this.Preprocess = src.Preprocess;
            this.StrokeFilter = src.StrokeFilter;
            this.StrokeFilterSize = src.StrokeFilterSize;
            this.NominalPitchRatio = src.NominalPitchRatio;
            this.EnableWideRangeCharacter = src.EnableWideRangeCharacter;
            this.ReadingRetry = src.ReadingRetry;
            this.CheckSumFirst = src.CheckSumFirst;
            this.GridJudge = src.GridJudge;
            this.SymbolAccept = src.SymbolAccept;
            this.SymbolReading = src.SymbolReading;
            this.CharacterThreshold = src.CharacterThreshold;
            this.BaseLineError = src.BaseLineError;
            this.SpaceError = src.SpaceError;
            this.InternalFilter = src.InternalFilter;
        }
    }
}
