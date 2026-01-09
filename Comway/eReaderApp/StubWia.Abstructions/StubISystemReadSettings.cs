using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemReadSettings :ISystemReadSettings
    {

        public StubISystemReadSettings() { }
        public bool ChecksumOmmission { get; set; }
        public ScoreRange ScoreSetting { get; set; }
        public ScoreAs100 WaferScoreAs100 { get; set; }
        public bool DisableOutputResultString { get; set; }
        public bool DisableOutputResultOKNG { get; set; }
        public bool DisableOutputResultScore { get; set; }
        public bool DisplayChecksumFirstAsAstah { get; set; }
        public int TuneCompleteTimeout { get; set; }
        public int TuneContinueInterval { get; set; }
    }
}
