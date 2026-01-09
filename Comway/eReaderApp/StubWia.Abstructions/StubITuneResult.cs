using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubITuneResult : ITuneResult
    {

        public StubITuneResult() { }
        public MarkType Mark { get; }
        public double Progress { get; }
        public int NumRead { get; }
        public bool CurrentPassed { get; }
        public string CurrentString { get; }
        public double CurrentScore { get; }
        public bool BestPassed { get; }
        public string BestString { get; }
        public double BestScore { get; }
        public int NumTunePassed { get; }
        public int NumTuneFailed { get; }
        public double CurrentMinimumScore { get; }
        public double BestMinimumScore { get; }
        public IJobReadSettings BestRead { get; } = new StubIJobReadSettings();
        public string GetCurrentString(int fieldStrNum) { return ""; }
        public string GetBestString(int fieldStrNum) { return ""; }

    }
}
