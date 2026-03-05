using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ジョブコンフィグ
    /// </summary>
    public interface IJobConfig : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 親ジョブ
        /// </summary>
        /// <remarks>このプロパティはReadonlyで変更されることはない。</remarks>
        IJob ParentJob { get; }

        /// <summary>
        /// コンフィグ番号
        /// </summary>
        /// <remarks>このプロパティはReadonlyで変更されることはない。</remarks>
        int ConfigID { get; }

        /// <summary>
        /// 取込み設定
        /// </summary>
        /// <remarks>このプロパティはReadonlyで変更されることはない。</remarks>
        IJobAcqSettings AcquireSettings { get; }

        /// <summary>
        /// 読取り設定
        /// </summary>
        /// <remarks>このプロパティはReadonlyで変更されることはない。</remarks>
        IJobReadSettings ReadSettings { get; }

        /// <summary>
        /// チューニング設定
        /// </summary>
        /// <remarks>このプロパティはReadonlyで変更されることはない。</remarks>
        /// <remarks>
        /// <see cref = "SetTuneSettings" />メソッドを実行すると変更される。
        /// </remarks>
        IJobTuneSettings TuneSettings { get; }

        /// <summary>
        /// 最後に実行されたチューニングの結果
        /// </summary>
        /// <remarks>
        /// チューニング実行中に変更される。
        /// <see cref = "RunTuning" />メソッドを実行すると変更される。
        /// <see cref = "ClearTuneResult" />メソッドを実行すると変更される。
        /// </remarks>
        ITuneResult TuneLatestResult { get; }

        /// <summary>
        /// チューニング実行の進捗
        /// </summary>
        /// <remarks>
        /// チューニング実行中に変更される。
        /// <see cref = "RunTuning" />メソッドを実行すると変更される。
        /// </remarks>
        double TuneProgress { get; }

        /// <summary>
        /// 有効、無効
        /// </summary>
        bool Enable { get; set; }

        /// <summary>
        /// ReadCompletedEventを発行するかどうかを制御する
        /// </summary>
        bool IsReadCompletedEventEnabled { get; set; }

        /// <summary>
        /// 最後に読み取った結果
        /// </summary>
        /// <remarks>
        /// <see cref = "RunRead" />メソッドを実行すると変更される。
        /// </remarks>
        IReadResult LatestReadResult { get; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        /// <summary>
        /// 読取結果が確定したイベント
        /// 読取実行を繰り返し、結果が確定したときに発行される
        /// </summary>
        event EventHandler<IReadCompletedEventArgs> ReadCompleted;

        /// <summary>
        /// チューニングが開始される前のイベント
        /// </summary>
        event EventHandler TuneStarting;

        /// <summary>
        /// チューンが終了したことを通知するイベント
        /// </summary>
        event EventHandler TuneCompleted;

        /// <summary>
        /// チューン画像更新イベント
        /// </summary>
        event EventHandler<IAcquireImageCompletedEventArgs> TuneImageUpdated;

        /// <summary>
        /// チューン更新イベント
        /// </summary>
        event EventHandler TuneResultUpdated;

        /// <summary>
        /// チューン結果が承認されたことを通知するイベント
        /// </summary>
        event EventHandler TuneResultAccepted;

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// 読取り実行
        /// </summary>
        /// <returns>読取り結果。nullは返されない。</returns>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "ReadCompleted" />
        ///     </term>
        ///     <description>
        ///       コンフィグ読取りが終了した場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"LatestReadResult"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="LatestReadResult"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        IReadResult RunRead();

        /// <summary>
        /// 条件を指定して読取り実行する
        /// </summary>
        /// <param name="acq">実行画像を含んだ取込み結果</param>
        /// <param name="readSettings">読取り条件</param>
        /// <returns>読取り結果。nullは返されない。</returns>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "ReadCompleted" />
        ///     </term>
        ///     <description>
        ///       コンフィグ読取りが終了した場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"LatestReadResult"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="LatestReadResult"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        IReadResult RunReadWithParams(IAcquireResult acq, IJobReadSettings readSettings);

        /// <summary>
        /// チューン開始
        /// </summary>
        /// <param name="isMultiLightTuneForced">マルチ照明チューニングを強制するかどうか</param>
        /// <return>チューニング実行ID</return>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "TuneStarting" />
        ///     </term>
        ///     <description>
        ///       チューニング処理が開始された場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "TuneImageUpdated" />
        ///     </term>
        ///     <description>
        ///       チューニング実行中に画像が取り込まれた場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "TuneResultUpdated" />
        ///     </term>
        ///     <description>
        ///       チューニング実行中にチューニング結果が更新された場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneLatestResult"</c>）
        ///     </term>
        ///     <description>
        ///       チューニング実行中、チューニング結果が更新された場合に<see cref="TuneLatestResult"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneProgress"</c>）
        ///     </term>
        ///     <description>
        ///       チューニング実行中、チューニング進捗率が更新された場合に<see cref="TuneProgress"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        int RunTuning(bool isMultiLightTuneForced);

        /// <summary>
        /// チューニングを停止して、承認待ち状態にする
        /// </summary>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "TuneCompleted" />
        ///     </term>
        ///     <description>
        ///       チューニング処理が停止された場合に発火する。
        ///     </description>
        ///   </item>
        /// </remarks>
        void CancelTuning();

        /// <summary>
        /// チューニングを中止して、実行待ち状態にする
        /// </summary>
        /// <returns>チューニング連番  -1:チューニングは実行されていない</returns>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "TuneCompleted" />
        ///     </term>
        ///     <description>
        ///       チューニング処理が停止された場合に発火する。
        ///     </description>
        ///   </item>
        /// </remarks>
        int AbortTuning();

        /// <summary>
        /// チューニング結果を承認してジョブコンフィグ設定に反映する
        /// </summary>
        /// <returns>false: 合格したチューニング結果が無い</returns>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "TuneResultAccepted" />
        ///     </term>
        ///     <description>
        ///       チューニング結果が承認された場合に発火する。
        ///     </description>
        ///   </item>
        /// </remarks>
        bool AcceptTuningResult();

        /// <summary>
        /// チューン結果可否を確認し、合格の場合は結果を承認する
        /// </summary>
        /// <remarks>チューニング実行中であれば中止して判定する。</remarks>
        /// <returns>false: 合格したチューニング結果が無い</returns>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "TuneResultAccepted" />
        ///     </term>
        ///     <description>
        ///       チューニング結果が承認された場合に発火する。
        ///     </description>
        ///   </item>
        /// </remarks>
        bool JudgeTuningResult();

        /// <summary>
        /// チューン結果のリセット
        /// </summary>
        void ClearTuneResult();

        /// <summary>
        /// ジョブで使われているカスタムフォントがシステムに存在するか確認する
        /// </summary>
        /// <returns>true:存在する false:しない</returns>
        bool CheckFontIdValidity();

        /// <summary>
        /// チューニング設定情報をセットする
        /// </summary>
        /// <param name="tuneSettings">チューニング設定情報</param>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"TuneSettings"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="TuneSettings"/>
        ///       プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </remarks>
        void SetTuneSettings( IJobTuneSettings tuneSettings );

        /// <summary>
        /// 設定内容を変更する
        /// </summary>
        /// <param name="readSettings">読取り設定</param>
        /// <param name="acqSettings">画像取込み設定</param>
        /// <remarks>
        /// それぞれのオブジェクトのプロパティをコピーする。
        /// 変更があったプロパティの<see cref = "PropertyChanged" />イベントが発火される。
        /// </remarks>
        void ApplySettings(IJobReadSettings readSettings, IJobAcqSettings acqSettings);

        /// <summary>
        /// チェックサム判別の実行
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns></returns>
        bool JudgeChecksum(String str);

        /// <summary>
        /// チェックサムでのスコア調整
        /// </summary>
        /// <param name="score">読取りスコア</param>
        /// <param name="readedString">読取り文字列</param>
        /// <param name="pass">読み取れたかどうか</param>
        /// <param name="readSettings">読取り設定</param>
        /// <returns>調整されたスコア</returns>
        int GetAdjustedChecksumScore(double score, string readedString, bool pass, IJobReadSettings readSettings);

        /// <summary>
        /// クローンの生成
        /// </summary>
        /// <returns></returns>
        IJobConfig Clone();
    }

    public interface IReadCompletedEventArgs
    {
        IReadResult Result { get; }

        /// <summary>
        /// 読取結果
        /// </summary>
        IAcquireResult AcqResult { get;  }

        /// <summary>
        /// ログ出力時の識別用の文字列
        /// </summary>
        string LogIdString { get; }

    }
}
