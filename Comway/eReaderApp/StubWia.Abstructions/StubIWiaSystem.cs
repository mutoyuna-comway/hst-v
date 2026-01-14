using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIWiaSystem : IWiaSystem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIWiaSystem() { }
        public ISystemAcqSettings AcquisitionSettings { get; } = new StubISystemAcqSettings();
        public ISystemSettings SystemSettings { get; } = new StubISystemSettings();
        public ISystemGUISettings GUISettings { get; } = new StubISystemGUISettings();
        public ISystemCommSettings CommunicationSettings { get; } = new StubISystemCommSettings();
        public ISystemReadSettings ReadSettings { get; } = new StubISystemReadSettings();
        public ISystemLogSettings LogSettings { get; } = new StubISystemLogSettings();
        public IWiaDevice Device { get; } = new StubIWiaDevice();
        public IWiaCommManager CommManager { get; } = new StubIWiaCommManager();
        public IJob Job { get; } = new StubIJob();
        public IMaintenanceService MaintenanceServices { get; } = new StubIMaintenanceService();
        public string AppVersion { get; }
        public bool IsOnline { get; }
        //public bool IsScreenLocked { get; set; }
        private bool _isScreenLocked;
        public bool IsScreenLocked
        {
            get => _isScreenLocked;
            set
            {
                _isScreenLocked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsScreenLocked)));
            }
        }
        //public bool IsAcquireDisabled { get; set; }
        private bool _isAcquireDisabled;
        public bool IsAcquireDisabled
        {
            get => _isAcquireDisabled;
            set
            {
                _isAcquireDisabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAcquireDisabled)));
            }
        }
        public string ActiveJobName { get; }
        public DateTime ActiveJobLoadTime { get; }
        public DateTime BootTime { get; }
        public event EventHandler CloseApplicationRequested;
        public event EventHandler<IScreenVisibilityChangeEventArgs> ScreenVisibilityChangeRequested;
        public event EventHandler LiveViewStarted;
        public event EventHandler LiveViewStopped;
        public event EventHandler AcquireImageAvailable;
        public event EventHandler ReadResultAvailable;
        public void ApplicationExit(int waitTime) { }
        public string GetJobFolder() { return ""; }
        public string GetDeviceFolder() { return ""; }
        public void WriteCommandLogException(Exception exp, string msg = "") { }
        public void SetScreenVisibility(bool visible, int x, int y) { }
        public bool LoadJobFile(String fileName) { return true; }
        public bool SaveJobFile(String fileName) { return true; }
        public bool LoadBitmapFile(String fileName) { return true; }
        public void GoOnline() { }
        public void GoOffline() { }
        public int GetStatsResultsCount() { return 0; }
        public int GetStatsResultsPassNum(int index) { return 0; }
        public int GetStatsResultsFailNum(int index) { return 0; }
        public double GetStatsResultsAvgScore(int index) { return 0; }
        public bool GetConfigNumPassed(int configID, string jobFileName, out int num) { num = 0; return true; }
        public bool GetConfigNumFailed(int configID, string jobFileName, out int num) { num = 0; return true; }
        public bool GetConfigAvgScore(int configID, string jobFileName, out int score) { score = 0; return true; }
        public bool FindJobFilePath(String dispName, out String filePath) { filePath = ""; return true; }
        public int GetAllNumPassed(int configID) { return 0; }
        public int GetAllNumFailed(int configID) { return 0; }
        public int GetAllAverageScore(int configID) { return 0; }
        public void AllStatsClear() { }
        public IRecogCondition CreateRecogCond() { return null; }
        public ICameraInfo GetCamInfo() { return null; }
        public void StartLiveView() { }
        public void StopLiveView() { }
        public int LastBestTarget() { return 0; }
        public void ClearTuneResult() { }
        public bool IsTuning { get; }
        public TuneState TuneCurrentState { get; }
        public int TuneCurrentSeqNumber { get; }
        public int TuneCurrentConfigNumber { get; }

        public IImageSource ImageSource { get; }

        public bool ReadCommandSync(bool withRetry, int timeOut, ref int lastReadConfig) { return true; }
        public int TuneStart(bool isCommand, int tuningConf) { return 0; }
        public bool TuneResultJudge() { return true; }
        public void TuneCancel(bool isCommand, bool cancelFlag) { }
        public bool JudgeChecksum(String str, ChecksumType chk) { return true; }
        public int AddChecksumScore(double score, bool pass, ScoreRange range, IJobReadSettings prm) { return 0; }
        public bool AcquireImage(int config) { return true; }
        public bool ReadOnceCommandSync(int configID, bool withRetry, bool byCommand, int timeOut) { return true; }
        public int ReadRetry(int configID, int lightRange, int LightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, out IReadResult result)
        { result = null; return 0; }
        public IReadResult GetReadBestResult(int configID) { return null; }

        public int AddChecksumScore(double score, bool pass, IJobReadSettings readSettings)
        {
            return 1;
        }
    }
    public class StubIScreenVisibilityChangeEventArgs : IScreenVisibilityChangeEventArgs
    {
        public StubIScreenVisibilityChangeEventArgs() { }
        public bool IsVisible { get; }
        public int LocationX { get; }
        public int LocationY { get; }
    }
}
