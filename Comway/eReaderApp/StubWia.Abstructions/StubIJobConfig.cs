using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
     public class StubIJobConfig : IJobConfig
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIJobConfig() {
            ConfigID = 1;
        }       
        public int ConfigID { get; }
        public IJobAcqSettings AcquireSettings { get; } = new StubIJobAcqSettings();
        public IJobReadSettings ReadSettings { get; } = new StubIJobReadSettings();
        public IJobTuneSettings TuneSettings { get; } = new StubIJobTuneSettings();
        public ITuneResult TuneLatestResult { get; } = new StubITuneResult();
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
}
