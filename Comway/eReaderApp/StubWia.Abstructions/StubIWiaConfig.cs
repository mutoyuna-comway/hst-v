using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIStatsResult : IStatsResult
    {

        public StubIStatsResult() { }
        public string ConfigName { get; }
        public int RunNu { get; }
        public int PassNum { get; }
        public int FailNum { get; }
        public double AvgScore { get; }
        public string AvgScoreString { get; }
    }

    public class StubICameraInfo : ICameraInfo
    {

        public StubICameraInfo() {
            CameraFound = true;
            CameraIsConnected = true;
            ModelName = "";
            FirmwareVersion = "";
            MacAddress = PhysicalAddress.None;
            MacAddressString = "";
            SerialNumber = "";
            PacketSize = 1;
            ConnectedIPAddress = new IPAddress(0);
            SubnetMask = new IPAddress(0);
        }
        public bool CameraFound { get; }
        public bool CameraIsConnected { get; }
        public string ModelName { get; }
        public string FirmwareVersion { get; }
        public PhysicalAddress MacAddress { get; }
        public string MacAddressString { get; }
        public string SerialNumber { get; }
        public ulong PacketSize { get; }
        public IPAddress ConnectedIPAddress { get; }
        public IPAddress SubnetMask { get; }
    }

    public class StubICameraInfoFactory : ICameraInfoFactory
    {

        public StubICameraInfoFactory() { }
        public ICameraInfo Create() { return null; }
        public ICameraInfo Create(
            bool cameraFound,
            bool cameraIsConnected,
            string modelName,
            string firmwareVersion,
            PhysicalAddress macAddress,
            string serialNumber,
            ulong packetSize,
            IPAddress connectedIPAddress,
            IPAddress subnetMask)
        { return null; }
    }

    public class StubIImage : IImage
    {

        public StubIImage() { }
        public IntPtr Image { get; }
    }

    public class StubIAcquireCondition : IAcquireCondition
    {

        public StubIAcquireCondition() { }
        public int Exposure { get; }
        public int Gain { get; }
        public ImageOrient Orient { get; }
        public ILightConfig[] LightConfs { get; } = new[] {new StubILightConfig()};
    }

    public class StubIWaitResponse : IWaitResponse
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIWaitResponse() { }
        //public string ResponseCommand { get; set; }
        private string _responseCommand;
        public string ResponseCommand
        {
            get => _responseCommand;
            set
            {
                _responseCommand = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResponseCommand)));
            }
        }
        //public ulong ResponseTime { get; set; }
        private ulong _responseTime;
        public ulong ResponseTime
        {
            get => _responseTime;
            set
            {
                _responseTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResponseTime)));
            }
        }
    }

    public class StubIFilterConfig : IFilterConfig
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubIFilterConfig() { }
        //public FilterType Filter { get; set; }
        private FilterType _filter;
        public FilterType Filter
        {
            get => _filter;
            set
            {
                _filter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
            }
        }
    }

    public class StubICharacterSize : ICharacterSize
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubICharacterSize() { }
        //public double ULX { get; set; }
        private double _uLX;
        public double ULX
        {
            get => _uLX;
            set
            {
                _uLX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ULX)));
            }
        }
        //public double ULY { get; set; }
        private double _uLY;
        public double ULY
        {
            get => _uLY;
            set
            {
                _uLY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ULY)));
            }
        }
        //public double Wide { get; set; }
        private double _wide;
        public double Wide
        {
            get => _wide;
            set
            {
                _wide = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Wide)));
            }
        }
        //public double High { get; set; }
        private double _high;
        public double High
        {
            get => _high;
            set
            {
                _high = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(High)));
            }
        }
        //public double Theta { get; set; }
        private double _theta;
        public double Theta
        {
            get => _theta;
            set
            {
                _theta = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Theta)));
            }
        }
    }

    public class StubIRegion : IRegion
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StubIRegion() { }
        //public RegionMode ROIMode { get; set; }
        private RegionMode _rOIMode;
        public RegionMode ROIMode
        {
            get => _rOIMode;
            set
            {
                _rOIMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ROIMode)));
            }
        }
        //public double UlX { get; set; }
        private double _ulX;
        public double UlX
        {
            get => _ulX;
            set
            {
                _ulX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UlX)));
            }
        }
        //public double UlY { get; set; }
        private double _ulY;
        public double UlY
        {
            get => _ulY;
            set
            {
                _ulY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UlY)));
            }
        }
        //public double Wide { get; set; }
        private double _wide;
        public double Wide
        {
            get => _wide;
            set
            {
                _wide = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Wide)));
            }
        }
        //public double High { get; set; }
        private double _high;
        public double High
        {
            get => _high;
            set
            {
                _high = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(High)));
            }
        }
        //public double Theta { get; set; }
        private double _theta;
        public double Theta
        {
            get => _theta;
            set
            {
                _theta = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Theta)));
            }
        }
        //public double Phi { get; set; }
        private double _phi;
        public double Phi
        {
            get => _phi;
            set
            {
                _phi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Phi)));
            }
        }
        //public double MarginX { get; set; }
        private double _marginX;
        public double MarginX
        {
            get => _marginX;
            set
            {
                _marginX = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MarginX)));
            }
        }
        //public double MarginY { get; set; }
        private double _marginY;
        public double MarginY
        {
            get => _marginY;
            set
            {
                _marginY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MarginY)));
            }
        }
    }

}
