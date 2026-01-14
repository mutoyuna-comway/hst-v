using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemLogSettings : ISystemLogSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubISystemLogSettings() { }
        //public bool CommandLogOutput { get; set; }
        private bool _commandLogOutput;
        public bool CommandLogOutput
        {
            get => _commandLogOutput;
            set
            {
                _commandLogOutput = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CommandLogOutput)));
            }
        }
        //public ILumpLogOutput LogOutput { get; set; } = new StubILumpLogOutput();
        private ILumpLogOutput _logOutput = new StubILumpLogOutput();
        public ILumpLogOutput LogOutput
        {
            get => _logOutput;
            set
            {
                _logOutput = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogOutput)));
            }
        }
        //public int LogUpdateCount { get; set; }
        private int _logUpdateCount;
        public int LogUpdateCount
        {
            get => _logUpdateCount;
            set
            {
                _logUpdateCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogUpdateCount)));
            }
        }
        //public IImageSaveSettings ImgSaveSetting { get; set; } = new StubIImageSaveSettings();
        private IImageSaveSettings _imgSaveSetting = new StubIImageSaveSettings();
        public IImageSaveSettings ImgSaveSetting
        {
            get => _imgSaveSetting;
            set
            {
                _imgSaveSetting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImgSaveSetting)));
            }
        }
        //public bool AppCameraLogEnabled { get; set; }
        private bool _appCameraLogEnabled;
        public bool AppCameraLogEnabled
        {
            get => _appCameraLogEnabled;
            set
            {
                _appCameraLogEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AppCameraLogEnabled)));
            }
        }
        //public bool AppStartupLogEnabled { get; set; }
        private bool _appStartupLogEnabled;
        public bool AppStartupLogEnabled
        {
            get => _appStartupLogEnabled;
            set
            {
                _appStartupLogEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AppStartupLogEnabled)));
            }
        }
        //public ParamsBackupModeConstants ParamsBackupMode { get; set; }
        private ParamsBackupModeConstants _paramsBackupMode;
        public ParamsBackupModeConstants ParamsBackupMode
        {
            get => _paramsBackupMode;
            set
            {
                _paramsBackupMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ParamsBackupMode)));
            }
        }
        //public ReadParamLogConstants ReadParamLog { get; set; }
        private ReadParamLogConstants _readParamLog;
        public ReadParamLogConstants ReadParamLog
        {
            get => _readParamLog;
            set
            {
                _readParamLog = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadParamLog)));
            }
        }
        //public int TuneAcceptImageSaveNum { get; set; }
        private int _tuneAcceptImageSaveNum;
        public int TuneAcceptImageSaveNum
        {
            get => _tuneAcceptImageSaveNum;
            set
            {
                _tuneAcceptImageSaveNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneAcceptImageSaveNum)));
            }
        }
        //public bool TuneDetailLogOutput { get; set; }
        private bool _tuneDetailLogOutput;
        public bool TuneDetailLogOutput
        {
            get => _tuneDetailLogOutput;
            set
            {
                _tuneDetailLogOutput = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneDetailLogOutput)));
            }
        }
        //public bool TuneDetailLogSortEnabled { get; set; }
        private bool _tuneDetailLogSortEnabled;
        public bool TuneDetailLogSortEnabled
        {
            get => _tuneDetailLogSortEnabled;
            set
            {
                _tuneDetailLogSortEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneDetailLogSortEnabled)));
            }
        }
        //public int TuneDetailLogMaxNum { get; set; }
        private int _tuneDetailLogMaxNum;
        public int TuneDetailLogMaxNum
        {
            get => _tuneDetailLogMaxNum;
            set
            {
                _tuneDetailLogMaxNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneDetailLogSortEnabled)));
            }
        }
    }
}
