using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
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
        public bool IsCameraFound { get; }
        public bool IsValidLicense { get; }
        public string ModelName { get; }
        public string FirmwareVersion { get; }
        public string MacAddress { get; }
        public string SerialNumber { get; }
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
        public int GainMax { get; }
        public int GainMin { get; }
        public int ExposureMin { get; }
        public int ExposureMax { get; }
        public ICameraInfo CameraInfo { get; } = new StubICameraInfo();
        public ISystemAcqSettings CurrentAcqSettings { get; } = new StubISystemAcqSettings();
        public event EventHandler CameraInfoChanged;
        public void Initialize(ApplicationType appType, string camModuleName, string lightModuleName) { }
        public bool ReconnectDevice() { return true; }
        public void Disconnect() { }
        public bool CheckLicense() { return true; }
        public void NotifyAcqError() { }
        public bool IsLicensed(string authentiCode) { return true; }
    }
}
