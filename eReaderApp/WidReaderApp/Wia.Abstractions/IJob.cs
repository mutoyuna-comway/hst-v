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
        IJobConfig SelectedConfig { get; }

        /// <summary>
        /// 現在選択されているジョブコンフィグの番号
        /// </summary>
        int SelectedConfigIndex { get; set; }

        /// <summary>
        /// 割り当てられているジョブコンフィグの列挙
        /// </summary>
        IConfigStore Configs { get; }

        /// <summary>
        /// コンフィグ最大数構成タイプ
        /// </summary>
        MaxNumConfigType MaxNumConfig { get; set; }

        /// <summary>
        /// システムオブジェクトの取得
        /// </summary>
        IWiaSystem SystemService { get; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        /// <summary>
        /// コンフィグ読取り結果が更新されたことを通知するイベント
        /// </summary>
        event EventHandler<IReadCompletedEventArgs> ConfigReadResultAvailable;

        /// <summary>
        /// 選択されているジョブコンフィグが変更されることを通知するイベント
        /// </summary>
        event EventHandler SelectedConfigChanging;

        /// <summary>
        /// 選択されているジョブコンフィグが変更されたことを通知するイベント
        /// </summary>
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
        /// <returns>ジョブコンフィグ</returns>
        /// <remarks>まだ割り当てられていない番号を指定された場合は、初期状態のジョブコンフィグを返す。</remarks>
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
        bool CopyConfig(int srcConfID, int dstConfID);

        /// <summary>
        /// 読取り実行
        /// </summary>
        /// <returns>読み取ったコンフィグ番号。失敗の場合は-1を返す。</returns>
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

        //
        // TODO: 下記については今後修正検討が必要となる。
        //

        bool CheckValidConfigID(int configID);

        bool CheckExistenceConfig(int targetConfig);

        int GetConfigMaxNum();

        int RunReadRetry(int configID, int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, out IReadResult result);
    }

}