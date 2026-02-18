using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Wia.Abstractions
{
    /// <summary>
    /// ウェーハID読取りアプリケーションのジョブ
    /// </summary>
    public interface IJob : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 読取り手法
        /// </summary>
        ReadMethod ReadType { get; set; }

        /// <summary>
        /// スコアモード
        /// </summary>
        ScoreMode ScoreType { get; set; }

        /// <summary>
        /// 現在選択されているジョブコンフィグ
        /// </summary>
        /// <remarks>
        /// <see cref="SelectedConfigIndex"/>を変更すると変更される。</remarks>
        IJobConfig SelectedConfig { get; }

        /// <summary>
        /// 現在選択されているジョブコンフィグの番号
        /// </summary>
        /// <remarks>
        /// <para>
        /// このプロパティの値が変更された場合は以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "PropertyChanged" />（<c>"SelectedConfig"</c>）
        ///     </term>
        ///     <description>
        ///       <see cref="SelectedConfig"/>プロパティの値が変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term> <see cref = "SelectedConfigChanging" /> </term>
        ///     <description>
        ///       選択中のジョブコンフィグが変更されることを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term> <see cref = "SelectedConfigChanged" /> </term>
        ///     <description>
        ///       選択中のジョブコンフィグが変更されたことを通知するイベントを発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        int SelectedConfigIndex { get; set; }

        /// <summary>
        /// 割り当てられているジョブコンフィグの列挙
        /// </summary>
        /// <remarks>このプロパティはReadonlyで変更されることはない。</remarks>
        IConfigStore Configs { get; }

        /// <summary>
        /// コンフィグ最大数構成タイプ
        /// </summary>
        /// <see cref = "GetConfigMaxNum()" />で返す値が変わる
        MaxNumConfigType MaxNumConfig { get; set; }

        /// <summary>
        /// システムオブジェクトの取得
        /// </summary>
        /// <remarks>このプロパティはReadonlyで変更されることはない。</remarks>
        IWiaSystem SystemService { get; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        /// <summary>
        /// コンフィグ読取りが完了したイベント
        /// </summary>
        /// <remarks>
        /// <see cref="RunRead()"/>メソッドの実行が終了した場合に発火される。
        /// </remarks>
        event EventHandler<IReadCompletedEventArgs> ConfigReadCompleted;

        /// <summary>
        /// コンフィグ読取り結果が更新されたことを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="RunRead()"/>メソッドの実行中に発火される。
        /// </remarks>
        event EventHandler<IReadCompletedEventArgs> ConfigReadResultAvailable;

        /// <summary>
        /// 選択されているジョブコンフィグが変更されることを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="SelectedConfigIndex"/>プロパティの変更前にによって発火される。
        /// </remarks>
        event EventHandler SelectedConfigChanging;

        /// <summary>
        /// 選択されているジョブコンフィグが変更されたことを通知するイベント
        /// </summary>
        /// <remarks>
        /// <see cref="SelectedConfigIndex"/>プロパティの変更によって発火される。
        /// </remarks>
        event EventHandler SelectedConfigChanged;

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// 指定した番号のジョブコンフィグを返す
        /// </summary>
        /// <param name="index">番号</param>
        /// <remarks>まだ割り当てられていない番号を指定された場合は、初期状態のジョブコンフィグを返す。</remarks>
        /// <returns>ジョブコンフィグ</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index"/>が範囲外。最小値:0、最大値:<see cref="MaxNumConfig"/>の値により、49または15となる。
        /// </exception>
        IJobConfig GetConfig(int index);

        /// <summary>
        /// コンフィグ番号でソートされた有効に設定されているジョブコンフィグの配列を返す
        /// </summary>
        /// <returns>ジョブコンフィグの配列</returns>
        IJobConfig[] GetSortedEnableConfigArray();

        /// <summary>
        /// ジョブで使われているカスタムフォントがシステムに存在するか確認する
        /// </summary>
        /// <returns>true:存在する false:しない</returns>
        bool CheckFontIdValidity();

        /// <summary>
        /// ジョブコンフィグのコピー
        /// </summary>
        /// <param name="srcConfID">コピー元のコンフィグ番号</param>
        /// <param name="dstConfID">コピー先のコンフィグ番号</param>
        /// <returns>true:成功</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="srcConfID"/>が範囲外。最小値:0、最大値:<see cref="GetConfigMaxNum()"/>の値により、49または15となる。
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="dstConfID"/>が範囲外。最小値:0、最大値:<see cref="GetConfigMaxNum()"/>の値により、49または15となる。
        /// </exception>
        bool CopyConfig(int srcConfID, int dstConfID);

        /// <summary>
        /// 読取りに成功するまでジョブコンフィグ読取りを行う
        /// </summary>
        /// <returns>読み取ったコンフィグ番号。失敗の場合は-1を返す。</returns>
        /// <remarks>
        /// <para>
        /// このメソッドは処理の過程で以下のイベントを発火する。
        /// </para>
        /// <list type="bullet">
        ///   <item>
        ///     <term>
        ///       <see cref = "ConfigReadResultAvailable" />
        ///     </term>
        ///     <description>
        ///       コンフィグ読取り結果が更新された場合に発火する。
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <term><see cref="ConfigReadCompleted"/></term>
        ///     <description>
        ///       コンフィグ読取りが完了した場合に発火する。
        ///     </description>
        ///   </item>
        /// </list>
        /// </remarks>
        int RunRead();

        /// <summary>
        /// チューン結果のリセット
        /// </summary>
        void ClearTuneResult();

        /// <summary>
        /// 読取り結果についてLastBestのコンフィグ番号の取得
        /// </summary>
        /// <returns>コンフィグ番号。未実行の場合は0を返す。</returns>
        int GetLastBestConfigId();

        /// <summary>
        /// 読取り結果について指定したコンフィグ番号のLastBestの結果を取得する
        /// </summary>
        /// <param name="configID">コンフィグ番号</param>
        /// <returns>読取り結果</returns>
        IReadResult GetReadBestResult(int configID);

        /// <summary>
        /// ジョブコンフィグの最大数の取得
        /// </summary>
        /// <returns>コンフィグ最大数</returns>
        int GetConfigMaxNum();

        //
        // TODO: 下記については今後修正検討が必要となる。
        //

        bool CheckValidConfigID(int configID);

        bool CheckExistenceConfig(int targetConfig);

        int RunReadRetry(int configID, int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, out IReadResult result);
    }

}