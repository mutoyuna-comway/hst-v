using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubIWiaDevice : IWiaDevice
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StubIWiaDevice() {
            IsCameraFound = true;
            IsValidLicense = true;
            ModelName = "";
            FirmwareVersion = "";
            MacAddress = "";
            SerialNumber = "";
            GainMax = 1;
            GainMin = 1;
            ExposureMin = 1;
            ExposureMax = 1;    

        }
        private bool _isCameraFound;
        public bool IsCameraFound {
            get { return this._isCameraFound; }
            private set
            {
                this._isCameraFound = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCameraFound)));
            }
        }
        private bool _isValidLicense;
        public bool IsValidLicense {
            get { return this._isValidLicense; }
            private set
            {
                this._isValidLicense = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsValidLicense)));
            }
        }
        private string _modelName;
        public string ModelName {
            get { return this._modelName; }
            private set
            {
                this._modelName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ModelName)));
            }
        }
        private string _firmwareVersion;
        public string FirmwareVersion {
            get { return this._firmwareVersion; }
            private set
            {
                this._firmwareVersion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirmwareVersion)));
            }
        }
        private string _macAddress;
        public string MacAddress {
            get { return this._macAddress; }
            private set
            {
                this._macAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MacAddress)));
            }
        }
        private string _serialNumber;
        public string SerialNumber {
            get { return this._serialNumber; }
            private set
            {
                this._serialNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SerialNumber)));
            }
        }
        //public int PacketSize { get; set; }
        private int _packetSize;
        public int PacketSize
        {
            get => _packetSize;
            set
            {
                _packetSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PacketSize)));
            }
        }
        private int _gainMax;
        public int GainMax {
            get { return this._gainMax; }
            private set
            {
                this._gainMax = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GainMax)));
            }
        }
        private int _gainMin;
        public int GainMin {
            get { return this._gainMin; }
            private set
            {
                this._gainMin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GainMin)));
            }
        }
        private int _exposureMin;
        public int ExposureMin {
            get { return this._exposureMin; }
            private set
            {
                this._exposureMin = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExposureMin)));
            }
        }
        private int _exposureMax;
        public int ExposureMax {
            get { return this._exposureMax; }
            private set
            {
                this._exposureMax = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExposureMax)));
            }
        }
        private ICameraInfo _cameraInfo = new StubICameraInfo();
        public ICameraInfo CameraInfo {
            get { return this._cameraInfo; }
            private set
            {
                this._cameraInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CameraInfo)));
            }
        }
        private ISystemAcqSettings _currentAcqSettings = new StubISystemAcqSettings();
        public ISystemAcqSettings CurrentAcqSettings {
            get { return this._currentAcqSettings; }
            private set
            {
                this._currentAcqSettings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentAcqSettings)));
            }
        }
        public event EventHandler CameraInfoChanged;
        public void Initialize(ApplicationType appType, string camModuleName, string lightModuleName) { }
        public bool ReconnectDevice() { return true; }
        public void Disconnect() { }
        public bool CheckLicense() { return true; }
        public void NotifyAcqError() { }
        public bool IsLicensed(string authentiCode) { return true; }
    }
}
