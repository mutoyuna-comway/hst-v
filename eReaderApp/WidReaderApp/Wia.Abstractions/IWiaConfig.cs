using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Xml.Serialization;
using Wia.Abstractions;

namespace Wia.Abstractions
{

    public interface IStatsResult
    {
        string ConfigName { get; }
        int RunNu { get; }
        int PassNum { get; }
        int FailNum { get; }
        double AvgScore { get; }
        string AvgScoreString { get; }
    }

    //public interface IStatsResults<IStatsResult> : IEnumerable<IStatsResult>, IReadOnlyList<IStatsResult>
    //{
    //}


    public interface ICameraInfo
    {
        //TODO: 以下、本来はsetは必要ない
        bool CameraFound { get; }
        bool CameraIsConnected { get; }
        string ModelName { get; }
        string FirmwareVersion { get; }
        PhysicalAddress MacAddress { get; }
        string MacAddressString { get; }
        string SerialNumber { get; }
        ulong PacketSize { get; }
        IPAddress ConnectedIPAddress { get; }
        IPAddress SubnetMask { get; }
    }

    public sealed class CameraInfoOptions
    {
        bool CameraFound { get; }
        bool CameraIsConnected { get; }
        string ModelName { get; }
        string FirmwareVersion { get; }
        PhysicalAddress MacAddress { get; }
        string MacAddressString { get; }
        string SerialNumber { get; }
        int PacketSize { get; }
        IPAddress ConnectedIPAddress { get; }
        IPAddress SubnetMask { get; }

        //public CameraInfoOptions(
        //    bool cameraFound,
        //    bool cameraIsConnected,
        //    string modelName,
        //    string firmwareVersion,
        //    PhysicalAddress macAddress,
        //    string serialNumber,
        //    int packetSize,
        //    IPAddress connectedIPAddress,
        //    IPAddress subnetMask )
        //{ 
        //    CameraFound = cameraFound;
        //    CameraIsConnected = cameraIsConnected;
        //    ModelName = modelName;
        //    FirmwareVersion = firmwareVersion;
        //    MacAddress = macAddress;
        //    SerialNumber = serialNumber;
        //    PacketSize = packetSize;
        //    ConnectedIPAddress = connectedIPAddress;
        //    SubnetMask = subnetMask;
        //}
    }

    public interface ICameraInfoFactory
    {
        ICameraInfo Create();

        ICameraInfo Create(
            bool cameraFound,
            bool cameraIsConnected,
            string modelName,
            string firmwareVersion,
            PhysicalAddress macAddress,
            string serialNumber,
            ulong packetSize,
            IPAddress connectedIPAddress,
            IPAddress subnetMask);
    }

    public interface IImage
    {
        IntPtr Image { get; }
    }

    public interface IAcquireCondition
    {
        int Exposure { get; }
        int Gain { get; }

        ImageOrient Orient { get; }

        ILightConfig[] LightConfs { get; }
    }

    public interface IWaitResponse
    {
        /// <summary>
        /// 応答コマンド
        /// </summary>
        string ResponseCommand { get; set; }

        /// <summary>
        /// 応答時間(mesc.)
        /// </summary>
        ulong ResponseTime { get; set; }
    }


    public interface IFilterConfig
    {
        FilterType Filter { get; set; }
    }
        
    public interface ICharacterSize
    {
        double ULX { get; set; }
        double ULY { get; set; }
        double Wide { get; set; }
        double High { get; set; }
        double Theta { get; set; }
    }
    public interface IRegion
    {
        RegionMode ROIMode { get; set; }
        double UlX { get; set; }
        double UlY { get; set; }
        double Wide { get; set; }
        double High { get; set; }
        double Theta { get; set; }
        double Phi { get; set; }

        double MarginX { get; set; }
        double MarginY { get; set; }
    }

    //
    // TODO: コマンドからのプロパティ設定はPropertyChangedイベントに対応させる必要がある
    // ライブラリモード時もしくは未変更時はイベントを反映しない
    //

}