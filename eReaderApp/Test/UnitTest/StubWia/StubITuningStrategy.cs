using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubITuningStrategy : ITuningStrategy
    {
        private bool _IsMultiLightTuneForced;
        public bool IsMultiLightTuneForced 
        {
            get => this._IsMultiLightTuneForced;
            set
            {
                this._IsMultiLightTuneForced = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsMultiLightTuneForced)));
            }
        }
        private double _progress = 0.0;
        public double Progress
        {
            get => this._progress;
            private set
            {
                this._progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Progress)));
            }
        }

        private ITuneResult _latestTuningResult ;
        public ITuneResult LatestTuningResult 
        { 
            get => this._latestTuningResult;
            private set
            {
                this._latestTuningResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LatestTuningResult)));
            }
        }

        private string _tuneHistory = "";
        public string TuneHistory
        {
            get => this._tuneHistory;
            private set
            {
                this._tuneHistory = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneHistory)));
            }
        }

        private string _archiveFolderName;
        public string ArchiveFolderName
        {
            get => this._archiveFolderName;
            set
            {
                this._archiveFolderName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ArchiveFolderName)));
            }
        }
        private bool _isArchiveAutoCleanup;
        public bool IsArchiveAutoCleanup
        {
            get => this._isArchiveAutoCleanup;
            set
            {
                this._isArchiveAutoCleanup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsArchiveAutoCleanup)));
            }
        }
        private ScoreMode _scoreType;
        public ScoreMode ScoreType
        {
            get => this._scoreType;
            set
            {
                this._scoreType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScoreType)));
            }
        }
        private ScoreAs100 _waferScoreAs100;
        public ScoreAs100 WaferScoreAs100
        {
            get => this._waferScoreAs100;
            set
            {
                this._waferScoreAs100 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WaferScoreAs100)));
            }
        }

        public event EventHandler TuningPhaseStarted;
        public event EventHandler TuningPhaseCompleted;
        public event EventHandler<IReadOperationStartedEventArgs> ReadOperationStarted;
        public event EventHandler<IReadOperationCompletedEventArgs> ReadOperationCompleted;
        public event EventHandler TuningResultUpdated;
        public event EventHandler BestTuningResultUpdated;
        public event EventHandler<IAcquireImageStartedEventArgs> AcquireImageStarted;
        public event EventHandler<IAcquireImageCompletedEventArgs> AcquireImageCompleted;
        public event EventHandler<ILogMessageEventArgs> LogMessageAvailable;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool RunSequence(IJobConfig conf, CancellationToken token)
        {
            return true;
        }

        public void SetImageSource(IImageSource imageSource)
        {
            
        }
    }
}
