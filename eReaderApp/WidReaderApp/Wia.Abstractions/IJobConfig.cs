using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ジョブコンフィグ
    /// </summary>
    public interface IJobConfig
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// コンフィグ番号
        /// </summary>
        int ConfigID { get; }

        /// <summary>
        /// 取込み設定
        /// </summary>
        IJobAcqSettings AcquireSettings { get; }

        /// <summary>
        /// 読取り設定
        /// </summary>
        IJobReadSettings ReadSettings { get; }

        /// <summary>
        /// チューニング設定
        /// </summary>
        IJobTuneSettings TuneSettings { get; }

        /// <summary>
        /// 最後に実行されたチューニングの結果
        /// </summary>
        ITuneResult TuneLatestResult { get; } //nullは許容しない。結果がない場合はgcnew EReader::TuneResult();を返す　Director->LatestTuneと置換え予定

        /// <summary>
        /// 有効、無効
        /// </summary>
        bool Enable { get; set; }


        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// ジョブで使われているカスタムフォントがシステムに存在するか確認する
        /// </summary>
        /// <returns>true:存在する false:しない</returns>
        bool CheckFontIdValidity();

        /// <summary>
        /// チューニング設定情報をセットする
        /// </summary>
        /// <param name="tuneSettings">チューニング設定情報</param>
        void SetTuneSettings( IJobTuneSettings tuneSettings );

        /// <summary>
        /// 設定内容を変更する
        /// </summary>
        /// <param name="readSettings">読取り設定</param>
        /// <param name="acqSettings">画像取込み設定</param>
        void ApplySettings(IJobReadSettings readSettings, IJobAcqSettings acqSettings);


        // TODO: 暫定のメソッド、そのうち削除する

        void SetLatestReadResult(IReadResult result);
        void ClearLatestReadResult();

    }

}
