using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubIWiaSystem : IWiaSystem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIWiaSystem() { }
        private ISystemAcqSettings _acquisitionSettings = new StubISystemAcqSettings();
        public ISystemAcqSettings AcquisitionSettings {
            get { return this._acquisitionSettings; }
            private set
            {
                this._acquisitionSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcquisitionSettings)));
            }
        }
        private ISystemSettings _systemSettings = new StubISystemSettings();
        public ISystemSettings SystemSettings {
            get { return this._systemSettings; }
            private set
            {
                this._systemSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SystemSettings)));
            }
        }
        private ISystemGUISettings _gUISettings = new StubISystemGUISettings();
        public ISystemGUISettings GUISettings {
            get { return this._gUISettings; }
            private set
            {
                this._gUISettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GUISettings)));
            }
        }
        private ISystemCommSettings _communicationSettings = new StubISystemCommSettings();
        public ISystemCommSettings CommunicationSettings {
            get { return this._communicationSettings; }
            private set
            {
                this._communicationSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CommunicationSettings)));
            }
        }
        private ISystemReadSettings _readSettings = new StubISystemReadSettings();
        public ISystemReadSettings ReadSettings {
            get { return this._readSettings; }
            private set
            {
                this._readSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadSettings)));
            }
        }
        private ISystemLogSettings _logSettings = new StubISystemLogSettings();
        public ISystemLogSettings LogSettings {
            get { return this._logSettings; }
            private set
            {
                this._logSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogSettings)));
            }
        }
        private IWiaDevice _device = new StubIWiaDevice();
        public IWiaDevice Device {
            get { return this._device; }
            private set
            {
                this._device = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Device)));
            }
        }
        private IWiaCommManager _commManager = new StubIWiaCommManager();
        public IWiaCommManager CommManager {
            get { return this._commManager; }
            private set
            {
                this._commManager = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CommManager)));
            }
        }
        private IJob _job = new StubIJob();
        public IJob Job {
            get { return this._job; }
            private set
            {
                this._job = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Job)));
            }
        }
        private IMaintenanceService _maintenanceServices = new StubIMaintenanceService();
        public IMaintenanceService MaintenanceServices {
            get { return this._maintenanceServices; }
            private set
            {
                this._maintenanceServices = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaintenanceServices)));
            }
        }
        private string _appVersion;
        public string AppVersion {
            get { return this._appVersion; }
            private set
            {
                this._appVersion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AppVersion)));
            }
        }
        private bool _isOnline;
        public bool IsOnline {
            get { return this._isOnline; }
            private set
            {
                this._isOnline = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsOnline)));
            }
        }
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
        private string _activeJobName;
        public string ActiveJobName {
            get => _activeJobName;
            set
            {
                _activeJobName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveJobName)));
            }
        }
        private DateTime _activeJobLoadTime;
        public DateTime ActiveJobLoadTime {
            get => _activeJobLoadTime;
            set
            {
                _activeJobLoadTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveJobLoadTime)));
            }
        }
        private DateTime _bootTime;
        public DateTime BootTime {
            get => _bootTime;
            set
            {
                _bootTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BootTime)));
            }
        }
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
        private bool _isTuning;
        public bool IsTuning {
            get => _isTuning;
            set
            {
                _isTuning = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsTuning)));
            }
        }
        private TuneState _tuneCurrentState;
        public TuneState TuneCurrentState {
            get => _tuneCurrentState;
            set
            {
                _tuneCurrentState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneCurrentState)));
            }
        }
        private int _tuneCurrentSeqNumber;
        public int TuneCurrentSeqNumber {
            get => _tuneCurrentSeqNumber;
            set
            {
                _tuneCurrentSeqNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneCurrentSeqNumber)));
            }
        }
        private int _tuneCurrentConfigNumber;
        public int TuneCurrentConfigNumber {
            get => _tuneCurrentConfigNumber;
            set
            {
                _tuneCurrentConfigNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneCurrentConfigNumber)));
            }
        }
        private IImageSource _imageSource;
        public IImageSource ImageSource {
            get => _imageSource;
            set
            {
                _imageSource = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSource)));
            }
        }

        private IIdReadingService _idReadingService = new StubIIdReadingService();
        public IIdReadingService IdReadingService
        {
            get => _idReadingService;
            private set
            {
                _idReadingService = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IdReadingService)));
            }
        }

        private ITuningService _tuningService = new StubITuningService();
        public ITuningService TuningService
        {
            get => _tuningService;
            private set
            {
                _tuningService = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuningService)));
            }
        }

        private bool _isLiveViewActive = false;
        public bool IsLiveViewActive
        {
            get => _isLiveViewActive;
            private set
            {
                _isLiveViewActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLiveViewActive)));
            }
        }

        private IAcquireResult _latestAcquireResult = new StubIAcquireResult();
        public IAcquireResult LatestAcquireResult
        {
            get => _latestAcquireResult;
            private set
            {
                _latestAcquireResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LatestAcquireResult)));
            }
        }

        private IImage _latestAcquiredImage = new StubIImage();
        public IImage LatestAcquiredImage
        {
            get => _latestAcquiredImage;
            private set
            {
                _latestAcquiredImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LatestAcquiredImage)));
            }
        }

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

        public int TuneStart(int configId, bool isMultiLightTuneForced)
        {
            return 0;
        }

        public void TuneAbort()
        {
            
        }
    }
    public class StubIScreenVisibilityChangeEventArgs : IScreenVisibilityChangeEventArgs
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIScreenVisibilityChangeEventArgs() { }
        private bool _isVisible;
        public bool IsVisible {
            get { return this._isVisible; }
            private set
            {

                this._isVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsVisible)));
            }
        }
        private int _locationX;
        public int LocationX {
            get { return this._locationX; }
            private set
            {
                _locationX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationX)));
            }
        }
        private int _locationY;
        public int LocationY {
            get { return this._locationY; }
            private set
            {
                _locationY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LocationY)));
            }
        }
    }
}
