using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;

namespace Wia.Abstractions
{
    /// <summary>
    /// ウェーハID読取りアプリケーションのシステム
    /// </summary>
    public interface IWiaSystem : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// システム設定、画像取込
        /// </summary>
        ISystemAcqSettings AcquisitionSettings { get; }

        /// <summary>
        /// システム設定、システム全般
        /// </summary>
        ISystemSettings SystemSettings { get; }

        /// <summary>
        /// システム設定、画面制御
        /// </summary>
        ISystemGUISettings GUISettings { get; }

        /// <summary>
        /// システム設定、通信設定
        /// </summary>
        ISystemCommSettings CommunicationSettings { get; }

        /// <summary>
        /// システム設定、読取設定
        /// </summary>
        ISystemReadSettings ReadSettings { get; }

        /// <summary>
        /// システム設定、ログ記録
        /// </summary>
        ISystemLogSettings LogSettings { get; }

        /// <summary>
        /// 読取りデバイス情報
        /// </summary>
        IWiaDevice Device { get; }

        /// <summary>
        /// 画像取込みソース
        /// </summary>
        IImageSource ImageSource { get; }

        /// <summary>
        /// 通信管理
        /// </summary>
        IWiaCommManager CommManager { get; }

        /// <summary>
        /// ジョブ
        /// </summary>
        IJob Job { get; }

        /// <summary>
        /// 保守機能サービス
        /// </summary>
        IMaintenanceService MaintenanceServices { get; }

        /// <summary>
        /// アプリケーションソフトウェアのバージョン
        /// </summary>
        string AppVersion { get; }

        /// <summary>
        /// オンライン状態 tru:オンライン false:
        /// </summary>
        bool IsOnline { get; }

        /// <summary>
        /// 画面がロックされているかどうか true:ロックされている
        /// </summary>
        bool IsScreenLocked { get; set; }

        /// <summary>
        /// 取込の無効化(DIBの読込) true:無効
        /// </summary>
        bool IsAcquireDisabled { get; set; }

        /// <summary>
        /// ライブラリモード
        /// </summary>

        /// <summary>
        /// 現在開かれているジョブ名
        /// </summary>
        string ActiveJobName { get; }

        /// <summary>
        /// 現在開かれているジョブの開いた日時
        /// </summary>
        DateTime ActiveJobLoadTime { get; }

        /// <summary>
        /// アプリケーションを起動した日時
        /// </summary>
        DateTime BootTime { get; }

        /// <summary>
        /// ID読取り管理
        /// </summary>
        IIdReadingService IdReadingService { get; }

        /// <summary>
        /// チューニング管理
        /// </summary>
        ITuningService TuningService { get; }

        /// <summary>
        /// ライブ中
        /// </summary>
        bool IsLiveViewActive { get; }

        /// <summary>
        /// 最新の画像取り込み結果の取得
        /// </summary>
        IAcquireResult LatestAcquireResult { get; }

        /// <summary>
        /// 最新の取り込み画像の取得
        /// </summary>
        IImage LatestAcquiredImage { get; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        /// <summary>
        /// アプリケーションの終了要求のイベント
        /// </summary>
        event EventHandler CloseApplicationRequested;

        /// <summary>
        /// アプリケーションの画面が表示されたことを通知するイベント
        /// </summary>
        event EventHandler<IScreenVisibilityChangeEventArgs> ScreenVisibilityChangeRequested;

        /// <summary>
        /// ライブ表示が開始されたことを通知するイベント
        /// </summary>
        event EventHandler LiveViewStarted;

        /// <summary>
        /// ライブ表示が終了ことを通知するイベント
        /// </summary>
        event EventHandler LiveViewStopped;

        event EventHandler AcquireImageAvailable;


        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// アプリケーションを終了する
        /// </summary>
        /// <param name="waitTime">終了処理を開始するまでの待ち時間。msec</param>
        void ApplicationExit(int waitTime);

        /// <summary>
        /// Jobフォルダの取得
        /// </summary>
        /// <returns>Jobフォルダのフルパスフォルダ名</returns>
        string GetJobFolder();

        /// <summary>
        /// デバイスフォルダ取得　例) C:\ProgramData\HstVision\e-Reader\dev00
        /// </summary>
        /// <returns>デバイスフォルダのフルパスフォルダ名</returns>

        string GetDeviceFolder();

        /// <summary>
        /// コマンド実行で発生したエラーをシーケンスログに出力する
        /// </summary>
        /// <param name="exp">例外オブジェクト</param>
        /// <param name="msg">エラーを表す文字列</param>
        void WriteCommandLogException(Exception exp, string msg = "");

        /// <summary>
        /// 画面の表示、非表示と位置を変更する
        /// </summary>
        /// <param name="visible">表示、非表示</param>
        /// <param name="x">画面左上の位置x</param>
        /// <param name="y">画面左上の位置y</param>
        /// <remarks>ScreenVisibilityChangeRequestedイベントが発行される。</remarks>
        void SetScreenVisibility(bool visible, int x, int y);

        /// <summary>
        /// ジョブファイルを読み込む
        /// </summary>
        /// <param name="fileName">ジョブファイルのフルパスファイル名</param>
        /// <returns>true:成功</returns>
        /// <remarks>Jobプロパティが変更される</remarks>
        bool LoadJobFile(String fileName);

        /// <summary>
        /// ジョブの内容をファイルに保存する
        /// </summary>
        /// <param name="fileName">ジョブファイルのフルパスファイル名</param>
        /// <returns>true:成功</returns>
        bool SaveJobFile(String fileName);

        /// <summary>
        /// ビットマップの画像ファイルを読み込む
        /// </summary>
        /// <param name="fileName">ビットマップのフルパスファイル名</param>
        /// <returns>true:成功</returns>
        /// <remarks>画像取込みが無効となる。IsAcquireDisabledプロパティが変更される。</remarks>
        bool LoadBitmapFile(String fileName);

        /// <summary>
        /// 接続モードオンラインに移行する
        /// </summary>
        /// <remarks>IsOnlineプロパティが変更される。</remarks>
        void GoOnline();

        /// <summary>
        /// 接続モードオフラインに移行する
        /// </summary>
        /// <remarks>IsOnlineプロパティが変更される。</remarks>
        void GoOffline();

        /// <summary>
        /// 実行結果の統計情報の総数を得る
        /// </summary>
        /// <returns>統計情報の総数</returns>
        int GetStatsResultsCount();

        /// <summary>
        /// 実行結果の統計情報の成功数を得る
        /// </summary>
        /// <param name="index">コンフィグ番号</param>
        /// <returns>成功数</returns>
        int GetStatsResultsPassNum(int index);

        /// <summary>
        /// 実行結果の統計情報の失敗数を得る
        /// </summary>
        /// <param name="index">コンフィグ番号</param>
        /// <returns>失敗数</returns>
        int GetStatsResultsFailNum(int index);

        /// <summary>
        /// 実行結果の統計情報の平均スコアを得る
        /// </summary>
        /// <param name="index">コンフィグ番号</param>
        /// <returns>平均スコア</returns>
        double GetStatsResultsAvgScore(int index);

        /// <summary>
        /// ジョブ名とコンフィグ番号を指定して統計情報の成功数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <param name="jobFileName">ジョブファイル名</param>
        /// <param name="num">成功数を出力する</param>
        /// <returns>true:成功</returns>
        /// <remarks>ジョブ名が空のときは、全てのジョブを対象として値を返す。</remarks>
        bool GetConfigNumPassed(int configID, string jobFileName, out int num);

        /// <summary>
        /// ジョブ名とコンフィグ番号を指定して統計情報の失敗数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <param name="jobFileName">ジョブファイル名</param>
        /// <param name="num">失敗数を出力する</param>
        /// <returns>true:成功</returns>
        /// <remarks>ジョブ名が空のときは、全てのジョブを対象として値を返す。</remarks>
        bool GetConfigNumFailed(int configID, string jobFileName, out int num);

        /// <summary>
        /// ジョブ名とコンフィグ番号を指定して統計情報の平均スコアを得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <param name="jobFileName">ジョブファイル名</param>
        /// <param name="score">平均スコア[0-100]を出力する</param>
        /// <returns>true:成功</returns>
        /// <remarks>ジョブ名が空のときは、全てのジョブを対象として値を返す。</remarks>
        bool GetConfigAvgScore(int configID, string jobFileName, out int score);

        /// <summary>
        /// 統計情報のジョブのフルパスファイル名を返す
        /// </summary>
        /// <param name="dispName">ジョブ名</param>
        /// <param name="filePath">フルパスファイル名を出力する。</param>
        /// <returns>true:成功</returns>
        bool FindJobFilePath(String dispName, out String filePath);

        /// <summary>
        /// コンフィグの統計情報の成功数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>成功数</returns>
        int GetAllNumPassed(int configID);

        /// <summary>
        /// コンフィグの統計情報の失敗数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>失敗数</returns>
        int GetAllNumFailed(int configID);

        /// <summary>
        /// コンフィグの統計情報の平均スコアを得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>平均スコア</returns>
        int GetAllAverageScore(int configID);

        /// <summary>
        /// 統計情報をクリアする
        /// </summary>
        void AllStatsClear();
        
        /// <summary>
        /// 認識条件オブジェクトを生成する
        /// </summary>
        /// <returns></returns>
        IRecogCondition CreateRecogCond();

        /// <summary>
        /// カメラ情報を取得する
        /// </summary>
        /// <returns>カメラ情報オブジェクト</returns>
        ICameraInfo GetCamInfo();

        /// <summary>
        /// ライブ表示を開始する
        /// </summary>
        /// <remarks>LiveViewStartedイベントが発行される。</remarks>
        void StartLiveView();

        /// <summary>
        /// ライブ表示を終了する
        /// </summary>
        /// <remarks>LiveViewStoppedイベントが発行される。</remarks>
        void StopLiveView();

        /// <summary>
        /// 画像取込み
        /// </summary>
        /// <param name="configId">コンフィグ番号</param>
        /// <returns>true: 成功 false: 失敗</returns>
        bool AcquireImage(int configId);

        /// <summary>
        /// チューン開始
        /// </summary>
        /// <param name="configId">コンフィグ番号</param>
        /// <param name="isMultiLightTuneForced">マルチ照明チューニングを強制するかどうか</param>
        /// <returns>チューニング実行ID</returns>
        int TuneStart(int configId, bool isMultiLightTuneForced);

        /// <summary>
        /// チューンキャンセル
        /// </summary>
        void TuneAbort();

        /// <summary>
        /// チューン結果可否を確認
        /// </summary>
        /// <remarks>読取できたものがあれば承認/そうでなければRejectする</remarks>
        /// <exception cref="TimeoutException">チューン停止待ち処理がタイムアウトした</exception>
        /// <returns>Accept(true)/Reject(false)</returns>
        bool TuneResultJudge();


        //
        // Jobのチューニング処理に関するメソッド、TODO: 本来はIJobにあるべき
        //


        bool IsTuning { get; }

        TuneState TuneCurrentState { get; }

        int TuneCurrentSeqNumber { get; }

        int TuneCurrentConfigNumber { get; }

        //
        // Config
        //

    }

    /// <summary>
    /// アプリケーションの画面が表示されたことを通知するイベント引数
    /// </summary>
    public interface IScreenVisibilityChangeEventArgs
    {
        /// <summary>
        /// 表示状態、true:表示
        /// </summary>
        bool IsVisible { get; }

        /// <summary>
        /// ウィンドウの左上X座標
        /// </summary>
        int LocationX { get; }

        /// <summary>
        /// ウィンドウの左上Y座標
        /// </summary>
        int LocationY { get; }
    }

}