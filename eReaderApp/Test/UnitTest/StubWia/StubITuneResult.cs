using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubITuneResult : ITuneResult
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubITuneResult() { }
        private MarkType _mark;
        public MarkType Mark
        {
            get { return this._mark; }
            private set
            {
                this._mark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mark)));
            }
        }
        private double _progress;
        public double Progress {
            get { return this._progress; }
            private set
            {
                this._progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }
        private int _numRead;
        public int NumRead {
            get { return this._numRead; }
            private set
            {
                this._numRead = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumRead)));
            }
        }
        private bool _currentPassed;
        public bool CurrentPassed {
            get { return this._currentPassed; }
            private set
            {
                this._currentPassed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPassed)));
            }
        }
        private string _currentString;
        public string CurrentString {
            get { return this._currentString; }
            private set
            {
                this._currentString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentString)));
            }
        }
        private double _currentScore;
        public double CurrentScore {
            get { return this._currentScore; }
            private set
            {
                this._currentScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentScore)));
            }
        }
        private bool _bestPassed;
        public bool BestPassed {
            get { return this._bestPassed; }
            private set
            {
                this._bestPassed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestPassed)));
            }
        }
        private string _bestString;
        public string BestString {
            get { return this._bestString; }
            private set
            {
                this._bestString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestString)));
            }
        }
        private double _bestScore;
        public double BestScore {
            get { return this._bestScore; }
            private set
            {
                this._bestScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestScore)));
            }
        }
        private int _numTunePassed;
        public int NumTunePassed {
            get { return this._numTunePassed; }
            private set
            {
                this._numTunePassed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumTunePassed)));
            }
        }
        private int _numTuneFailed;
        public int NumTuneFailed {
            get { return this._numTuneFailed; }
            private set
            {
                this._numTuneFailed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumTuneFailed)));
            }
        }
        private double _currentMinimumScore;
        public double CurrentMinimumScore {
            get { return this._currentMinimumScore; }
            private set
            {
                this._currentMinimumScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentMinimumScore)));
            }
        }
        private double _bestMinimumScore;
        public double BestMinimumScore {
            get { return this._bestMinimumScore; }
            private set
            {
                this._bestMinimumScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestMinimumScore)));
            }
        }
        private IJobReadSettings _bestRead = new StubIJobReadSettings();
        public IJobReadSettings BestRead {
            get { return this._bestRead; }
            private set
            {
                this._bestRead = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestRead)));
            }
        }

        private IJobAcqSettings _acqSettings ;
        public IJobAcqSettings AcqSettings
        {
            get { return this._acqSettings; }
            private set
            {
                this._acqSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqSettings)));
            }
        }

        private IJobReadSettings _readSettings;
        public IJobReadSettings ReadSettings
        {
            get { return this._readSettings; }
            private set
            {
                this._readSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadSettings)));
            }
        }
        private IJobAcqSettings _bestAcqSettings ;
        public IJobAcqSettings BestAcqSettings
        {
            get { return this._bestAcqSettings; }
            private set
            {
                this._bestAcqSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestAcqSettings)));
            }
        }
        private IJobReadSettings _bestReadSettings;
        public IJobReadSettings BestReadSettings
        {
            get { return this._bestReadSettings; }
            private set
            {
                this._bestReadSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestReadSettings)));
            }
        }

        private IImage _bestPassedImage;
        public IImage BestPassedImage
        {
            get { return this._bestPassedImage; }
            private set
            {
                this._bestPassedImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestPassedImage)));
            }
        }

        private int _BestRecordNumber = 0;
        public int BestRecordNumber
        {
            get { return this._BestRecordNumber; }
            private set
            {
                this._BestRecordNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BestRecordNumber)));
            }
        }

        public string GetCurrentString(int fieldStrNum) { return ""; }
        public string GetBestString(int fieldStrNum) { return ""; }

        public ITuneResult Clone()
        {
            throw new NotImplementedException();
        }
    }
}
