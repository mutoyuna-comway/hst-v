using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// カメラシステム設定
    /// </summary>
    public interface ISystemCameraSettings : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// カメラのIPアドレス
        /// </summary>
        IPAddress CameraIPAddress { get; set; }

        /// <summary>
        /// カメラのIPアドレス文字列
        /// </summary>
        string CameraIPAddressString { get; set; }

        /// <summary>
        /// 指定IPアドレスへの接続
        /// </summary>
        bool ConnectToSpecify { get; set; }

        /// <summary>
        /// パケットディレイ
        /// </summary>
        int PacketDelay { get; set; }

        /// <summary>
        /// パケットサイズ
        /// </summary>
        int PacketSize { get; set; }

        /// <summary>
        /// 認証コード
        /// </summary>
        string AuthenticationCode { get; set; }

        /// <summary>
        /// 画像転送設定
        /// </summary>
        bool SendImageToHost { get; set; }

        /// <summary>
        /// 取込み画像のファイル出力先のファイル名。半解像度で出力。
        /// 指定のない場合は出力しない。
        string AcqImageSaveFileName { get; set; }

        /// <summary>
        /// 取込み画像のファイル出力先のファイル名。半解像度で出力。
        /// 指定のない場合は出力しない。
        /// </summary>
        string AcqImageSaveFileNameHalf { get; set; }

    }
}
