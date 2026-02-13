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

        /// <summary>
        /// チューニングの実行中かどうかを取得
        /// </summary>
        bool IsTuning { get; }

        /// <summary>
        /// チューニングの現在の状態を取得
        /// </summary>
        TuneState TuneCurrentState { get; }

        /// <summary>
        /// チューニングの実行連番の取得
        /// </summary>
        int TuneCurrentSeqNumber { get; }

        /// <summary>
        /// チューニング実行中のジョブコンフィグ番号の取得
        /// </summary>
        int TuneCurrentConfigNumber { get; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        /// <summary>
        /// アプリケーションの終了要求のイベント
        /// </summary>
        /// <remarks>
        /// <see cref="ApplicationExit(uint)"/> によって発火される。
        /// </remarks>
        event EventHandler CloseApplicationRequested;

        /// <summary>
        /// アプリケーションの画面が表示されたことを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="SetScreenVisibility(bool,int,int)"/> によって発火される。
        /// </remarks>
        event EventHandler<IScreenVisibilityChangeEventArgs> ScreenVisibilityChangeRequested;

        /// <summary>
        /// ライブ表示が開始されたことを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="StartLiveView()"/> によって発火される。
        /// </remarks>
        event EventHandler LiveViewStarted;

        /// <summary>
        /// ライブ表示が終了ことを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="StopLiveView()"/> によって発火される。
        /// </remarks>
        event EventHandler LiveViewStopped;

        /// <summary>
        /// 画像取込みが完了し取り込んだ画像が利用可能になったことを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="LoadBitmapFile(string)"/> によって発火される。
        /// <see cref="StartLiveView()"/> によって発火される。
        /// </remarks>
        event EventHandler AcquireImageAvailable;

        /// <summary>
        /// 画像取込みが失敗したことを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="StartLiveView()"/> によって発火される。
        /// </remarks>
        event EventHandler ImageAcquisitionFailed;

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// アプリケーションを終了する
        /// </summary>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="CloseApplicationRequested"/></term>
        ///     <description>
        ///       指定した待ち時間経過後に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="waitTime">終了処理を開始するまでの待ち時間。msec</param>
        void ApplicationExit(uint waitTime);

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
        /// コマンド実行で発生したエラーを
        /// シーケンスログ(Seq_YYYY.MM.DD_hh.mm.ss.000.log)と
        /// アサーションログ(AssertionLog_YYYYMMDD_hh.log)に出力する
        /// </summary>
        /// <remarks>
        /// <see cref="GetDeviceFolder"/> で取得したパスと <c>Log</c> フォルダ名を
        /// 連結したフォルダにログが出力される。
        /// </remarks>
        /// <param name="exp">例外オブジェクト</param>
        /// <param name="msg">エラーを表す文字列</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="exp"/> が <see langword="null"/> で、
        /// <paramref name="msg"/> が空文字の場合にスローされる。
        /// </exception> 
        void WriteCommandLogException(Exception exp, string msg = "");

        /// <summary>
        /// メイン画面の表示、非表示と位置を変更する
        /// </summary>
        /// <remarks>
        /// 変更を依頼するイベントを発火することで機能を実行する。
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <see cref="ScreenVisibilityChangeRequested"/>。
        /// </remarks>
        /// <param name="visible">表示、非表示</param>
        /// <param name="x">画面左上の位置x</param>
        /// <param name="y">画面左上の位置y</param>
        void SetScreenVisibility(bool visible, int x, int y);

        /// <summary>
        /// 新規のジョブを作成する
        /// </summary>
        /// <remarks>
        /// エラーが発生した場合は、アプリケーションログにエラー内容を出力する。例外は発生しない。
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="JobChanging"/></term>
        ///     <description>
        ///       ジョブが変更される<strong>前</strong>に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"ActiveJobName"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="ActiveJobName"/>プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"Job"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="Job"/>プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="JobChanged"/></term>
        ///     <description>
        ///       ジョブが変更された<strong>後</strong>に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <returns>
        /// 成功した場合は <see langword="true"/>、
        /// 失敗の場合は <see langword="false"/>。
        /// </returns>
        bool CreateNewJob();

        /// <summary>
        /// ジョブファイルを読み込む
        /// </summary>
        /// <remarks>
        /// エラーが発生した場合は、アプリケーションログにエラー内容を出力する。例外は発生しない。
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="JobChanging"/></term>
        ///     <description>
        ///       ジョブが変更される<strong>前</strong>に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"ActiveJobName"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="ActiveJobName"/>プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"Job"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="Job"/>プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="JobChanged"/></term>
        ///     <description>
        ///       ジョブが変更された<strong>後</strong>に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="fileName">ジョブファイルのフルパスファイル名</param>
        /// <returns>
        /// <returns>
        /// 読み込みに成功した場合は <see langword="true"/>、
        /// 失敗（ファイル名が不正・存在しないなど）の場合は <see langword="false"/>。
        /// </returns>
        bool LoadJobFile(string fileName);

        /// <summary>
        /// ジョブの内容をファイルに保存する
        /// </summary>
        /// <remarks>
        /// エラーが発生した場合は、アプリケーションログにエラー内容を出力する。例外は発生しない。
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <see cref = "PropertyChanged" />（<c>"ActiveJobName"</c>）
        /// </remarks>
        /// <param name="fileName">ジョブファイルのフルパスファイル名</param>
        /// <returns>
        /// 保存に成功した場合は <see langword="true"/>、
        /// 失敗（ファイル名が不正など）の場合は <see langword="false"/>。
        /// </returns>
        bool SaveJobFile(string fileName);

        /// <summary>
        /// 現在のジョブを上書き保存する
        /// </summary>
        /// <remarks>
        /// エラーが発生した場合は、アプリケーションログにエラー内容を出力する。例外は発生しない。
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// </remarks>
        /// <see cref = "PropertyChanged" />（<c>"ActiveJobName"</c>）
        /// <returns>
        /// 保存に成功した場合は <see langword="true"/>、
        /// 失敗（無題でファイル名が特定されないなど）の場合は <see langword="false"/>。
        /// </returns>
        bool SaveJobOverwrite();

        /// <summary>
        /// ビットマップの画像ファイルを読み込む
        /// </summary>
        /// <remarks>
        /// エラーが発生した場合は、アプリケーションログにエラー内容を出力する。例外は発生しない。
        /// <para>
        /// 処理に成功すると画像取込みが無効となる。
        /// </para>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"IsAcquireDisabled"</c>）
        ///     </term>
        ///     <description>
        ///       読込みに成功した場合に<see cref="IsAcquireDisabled"/>プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="AcquireImageAvailable"/></term>
        ///     <description>
        ///       読込みに成功した場合に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="fileName">ビットマップのフルパスファイル名</param>
        /// 読み込みに成功した場合は <see langword="true"/>、
        /// 失敗（ファイル名が不正・存在しないなど）の場合は <see langword="false"/>。
        bool LoadBitmapFile(string fileName);

        /// <summary>
        /// 接続モードオンラインに移行する
        /// </summary>
        /// <remarks>
        /// 接続モードが変更された場合は以下のイベントを発火する。
        /// <see cref = "PropertyChanged" />（<c>"IsOnline"</c>）
        /// </remarks>
        void GoOnline();

        /// <summary>
        /// 接続モードオフラインに移行する
        /// </summary>
        /// <remarks>
        /// 接続モードが変更された場合は以下のイベントを発火する。
        /// <see cref = "PropertyChanged" />（<c>"IsOnline"</c>）
        /// </remarks>
        void GoOffline();

        /// <summary>
        /// 実行結果の統計情報の総数を得る
        /// </summary>
        /// <returns>統計情報の総数</returns>
        int GetStatsResultsCount();

        /// <summary>
        /// 実行結果の統計情報の成功数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>成功数</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        int GetStatsResultsPassNum(int configID);

        /// <summary>
        /// 実行結果の統計情報の失敗数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>失敗数</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        int GetStatsResultsFailNum(int configID);

        /// <summary>
        /// 実行結果の統計情報の平均スコアを得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>平均スコア</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        double GetStatsResultsAvgScore(int configID);

        /// <summary>
        /// ジョブ名とコンフィグ番号を指定して統計情報の成功数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <param name="jobFileName">ジョブファイル名</param>
        /// <param name="num">成功数を出力する</param>
        /// <returns>true:成功</returns>
        /// <remarks>ジョブ名が空のときは、全てのジョブを対象として値を返す。</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="jobFileName"/>が見つからない
        /// </exception>
        bool GetConfigNumPassed(int configID, string jobFileName, out int num);

        /// <summary>
        /// ジョブ名とコンフィグ番号を指定して統計情報の失敗数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <param name="jobFileName">ジョブファイル名</param>
        /// <param name="num">失敗数を出力する</param>
        /// <returns>true:成功</returns>
        /// <remarks>ジョブ名が空のときは、全てのジョブを対象として値を返す。</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="jobFileName"/>が見つからない
        /// </exception>
        bool GetConfigNumFailed(int configID, string jobFileName, out int num);

        /// <summary>
        /// ジョブ名とコンフィグ番号を指定して統計情報の平均スコアを得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <param name="jobFileName">ジョブファイル名</param>
        /// <param name="score">平均スコア[0-100]を出力する</param>
        /// <returns>true:成功</returns>
        /// <remarks>ジョブ名が空のときは、全てのジョブを対象として値を返す。</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="jobFileName"/>が見つからない
        /// </exception>
        bool GetConfigAvgScore(int configID, string jobFileName, out int score);

        /// <summary>
        /// 統計情報のジョブのフルパスファイル名を返す
        /// </summary>
        /// <param name="dispName">ジョブ名</param>
        /// <param name="filePath">フルパスファイル名を出力する。</param>
        /// <returns>true:成功</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="dispName"/>が見つからない
        /// </exception>
        bool FindJobFilePath(String dispName, out String filePath);

        /// <summary>
        /// コンフィグの統計情報の成功数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>成功数</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        int GetAllNumPassed(int configID);

        /// <summary>
        /// コンフィグの統計情報の失敗数を得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>失敗数</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        int GetAllNumFailed(int configID);

        /// <summary>
        /// コンフィグの統計情報の平均スコアを得る
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>平均スコア</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
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
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"IsLiveViewActive"</c>）
        ///     </term>
        ///     <description>
        ///       ライブ表示が開始された場合に<see cref="IsLiveViewActive"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="LiveViewStarted"/></term>
        ///     <description>
        ///       ライブ表示が開始された場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="AcquireImageAvailable"/></term>
        ///     <description>
        ///       ライブ表示を停止するまで読込みに成功した場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="ImageAcquisitionFailed"/></term>
        ///     <description>
        ///       ライブ表示中の取込みでエラーが発生した場合に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        void StartLiveView();

        /// <summary>
        /// ライブ表示を終了する
        /// </summary>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"IsLiveViewActive"</c>）
        ///     </term>
        ///     <description>
        ///       ライブ表示が終了した場合に<see cref="IsLiveViewActive"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="LiveViewStopped"/></term>
        ///     <description>
        ///       ライブ表示が終了した場合に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        void StopLiveView();

        /// <summary>
        /// 画像取込み
        /// </summary>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term><see cref="AcquireImageAvailable"/></term>
        ///     <description>
        ///       ライブ表示を停止するまで読込みに成功した場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="ImageAcquisitionFailed"/></term>
        ///     <description>
        ///       ライブ表示中の取込みでエラーが発生した場合に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="configId">コンフィグ番号</param>
        /// <returns>
        /// 成功した場合は <see langword="true"/>、
        /// 失敗の場合は <see langword="false"/>。
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        bool AcquireImage(int configID);

        /// <summary>
        /// チューン開始
        /// </summary>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"IsTuning"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングが開始された場合に<see cref="IsTuning"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneCurrentState"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングの状態<see cref="TuneCurrentState"/>が<see cref="TuneState.Waiting"/>から<see cref="TuneState.Running"/>
        ///       に変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneCurrentSeqNumber"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングが開始された場合に<see cref="TuneCurrentSeqNumber"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneCurrentConfigNumber"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングが開始された場合に<see cref="TuneCurrentConfigNumber"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="configId">コンフィグ番号</param>
        /// <param name="isMultiLightTuneForced">マルチ照明チューニングを強制するかどうか</param>
        /// <returns>チューニング実行ID</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="configID"/>が範囲外
        /// </exception>
        int TuneStart(int configId, bool isMultiLightTuneForced);

        /// <summary>
        /// チューンキャンセル
        /// </summary>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"IsTuning"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングが開始された場合に<see cref="IsTuning"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneCurrentState"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングの状態<see cref="TuneCurrentState"/>が<see cref="TuneState.Running"/>から<see cref="TuneState.Completed"/>
        ///       に変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        void TuneAbort();

        /// <summary>
        /// チューン結果可否を決定する。
        /// </summary>
        /// <remarks>
        /// <para>読取できたものがあればその結果を承認し、ジョブコンフィグの内容を更新する。</para>
        /// <para>そうでなければ結果を破棄する。</para>
        /// <para>チューニング実行中<see cref="TuneState.Running"/>であれば中止して判定する。</para>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"IsTuning"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングが開始された場合に<see cref="IsTuning"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneCurrentState"</c>）
        ///     </term>
        ///     <description>
        ///       チューニングの状態<see cref="TuneCurrentState"/>が<see cref="TuneState.Completed"/>または<see cref="TuneState.Running"/>から
        ///       <see cref="TuneState.Waiting"/>に変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <exception cref="TimeoutException">チューン停止待ち処理がタイムアウトした</exception>
        /// <returns>
        /// 承認された場合は <see langword="true"/>、
        /// 破棄された場合は <see langword="false"/>。
        /// </returns>
        bool TuneResultJudge();
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