using System;
using System.Net.NetworkInformation;

namespace Wia.Abstractions
{

    /// <summary>
    /// カメラインターフェース
    /// </summary>
    public interface ICamContloler : IDisposable
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 実際の画像取り込みデバイスかどうか
        /// </summary>
        bool IsRealDevice { get; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// 初期化
        /// </summary>
        void Initialize();

        /// <summary>
        /// モジュール名の取得
        /// </summary>
        /// <returns>モジュール名</returns>
        String GetModuleName();

        /// <summary>
        /// 露光最小値の取得
        /// </summary>
        /// <returns>露光最小値</returns>
        int GetExposureMin();

        /// <summary>
        /// 露光最大値の取得
        /// </summary>
        /// <returns>露光最大値</returns>
        int GetExposureMax();

        /// <summary>
        /// ゲインの最小値取得
        /// </summary>
        /// <returns>ゲイン最小値</returns>
        int GetGainMin();

        /// <summary>
        /// ゲインの最大値取得
        /// </summary>
        /// <returns>ゲイン最大値</returns>
        int GetGainMax();

        /// <summary>
        /// 接続
        /// </summary>
        /// <param name="prms">設定状況</param>
        /// <param name="cameraInfoFactory">カメラ情報生成オブジェクト</param>
        /// <param name="expString">返答文字列</param>
        /// <returns>カメラ情報</returns>
        ICameraInfo Connect(ISystemCameraSettings prms, ICameraInfo currentCamInfo, ICameraInfoFactory cameraInfoFactory, out String expString);

        /// <summary>
        /// 切断
        /// </summary>
        /// <param name="expString">返答文字列</param>
        /// <returns>接続可否</returns>
        bool Disconnect(out String expString);

        /// <summary>
        /// 撮像
        /// </summary>
        /// <param name="cue">キュー</param>
        /// <param name="image">画像</param>
        /// <param name="expString">返答文字列</param>
        /// <returns>撮像可否</returns>
        bool Acquire(IAcquireCondition cue, IImage image, out String expString);

        /// <summary>
        /// 接続状態の取得
        /// </summary>
        /// <returns>接続</returns>
        bool GetIsConnected();

        /// <summary>
        /// カメラモデル名の取得
        /// </summary>
        /// <returns>カメラモデル名</returns>
        String GetCameraModelName();

        /// <summary>
        /// ファームウェアバージョンの取得
        /// </summary>
        /// <returns>ファームウェアバージョン</returns>
        String GetFirmwareVersion();

        /// <summary>
        /// マックアドレスの取得
        /// </summary>
        /// <returns>マックアドレス</returns>
        PhysicalAddress GetMacAddress();

        /// <summary>
        /// シリアルナンバーの取得
        /// </summary>
        /// <returns>シリアルナンバー</returns>
        String GetSerialNumber();

        /// <summary>
        /// パケットサイズの取得
        /// </summary>
        /// <returns>パケットサイズ</returns>
        ulong GetPacketSize();

        /// <summary>
        /// パケットサイズの設定
        /// </summary>
        /// <param name="packetSize">パケットサイズ</param>
        /// <param name="expString">返答文字列</param>
        /// <returns>設定可否</returns>
        bool SetPacketSize(ulong packetSize, ref String expString);


        /// <summary>
        /// パケットディレイの取得
        /// </summary>
        /// <returns>パケットディレイ</returns>
        ulong GetPacketDelay();

        /// <summary>
        /// パケットディレイの設定
        /// </summary>
        /// <param name="packetDelay">パケットディレイ</param>
        /// <param name="expString">返答文字列</param>
        /// <returns>設定可否</returns>
        bool SetPacketDelay(ulong packetDelay, ref String expString);

        /// <summary>
        /// ゲインの取得
        /// </summary>
        /// <returns>ゲイン値</returns>
        int GetGain();

        /// <summary>
        /// ゲインの設定
        /// </summary>
        /// <param name="gain">ゲイン値</param>
        /// <param name="expString">返答文字列</param>
        /// <returns>設定可否</returns>
        bool SetGain(int gain, ref String expString);

        /// <summary>
        /// 露光時間取得
        /// </summary>
        /// <returns>露光時間</returns>
        int GetExposure();

        /// <summary>
        /// 露光時間設定
        /// </summary>
        /// <param name="exposure">露光時間</param>
        /// <param name="expString">返答文字列</param>
        /// <returns>設定可否</returns>
        bool SetExposure(int exposure, ref String expString);

        /// <summary>
        /// タイトルへの表示名
        /// </summary>
        /// <returns>表示名</returns>
        String GetDisplayDeviceTitle();

        /// <summary>
        /// 取込みタイムアウト時間の設定
        /// </summary>
        /// <param name="acquireTimeout"></param>
        void SetAcquireTimeout(int acquireTimeout);
    }
}
