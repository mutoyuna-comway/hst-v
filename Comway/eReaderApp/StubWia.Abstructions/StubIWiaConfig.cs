using System;
using System.Collections.Generic;
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

        public StubICameraInfo() { }
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

        public StubIWaitResponse() { }
        public string ResponseCommand { get; set; }
        public ulong ResponseTime { get; set; }
    }

    public class StubIFilterConfig : IFilterConfig
    {

        public StubIFilterConfig() { }
        public FilterType Filter { get; set; }
    }

    public class StubICharacterSize : ICharacterSize
    {

        public StubICharacterSize() { }
        public double ULX { get; set; }
        public double ULY { get; set; }
        public double Wide { get; set; }
        public double High { get; set; }
        public double Theta { get; set; }
    }

    public class StubIRegion : IRegion
    {

        public StubIRegion() { }
        public RegionMode ROIMode { get; set; }
        public double UlX { get; set; }
        public double UlY { get; set; }
        public double Wide { get; set; }
        public double High { get; set; }
        public double Theta { get; set; }
        public double Phi { get; set; }
        public double MarginX { get; set; }
        public double MarginY { get; set; }
    }

}
