using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubISystemSettings : ISystemSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubISystemSettings() { }
        //public string Password { get; set; }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }
        //public string SystemRootFolderName { get; set; }
        private string _systemRootFolderName;
        public string SystemRootFolderName
        {
            get => _systemRootFolderName;
            set
            {
                _systemRootFolderName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SystemRootFolderName)));
            }
        }
        //public string SystemRoot { get; set; }
        private string _systemRoot;
        public string SystemRoot
        {
            get => _systemRoot;
            set
            {
                _systemRoot = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SystemRoot)));
            }
        }
        //public string SystemFolder { get; set; }
        private string _systemFolder;
        public string SystemFolder
        {
            get => _systemFolder;
            set
            {
                _systemFolder = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SystemFolder)));
            }
        }
        //public string DeviceFolder { get; set; }
        private string _deviceFolder;
        public string DeviceFolder
        {
            get => _deviceFolder;
            set
            {
                _deviceFolder = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DeviceFolder)));
            }
        }
        //public int DeviceID { get; set; }
        private int _deviceID;
        public int DeviceID
        {
            get => _deviceID;
            set
            {
                _deviceID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DeviceID)));
            }
        }
        //public IProcessorSettings ProcSetting { get; set; } = new StubIProcessorSettings();
        private IProcessorSettings _procSetting = new StubIProcessorSettings();
        public IProcessorSettings ProcSetting
        {
            get => _procSetting;
            set
            {
                _procSetting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcSetting)));
            }
        }
        //public bool UseExternalLight { get; set; }
        private bool _useExternalLight;
        public bool UseExternalLight
        {
            get => _useExternalLight;
            set
            {
                _useExternalLight = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UseExternalLight)));
            }
        }
        //public string UseLanguage { get; set; }
        private string _useLanguage;
        public string UseLanguage
        {
            get => _useLanguage;
            set
            {
                _useLanguage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UseLanguage)));
            }
        }
        //public bool ExpandConfig { get; set; }
        private bool _expandConfig;
        public bool ExpandConfig
        {
            get => _expandConfig;
            set
            {
                _expandConfig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExpandConfig)));
            }
        }
        //public string JobTemplate { get; set; }
        private string _jobTemplate;
        public string JobTemplate
        {
            get => _jobTemplate;
            set
            {
                _jobTemplate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JobTemplate)));
            }
        }
        //public string StartupJob { get; set; }
        private string _startupJob;
        public string StartupJob
        {
            get => _startupJob;
            set
            {
                _startupJob = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartupJob)));
            }
        }
        //public ApplicationType AppOperationalSpec { get; set; }
        private ApplicationType _appOperationalSpecb;
        public ApplicationType AppOperationalSpec
        {
            get => _appOperationalSpecb;
            set
            {
                _appOperationalSpecb = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AppOperationalSpec)));
            }
        }
        public string GetSystemFolder() { return ""; }
        public string GetDeviceFolder() { return ""; }
        public string GetAppFolder() { return ""; }
        public string GetJobFolder() { return ""; }
        public string GetDefaultAllImageFolder() { return ""; }
        public string GetDefaultFailImageFolder() { return ""; }
        public string GetLogFolder() { return ""; }
        public void ProhibitSettingSystemRootFolder() { }
    }
}
