using System;
using System.Security.AccessControl;

namespace Wia.Abstractions
{
    /// <summary>
    /// 読取りデバイス
    /// </summary>
    public interface IWiaDevice
    {
        bool IsCameraFound { get; }
        bool IsValidLicense { get; }
        string ModelName { get; }
        string FirmwareVersion { get; }
        string MacAddress { get; }
        string SerialNumber { get; }

        int PacketSize { get; set; }

        int GainMax { get; }
        int GainMin { get; }

        int ExposureMin { get; }
        int ExposureMax { get; }

        ICameraInfo CameraInfo { get; }

        ISystemAcqSettings CurrentAcqSettings { get; }

        event EventHandler CameraInfoChanged;

        void Initialize(ApplicationType appType, string camModuleName, string lightModuleName);

        bool ReconnectDevice();

        void Disconnect();

        bool CheckLicense();

        void NotifyAcqError();

        /// <summary>
        /// ライセンスが認証されるかどうかを確認する
        /// </summary>
        /// <param name="authentiCode">認証コード</param>
        /// <returns>判定結果 true: 認証パス</returns>
        bool IsLicensed(string authentiCode);

    }
}