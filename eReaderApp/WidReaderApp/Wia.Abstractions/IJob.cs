using System;
using System.Collections.Generic;

namespace Wia.Abstractions
{
    /// <summary>
    /// ウェーハID読取りアプリケーションのジョブ
    /// </summary>
    public interface IJob
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
        IEnumerable<IJobConfig> Configs { get; }

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


        //
        // TODO: 下記については今後修正検討が必要となる。
        //

        bool CheckValidConfigID(int configID);

        bool CheckExistenceConfig(int targetConfig);

        int GetConfigMaxNum();

    }

}