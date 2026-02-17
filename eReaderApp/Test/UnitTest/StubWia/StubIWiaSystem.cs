using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Wia.Abstractions;

namespace StubWia
{
    public class StubIWiaSystem : IWiaSystem
    {
        // プロパティ変更通知イベント
        public event PropertyChangedEventHandler PropertyChanged;

        public StubIWiaSystem() { }

        /// <summary>
        /// プロパティ値をセットし、変更があった場合に通知を行うヘルパーメソッド
        /// </summary>
        protected bool SetProperty<T>(ref T storage, T value, string propertyName)
        {
            
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        #region Properties (Sub-Interfaces & Simple Types)

        private ISystemAcqSettings _acquisitionSettings = new StubISystemAcqSettings();
        public ISystemAcqSettings AcquisitionSettings
        {
            get => _acquisitionSettings;
            private set => SetProperty(ref _acquisitionSettings, value, nameof(AcquisitionSettings));
        }

        private ISystemSettings _systemSettings = new StubISystemSettings();
        public ISystemSettings SystemSettings
        {
            get => _systemSettings;
            private set => SetProperty(ref _systemSettings, value, nameof(SystemSettings));
        }

        private ISystemGUISettings _gUISettings = new StubISystemGUISettings();
        public ISystemGUISettings GUISettings
        {
            get => _gUISettings;
            private set => SetProperty(ref _gUISettings, value, nameof(GUISettings));
        }

        private ISystemCommSettings _communicationSettings = new StubISystemCommSettings();
        public ISystemCommSettings CommunicationSettings
        {
            get => _communicationSettings;
            private set => SetProperty(ref _communicationSettings, value, nameof(CommunicationSettings));
        }

        private ISystemReadSettings _readSettings = new StubISystemReadSettings();
        public ISystemReadSettings ReadSettings
        {
            get => _readSettings;
            private set => SetProperty(ref _readSettings, value, nameof(ReadSettings));
        }

        private ISystemLogSettings _logSettings = new StubISystemLogSettings();
        public ISystemLogSettings LogSettings
        {
            get => _logSettings;
            private set => SetProperty(ref _logSettings, value, nameof(LogSettings));
        }

        private IWiaDevice _device = new StubIWiaDevice();
        public IWiaDevice Device
        {
            get => _device;
            private set => SetProperty(ref _device, value, nameof(Device));
        }

        private IImageSource _imageSource;
        public IImageSource ImageSource
        {
            get => _imageSource;
            // ImageSourceはインターフェイス上も set がないので private set に統一しても良いが、
            // もしインターフェイス定義で { get; } なら private set、 { get; set; } なら public set になります。
            // 今回はインターフェイス定義に従い private set とします。
            private set => SetProperty(ref _imageSource, value, nameof(ImageSource));
        }

        private IJob _job = new StubIJob();
        public IJob Job
        {
            get => _job;
            private set => SetProperty(ref _job, value, nameof(Job));
        }

        private IMaintenanceService _maintenanceServices = new StubIMaintenanceService();
        public IMaintenanceService MaintenanceServices
        {
            get => _maintenanceServices;
            private set => SetProperty(ref _maintenanceServices, value, nameof(MaintenanceServices));
        }

        private string _appVersion = "1.0.0.0";
        public string AppVersion
        {
            get => _appVersion;
            private set => SetProperty(ref _appVersion, value, nameof(AppVersion));
        }

        private bool _isOnline;
        public bool IsOnline
        {
            get => _isOnline;
            private set => SetProperty(ref _isOnline, value, nameof(IsOnline));
        }

        // Interface: { get; set; }
        private bool _isScreenLocked;
        public bool IsScreenLocked
        {
            get => _isScreenLocked;
            set => SetProperty(ref _isScreenLocked, value, nameof(IsScreenLocked));
        }

        // Interface: { get; set; }
        private bool _isAcquireDisabled;
        public bool IsAcquireDisabled
        {
            get => _isAcquireDisabled;
            set => SetProperty(ref _isAcquireDisabled, value, nameof(IsAcquireDisabled));
        }

        private string _activeJobName = "";
        public string ActiveJobName
        {
            get => _activeJobName;
            private set => SetProperty(ref _activeJobName, value, nameof(ActiveJobName));
        }

        private DateTime _activeJobLoadTime;
        public DateTime ActiveJobLoadTime
        {
            get => _activeJobLoadTime;
            private set => SetProperty(ref _activeJobLoadTime, value, nameof(ActiveJobLoadTime));
        }

        private DateTime _bootTime = DateTime.Now;
        public DateTime BootTime
        {
            get => _bootTime;
            private set => SetProperty(ref _bootTime, value, nameof(BootTime));
        }

        private IIdReadingService _idReadingService = new StubIIdReadingService();
        public IIdReadingService IdReadingService
        {
            get => _idReadingService;
            private set => SetProperty(ref _idReadingService, value, nameof(IdReadingService));
        }

        private ITuningService _tuningService = new StubITuningService();
        public ITuningService TuningService
        {
            get => _tuningService;
            private set => SetProperty(ref _tuningService, value, nameof(TuningService));
        }

        private bool _isLiveViewActive;
        public bool IsLiveViewActive
        {
            get => _isLiveViewActive;
            private set => SetProperty(ref _isLiveViewActive, value, nameof(IsLiveViewActive));
        }

        private IAcquireResult _latestAcquireResult = new StubIAcquireResult();
        public IAcquireResult LatestAcquireResult
        {
            get => _latestAcquireResult;
            private set => SetProperty(ref _latestAcquireResult, value, nameof(LatestAcquireResult));
        }

        private IImage _latestAcquiredImage = new StubIImage();
        public IImage LatestAcquiredImage
        {
            get => _latestAcquiredImage;
            private set => SetProperty(ref _latestAcquiredImage, value, nameof(LatestAcquiredImage));
        }

        private bool _isTuning;
        public bool IsTuning
        {
            get => _isTuning;
            private set => SetProperty(ref _isTuning, value, nameof(IsTuning));
        }

        private TuneState _tuneCurrentState;
        public TuneState TuneCurrentState
        {
            get => _tuneCurrentState;
            private set => SetProperty(ref _tuneCurrentState, value, nameof(TuneCurrentState));
        }

        private int _tuneCurrentSeqNumber;
        public int TuneCurrentSeqNumber
        {
            get => _tuneCurrentSeqNumber;
            private set => SetProperty(ref _tuneCurrentSeqNumber, value, nameof(TuneCurrentSeqNumber));
        }

        private int _tuneCurrentConfigNumber;
        public int TuneCurrentConfigNumber
        {
            get => _tuneCurrentConfigNumber;
            private set => SetProperty(ref _tuneCurrentConfigNumber, value, nameof(TuneCurrentConfigNumber));
        }

        #endregion

        #region Events

        public event EventHandler CloseApplicationRequested;
        public event EventHandler<IScreenVisibilityChangeEventArgs> ScreenVisibilityChangeRequested;
        public event EventHandler LiveViewStarted;
        public event EventHandler LiveViewStopped;
        public event EventHandler AcquireImageAvailable;
        public event EventHandler ImageAcquisitionFailed;

        #endregion

        #region Methods

        public void ApplicationExit(uint waitTime)
        {
            Task.Delay((int)waitTime).ContinueWith(t =>
            {
                CloseApplicationRequested?.Invoke(this, EventArgs.Empty);
            });
        }

        public string GetJobFolder() { return @"C:\Wia\Jobs"; }

        public string GetDeviceFolder() { return @"C:\ProgramData\HstVision\e-Reader\dev00"; }

        public void WriteCommandLogException(Exception exp, string msg = "")
        {
            Debug.WriteLine($"Log: {msg}, Ex: {exp?.Message}");
        }

        public void SetScreenVisibility(bool visible, int x, int y)
        {
            var args = new StubIScreenVisibilityChangeEventArgs(visible, x, y);
            ScreenVisibilityChangeRequested?.Invoke(this, args);
        }

        public bool CreateNewJob()
        {
            this.ActiveJobName = "NewJob"; // private set経由でPropertyChanged発火
            this.ActiveJobLoadTime = DateTime.Now;
            // Jobオブジェクト自体の再生成が必要ならここで行う
            this.Job = new StubIJob(); 
            return true;
        }

        public bool LoadJobFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;

            this.ActiveJobName = System.IO.Path.GetFileName(fileName);
            this.ActiveJobLoadTime = DateTime.Now;
            // Jobの中身が変わったとみなして通知
            this.Job = new StubIJob();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Job)));
            return true;
        }

        public bool SaveJobFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;
            this.ActiveJobName = System.IO.Path.GetFileName(fileName);
            this.ActiveJobLoadTime = DateTime.Now;
            return true;
        }

        public bool SaveJobOverwrite()
        {
            if (string.IsNullOrEmpty(ActiveJobName)) return false;
            // 名前は変わらないが、保存アクションとして通知が必要なら
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveJobName)));
            return true;
        }

        public bool LoadBitmapFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;

            IsAcquireDisabled = true; // public set経由で発火
            AcquireImageAvailable?.Invoke(this, EventArgs.Empty);
            return true;
        }

        public void GoOnline()
        {
            IsOnline = true; // private set経由で発火
        }

        public void GoOffline()
        {
            IsOnline = false; // private set経由で発火
        }

        // --- Stats Methods (Stubbed values) ---
        public int GetStatsResultsCount() => 100;
        public int GetStatsResultsPassNum(int configID) {
            if (50 < configID) {
                throw new ArgumentOutOfRangeException();
            }
            return 50;
        } 
        public int GetStatsResultsFailNum(int configID)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            return 20;
        }
        public double GetStatsResultsAvgScore(int configID)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            return 85.5;
        }

        public bool GetConfigNumPassed(int configID, string jobFileName, out int num)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            num = 50;
            return true;
        }
        public bool GetConfigNumFailed(int configID, string jobFileName, out int num)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            num = 5;
            return true;
        }

        public bool GetConfigAvgScore(int configID, string jobFileName, out int score)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            score = 90;
            return true;
        }

        public bool FindJobFilePath(string dispName, out string filePath)
        {
            if (string.IsNullOrEmpty(dispName)) {
                throw new ArgumentOutOfRangeException();
            }
            filePath = $@"C:\Jobs\{dispName}.wia";
            return true;
        }

        public int GetAllNumPassed(int configID)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            return 1000;
        }
        public int GetAllNumFailed(int configID)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            return 50;
        }
        public int GetAllAverageScore(int configID)
        {
            if (50 < configID)
            {
                throw new ArgumentOutOfRangeException();
            }
            return 88;
        }
        public void AllStatsClear() { }

        public IRecogCondition CreateRecogCond() => new StubIRecogCondition();
        public ICameraInfo GetCamInfo() => new StubICameraInfo();

        public void StartLiveView()
        {
            IsLiveViewActive = true; // private set経由で発火
            LiveViewStarted?.Invoke(this, EventArgs.Empty);
            AcquireImageAvailable?.Invoke(this, EventArgs.Empty);
        }

        public void StopLiveView()
        {
            IsLiveViewActive = false; // private set経由で発火
            LiveViewStopped?.Invoke(this, EventArgs.Empty);
        }

        public bool AcquireImage(int configID)
        {
            this.LatestAcquireResult = new StubIAcquireResult();
            this.LatestAcquiredImage = new StubIImage();
            AcquireImageAvailable?.Invoke(this, EventArgs.Empty);
            return true;
        }

        public int TuneStart(int configId, bool isMultiLightTuneForced)
        {
            IsTuning = true;
            TuneCurrentSeqNumber++;
            TuneCurrentConfigNumber = configId;
            TuneCurrentState = TuneState.Running;
            return 12345;
        }

        public void TuneAbort()
        {
            IsTuning = false;
            TuneCurrentState = TuneState.Completed;
        }

        public bool TuneResultJudge()
        {
            IsTuning = false;
            TuneCurrentState = TuneState.Waiting;
            return true;
        }

        #endregion
    }

    // 依存するスタブクラス（StubIScreenVisibilityChangeEventArgs以外）は省略していますが、
    // 既存のコードにある通りStubISystemAcqSettingsなどが存在することを前提としています。
    public class StubIScreenVisibilityChangeEventArgs : IScreenVisibilityChangeEventArgs
    {
        public StubIScreenVisibilityChangeEventArgs(bool visible, int x, int y)
        {
            IsVisible = visible;
            LocationX = x;
            LocationY = y;
        }
        public bool IsVisible { get; }
        public int LocationX { get; }
        public int LocationY { get; }
    }
}