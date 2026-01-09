using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
     public class StubIJobConfig : IJobConfig
    {
       
        public StubIJobConfig() { }       
        public int ConfigID { get; }
        public IJobAcqSettings AcquireSettings { get; } = new StubIJobAcqSettings();
        public IJobReadSettings ReadSettings { get; } = new StubIJobReadSettings();
        public IJobTuneSettings TuneSettings { get; } = new StubIJobTuneSettings();
        public ITuneResult TuneLatestResult { get; } = new StubITuneResult();
        public bool Enable { get; set; }
        public bool CheckFontIdValidity() { return true; }
        public void SetTuneSettings(IJobTuneSettings tuneSettings) { }
        public void ApplySettings(IJobReadSettings readSettings, IJobAcqSettings acqSettings) { }
        public void SetLatestReadResult(IReadResult result) { }
        public void ClearLatestReadResult() { }

    }
}
