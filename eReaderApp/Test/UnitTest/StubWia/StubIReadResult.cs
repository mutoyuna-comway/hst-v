using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubIReadResult : IReadResult
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StubIReadResult() {
            Mark = MarkType.OCR;
            ReadString = "";
            Score = 1;
            MinScore = 1;
            ElapsedTime = 1;
            ConfigID = 1;
            Pass = true;
            IsTimeout = true;
            ConfusionString = "";
            IsCorrectConfChecksum = true;


        }
        private MarkType _mark;
        public MarkType Mark {
            get { return this._mark; }
            private set
            {
                this._mark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mark)));
            }
        }
        private string _readString;
        public string ReadString {
            get { return this._readString; }
            private set
            {
                this._readString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadString)));
            }
        }
        private double _score;
        public double Score {
            get { return this._score; }
            private set
            {
                this._score = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score)));
            }
        }
        private double _minScore;
        public double MinScore {
            get { return this._minScore; }
            private set
            {
                this._minScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinScore)));
            }
        }
        private double _elapsedTime;
        public double ElapsedTime {
            get { return this._elapsedTime; }
            private set
            {
                this._elapsedTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ElapsedTime)));
            }
        }
        private int _configID;
        public int ConfigID
        {
            get { return this._configID; }
            private set
            {
                this._configID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfigID)));
            }
        }
        private IRegion _rOI = new StubIRegion();
        public IRegion ROI {
            get { return this._rOI; }
            private set
            {
                this._rOI = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ROI)));
            }
        }
        private ICharacterSize _charSize = new StubICharacterSize();
        public ICharacterSize CharSize {
            get { return this._charSize; }
            private set
            {
                this._charSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CharSize)));
            }
        }
        private bool _pass;
        public bool Pass {
            get { return this._pass; }
            private set
            {
                this._pass = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pass)));
            }
        }
        private bool _isTimeout;
        public bool IsTimeout {
            get { return this._isTimeout; }
            private set
            {
                this._isTimeout = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTimeout)));
            }
        }
        private string _confusionString;
        public string ConfusionString {
            get { return this._confusionString; }
            private set
            {
                this._confusionString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfusionString)));
            }
        }
        private bool _isCorrectConfChecksum;
        public bool IsCorrectConfChecksum {
            get { return this._isCorrectConfChecksum; }
            private set
            {
                this._isCorrectConfChecksum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCorrectConfChecksum)));
            }
        }
        private IReadOcrResult[] _ocrResults = new[] { new StubIReadOcrResult() };
        public IReadOcrResult[] OcrResults {
            get { return this._ocrResults; }
            private set
            {
                this._ocrResults = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OcrResults)));
            }
        }
        private IJobReadSettings _readSettings;
        public IJobReadSettings ReadSettings {
            get { return this._readSettings; }
            private set
            {
                this._readSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadSettings)));
            }
        }

        public double GetAddedScore(ScoreRange sr) { return 0; }
    }

    public class StubIReadOcrResult : IReadOcrResult
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIReadOcrResult() { }
        private char _character;
        public char Character {
            get { return this._character; }
            private set
            {
                this._character = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Character)));
            }
        }
        private int _value;
        public int Value {
            get { return this._value; }
            private set
            {
                this._value = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
            }
        }
        public double _row;
        public double Row {
            get { return this._row; }
            private set
            {
                this._row = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Row)));
            }
        }
        private double _col;
        public double Col {
            get { return this._col; }
            private set
            {
                this._col = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Col)));
            }
        }
        private bool _passCharTh;
        public bool PassCharTh {
            get { return this._passCharTh; }
            private set
            {
                this._passCharTh = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PassCharTh)));
            }
        }
        private bool _foundChecksumFirst;
        public bool FoundChecksumFirst {
            get { return this._foundChecksumFirst; }
            private set
            {
                this._foundChecksumFirst = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FoundChecksumFirst)));
            }
        }
        private bool _isSymbol;
        public bool IsSymbol {
            get { return this._isSymbol; }
            private set
            {
                this._isSymbol = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSymbol)));
            }
        }
        private bool _isFound;
        public bool IsFound {
            get { return this._isFound; }
            private set
            {
                this._isFound = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFound)));
            }
        }
        private bool _isConfusion;
        public bool IsConfusion {
            get { return this._isConfusion; }
            private set
            {
                this._isConfusion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsConfusion)));
            }
        }
        private int _lSError;
        public int LSError {
            get { return this._lSError; }
            private set
            {
                this._lSError = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LSError)));
            }
        }
    }
}
