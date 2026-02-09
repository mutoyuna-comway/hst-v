using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
     public class StubIJobConfig : IJobConfig
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIJobConfig() {
            ConfigID = 1;

        }
        
        private int _configID;
        public int ConfigID { 
            get { return this._configID; } 
            private set
            {
                this._configID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfigID)));
            }
        }
        private IJobAcqSettings _acquireSettings = new StubIJobAcqSettings();
        public IJobAcqSettings AcquireSettings {
            get { return this._acquireSettings; }
            private set
            {
                this._acquireSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcquireSettings)));
            }
        }
        private IJobReadSettings _readSettings = new StubIJobReadSettings();
        public IJobReadSettings ReadSettings {
            get { return this._readSettings; }
            private set
            {
                this._readSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadSettings)));
            }
        }
        private IJobTuneSettings _tuneSettings = new StubIJobTuneSettings();
        public IJobTuneSettings TuneSettings {
            get { return this._tuneSettings; }
            private set
            {
                this._tuneSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneSettings)));
            }
        }
        private ITuneResult _tuneLatestResult = new StubITuneResult();
        public ITuneResult TuneLatestResult {
            get { return this._tuneLatestResult; }
            private set
            {
                this._tuneLatestResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneLatestResult)));
            }
        }
        //public bool Enable { get; set; }
        private bool _enable;
        public bool Enable
        {
            get => _enable;
            set
            {
                _enable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Enable)));
            }
        }
        //bool IsReadCompletedEventEnabled { get; set; }
        private bool _isReadCompletedEventEnabled;
        public bool IsReadCompletedEventEnabled
        {
            get => _isReadCompletedEventEnabled;
            set
            {
                _isReadCompletedEventEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsReadCompletedEventEnabled)));
            }
        }
        public event EventHandler<IReadCompletedEventArgs> ReadCompleted;
        public IReadResult RunRead(IImageSource imgSrc, ScoreMode scoreType, ScoreAs100 waferScoreAs100) { return null; }
        public IReadResult RunReadWithParams(IAcquireResult acq, IJobReadSettings readSettings, ScoreMode scoreType, ScoreAs100 waferScoreAs100) { return null; }
        public bool CheckFontIdValidity() { return true; }
        public void SetTuneSettings(IJobTuneSettings tuneSettings) { }
        public void ApplySettings(IJobReadSettings readSettings, IJobAcqSettings acqSettings) { }
        public bool JudgeChecksum(String str) { return true; }
        public void SetLatestReadResult(IReadResult result) { }
        public void ClearLatestReadResult() { }
        public IReadResult GetLatestReadResult() {  return null; }

    }
    public class StubIReadCompletedEventArgs : IReadCompletedEventArgs
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIReadCompletedEventArgs() { }
        private IReadResult _result = new StubIReadResult();
        public IReadResult Result
        {
            get { return this._result; }
            private set
            {
                this._result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
            }
        }
        private IAcquireResult _acqResult = new StubIAcquireResult();
        public IAcquireResult AcqResult
        {
            get { return this._acqResult; }
            private set
            {
                this._acqResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqResult)));
            }
        }
        private string _logIdString;
        public string LogIdString
        {
            get { return this._logIdString; }
            private set
            {
                this._logIdString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogIdString)));
            }
        }       
    }
}
