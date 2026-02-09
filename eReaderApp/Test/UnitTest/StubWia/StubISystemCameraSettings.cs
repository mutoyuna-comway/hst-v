using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubISystemCameraSettings : ISystemCameraSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubISystemCameraSettings() { }
        //public IPAddress CameraIPAddress { get; set; }
        private IPAddress _cameraIPAddress;
        public IPAddress CameraIPAddress
        {
            get => _cameraIPAddress;
            set
            {
                _cameraIPAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CameraIPAddress)));
            }
        }
        //public string CameraIPAddressString { get; set; }
        private string _cameraIPAddressString;
        public string CameraIPAddressString
        {
            get => _cameraIPAddressString;
            set
            {
                _cameraIPAddressString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CameraIPAddressString)));
            }
        }
        //public bool ConnectToSpecify { get; set; }
        private bool _connectToSpecify;
        public bool ConnectToSpecify
        {
            get => _connectToSpecify;
            set
            {
                _connectToSpecify = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConnectToSpecify)));
            }
        }
        //public int PacketDelay { get; set; }
        private int _packetDelay;
        public int PacketDelay
        {
            get => _packetDelay;
            set
            {
                _packetDelay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PacketDelay)));
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
        //public string AuthenticationCode { get; set; }
        private string _authenticationCode;
        public string AuthenticationCode
        {
            get => _authenticationCode;
            set
            {
                _authenticationCode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthenticationCode)));
            }
        }
        //public bool SendImageToHost { get; set; }
        private bool _sendImageToHost;
        public bool SendImageToHost
        {
            get => _sendImageToHost;
            set
            {
                _sendImageToHost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SendImageToHost)));
            }
        }
        //public string AcqImageSaveFileName { get; set; }
        private string _acqImageSaveFileName;
        public string AcqImageSaveFileName
        {
            get => _acqImageSaveFileName;
            set
            {
                _acqImageSaveFileName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqImageSaveFileName)));
            }
        }
        //public string AcqImageSaveFileNameHalf { get; set; }
        private string _acqImageSaveFileNameHalf;
        public string AcqImageSaveFileNameHalf
        {
            get => _acqImageSaveFileNameHalf;
            set
            {
                _acqImageSaveFileNameHalf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqImageSaveFileNameHalf)));
            }
        }

    }
}
