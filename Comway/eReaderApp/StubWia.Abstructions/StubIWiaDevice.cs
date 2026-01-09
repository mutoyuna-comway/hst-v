using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIWiaDevice : IWiaDevice
    {

        public StubIWiaDevice() { }
        public bool IsCameraFound { get; }
        public bool IsValidLicense { get; }
        public string ModelName { get; }
        public string FirmwareVersion { get; }
        public string MacAddress { get; }
        public string SerialNumber { get; }
        public int PacketSize { get; set; }
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
