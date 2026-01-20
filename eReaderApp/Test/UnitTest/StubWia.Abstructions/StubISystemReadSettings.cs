using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemReadSettings :ISystemReadSettings
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubISystemReadSettings() { }
        //public bool ChecksumOmmission { get; set; }
        private bool _checksumOmmission;
        public bool ChecksumOmmission
        {
            get => _checksumOmmission;
            set
            {
                _checksumOmmission = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChecksumOmmission)));
            }
        }
        //public ScoreRange ScoreSetting { get; set; }
        private ScoreRange _scoreSetting;
        public ScoreRange ScoreSetting
        {
            get => _scoreSetting;
            set
            {
                _scoreSetting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScoreSetting)));
            }
        }
        //public ScoreAs100 WaferScoreAs100 { get; set; }
        private ScoreAs100 _waferScoreAs100;
        public ScoreAs100 WaferScoreAs100
        {
            get => _waferScoreAs100;
            set
            {
                _waferScoreAs100 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WaferScoreAs100)));
            }
        }
        //public bool DisableOutputResultString { get; set; }
        private bool _disableOutputResultString;
        public bool DisableOutputResultString
        {
            get => _disableOutputResultString;
            set
            {
                _disableOutputResultString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisableOutputResultString)));
            }
        }
        //public bool DisableOutputResultOKNG { get; set; }
        private bool _disableOutputResultOKNG;
        public bool DisableOutputResultOKNG
        {
            get => _disableOutputResultOKNG;
            set
            {
                _disableOutputResultOKNG = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisableOutputResultOKNG)));
            }
        }
        //public bool DisableOutputResultScore { get; set; }
        private bool _disableOutputResultScore;
        public bool DisableOutputResultScore
        {
            get => _disableOutputResultScore;
            set
            {
                _disableOutputResultScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisableOutputResultScore)));
            }
        }
        //public bool DisplayChecksumFirstAsAstah { get; set; }
        private bool _displayChecksumFirstAsAstah;
        public bool DisplayChecksumFirstAsAstah
        {
            get => _displayChecksumFirstAsAstah;
            set
            {
                _displayChecksumFirstAsAstah = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayChecksumFirstAsAstah)));
            }
        }
        //public int TuneCompleteTimeout { get; set; }
        private int _tuneCompleteTimeout;
        public int TuneCompleteTimeout
        {
            get => _tuneCompleteTimeout;
            set
            {
                _tuneCompleteTimeout = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneCompleteTimeout)));
            }
        }
        //public int TuneContinueInterval { get; set; }
        private int _tuneContinueInterval;
        public int TuneContinueInterval
        {
            get => _tuneContinueInterval;
            set
            {
                _tuneContinueInterval = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneContinueInterval)));
            }
        }
    }
}
