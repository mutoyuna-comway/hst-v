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

        /// <summary>
        /// ReadCompletedEventを発行するかどうかを制御する
        /// </summary>
        bool IsReadCompletedEventEnabled { get; set; }

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


        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// 読取り実行
        /// </summary>
        /// <param name="imgSrc">画像取込みソース</param>
        /// <param name="scoreType">スコアモード</param>
        /// <param name="waferScoreAs100">非英数字の得点方法</param>
        /// <returns>読取り結果。nullは返されない。</returns>
        IReadResult RunRead(IImageSource imgSrc, ScoreMode scoreType, ScoreAs100 waferScoreAs100);

        /// <summary>
        /// 条件を指定して読取り実行する
        /// </summary>
        /// <param name="acq">実行画像を含んだ取込み結果</param>
        /// <param name="readSettings">読取り条件</param>
        /// <param name="scoreType">スコアモード</param>
        /// <param name="waferScoreAs100">非英数字の得点方法</param>
        /// <returns>読取り結果。nullは返されない。</returns>
        IReadResult RunReadWithParams(IAcquireResult acq, IJobReadSettings readSettings, ScoreMode scoreType, ScoreAs100 waferScoreAs100);

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

        /// <summary>
        /// チェックサム判別の実行
        /// </summary>
        /// <param name="str">文字列</param>
        /// <returns></returns>
        bool JudgeChecksum(String str);

        // TODO: 暫定のメソッド、そのうち削除する

        void SetLatestReadResult(IReadResult result);
        void ClearLatestReadResult();

        IReadResult GetLatestReadResult();

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
