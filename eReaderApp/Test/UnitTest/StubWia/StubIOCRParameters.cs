using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubIOCRParameters : IOCRParameters
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubIOCRParameters() { }
        //public string CustomFontIDString { get; set; }
        private string _customFontIDString;
        public string CustomFontIDString
        {
            get => _customFontIDString;
            set
            {
                _customFontIDString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CustomFontIDString)));
            }
        }
        //public OCROperationMode Operation { get; set; }
        private OCROperationMode _operation;
        public OCROperationMode Operation
        {
            get => _operation;
            set
            {
                _operation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operation)));
            }
        }
        //public double ConfusionThreshold { get; set; }
        private double _confusionThreshold;
        public double ConfusionThreshold
        {
            get => _confusionThreshold;
            set
            {
                _confusionThreshold = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfusionThreshold)));
            }
        }
        //public bool UseConfusionChecksum { get; set; }
        private bool _useConfusionChecksum;
        public bool UseConfusionChecksum
        {
            get => _useConfusionChecksum;
            set
            {
                _useConfusionChecksum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UseConfusionChecksum)));
            }
        }
        //public PreprocessType Preprocess { get; set; }
        private PreprocessType _preprocess;
        public PreprocessType Preprocess
        {
            get => _preprocess;
            set 
            {
                _preprocess = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Preprocess)));
            }
        }
        //public FilterType StrokeFilter { get; set; }
        private FilterType _strokeFilter;
        public FilterType StrokeFilter
        {
            get => _strokeFilter;
            set
            {
                _strokeFilter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StrokeFilter)));
            }
        }
        //public int StrokeFilterSize { get; set; }
        private int _strokeFilterSize;
        public int StrokeFilterSize
        {
            get => _strokeFilterSize;
            set
            {
                _strokeFilterSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StrokeFilterSize)));
            }
        }
        //public double NominalPitchRatio { get; set; }
        private double _nominalPitchRatio;
        public double NominalPitchRatio
        {
            get => _nominalPitchRatio;
            set
            {
                _nominalPitchRatio = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NominalPitchRatio)));
            }
        }
        //public bool EnableWideRangeCharacter { get; set; }
        private bool _enableWideRangeCharacter;
        public bool EnableWideRangeCharacter
        {
            get => _enableWideRangeCharacter;
            set
            {
                _enableWideRangeCharacter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnableWideRangeCharacter)));
            }
        }
        //public ReadRetryMode ReadingRetry { get; set; }
        private ReadRetryMode _readingRetry;
        public ReadRetryMode ReadingRetry
        {
            get => _readingRetry;
            set
            {
                _readingRetry = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadingRetry)));
            }
        }
        //public ChecksumFirstType CheckSumFirst { get; set; }
        private ChecksumFirstType _checkSumFirst;
        public ChecksumFirstType CheckSumFirst
        {
            get => _checkSumFirst;
            set
            {
                _checkSumFirst = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckSumFirst)));
            }
        }
        //public OCRGridJudgeMode GridJudge { get; set; }
        private OCRGridJudgeMode _gridJudge;
        public OCRGridJudgeMode GridJudge
        {
            get => _gridJudge;
            set
            {
                _gridJudge = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GridJudge)));
            }
        }
        //public double SymbolAccept { get; set; }
        private double _symbolAccept;
        public double SymbolAccept
        {
            get => _symbolAccept;
            set
            {
                _symbolAccept = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SymbolAccept)));
            }
        }
        //public bool SymbolReading { get; set; }
        private bool _symbolReading;
        public bool SymbolReading
        {
            get => _symbolReading;
            set
            {
                _symbolReading = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SymbolReading)));
            }
        }
        //public int CharacterThreshold { get; set; }
        private int _characterThreshold;
        public int CharacterThreshold
        {
            get => _characterThreshold;
            set
            {
                _characterThreshold = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CharacterThreshold)));
            }
        }
        //public int BaseLineError { get; set; }
        private int _baseLineError;
        public int BaseLineError
        {
            get => _baseLineError;
            set
            {
                _baseLineError = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BaseLineError)));
            }
        }
        //public int SpaceError { get; set; }
        private int _spaceError;
        public int SpaceError
        {
            get => _spaceError;
            set
            {
                _spaceError = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpaceError)));
            }
        }
        //public InternalFilterType InternalFilter { get; set; }
        private InternalFilterType _internalFilter;
        public InternalFilterType InternalFilter
        {
            get => _internalFilter;
            set
            {
                _internalFilter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InternalFilter)));
            }
        }
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
