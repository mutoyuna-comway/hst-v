using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using Wia.Abstractions;
using static System.Net.Mime.MediaTypeNames;

namespace StubWia
{

    public class StubIStatsResult : IStatsResult
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIStatsResult() { }
        private string _configName;
        public string ConfigName {
            get { return this._configName; }
            private set
            {
                this._configName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfigName)));
            }
        }
        private int _runNu;
        public int RunNu {
            get { return this._runNu; }
            private set
            {
                this._runNu = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RunNu)));
            }
        }
        private int _passNum;
        public int PassNum {
            get { return this._passNum; }
            private set
            {
                this._passNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PassNum)));
            }
        }
        private int _failNum;
        public int FailNum {
            get { return this._failNum; }
            private set
            {
                this._failNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FailNum)));
            }
        }private double _avgScore;
        public double AvgScore {
            get { return this._avgScore; }
            private set
            {
                this._avgScore = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AvgScore)));
            }
        }
        private string _avgScoreString;
        public string AvgScoreString {
            get { return this._avgScoreString; }
            private set
            {
                this._avgScoreString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AvgScoreString)));
            }
        }
    }

    public class StubICameraInfo : ICameraInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        private bool _cameraFound;
        public bool CameraFound {
            get { return this._cameraFound; }
            private set
            {
                this._cameraFound = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CameraFound)));
            }
        }
        private bool _cameraIsConnected;
        public bool CameraIsConnected {
            get { return this._cameraIsConnected; }
            private set
            {
                this._cameraIsConnected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CameraIsConnected)));
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
        private PhysicalAddress _macAddress;
        public PhysicalAddress MacAddress {
            get { return this._macAddress; }
            private set
            {
                this._macAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MacAddress)));
            }
        }
        private string _macAddressString;
        public string MacAddressString {
            get { return this._macAddressString; }
            private set
            {
                this._macAddressString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MacAddressString)));
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
        private ulong _packetSize;
        public ulong PacketSize {
            get { return this._packetSize; }
            private set
            {
                this._packetSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PacketSize)));
            }
        }
        private IPAddress _connectedIPAddress;
        public IPAddress ConnectedIPAddress {
            get { return this._connectedIPAddress; }
            private set
            {
                this._connectedIPAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConnectedIPAddress)));
            }
        }
        private IPAddress _subnetMask;
        public IPAddress SubnetMask {
            get { return this._subnetMask; }
            private set
            {
                this._subnetMask = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubnetMask)));
            }
        }
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
        public event PropertyChangedEventHandler PropertyChanged;

        public StubIImage() { }
        private IntPtr _image;
        public IntPtr Image
        {
            get => _image;
            set
            {
                _image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Image)));
            }
        }
    }

    public class StubIAcquireCondition : IAcquireCondition
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIAcquireCondition() { }
        private int _exposure;
        public int Exposure {
            get => _exposure;
            set
            {
                _exposure = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Exposure)));
            }
        }
        private int _gain;
        public int Gain {
            get => _gain;
            set
            {
                _gain = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gain)));
            }
        }
        private ImageOrient _orient;
        public ImageOrient Orient {
            get => _orient;
            set
            {
                _orient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Orient)));
            }
        }
        private ILightConfig[] _lightConfs = new[] { new StubILightConfig() };
        public ILightConfig[] LightConfs {
            get => _lightConfs;
            set
            {
                _lightConfs = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightConfs)));
            }
        }
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
