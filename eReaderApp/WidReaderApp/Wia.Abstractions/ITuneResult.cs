using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// チューニング結果
    /// </summary>
    public interface ITuneResult
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// マーク種別
        /// </summary>
        MarkType Mark { get; }

        /// <summary>
        /// 読取数
        /// </summary>
        int NumRead { get; }

        /// <summary>
        /// 読取可否(現在)
        /// </summary>
        bool CurrentPassed { get; }

        /// <summary>
        /// 読取文字(現在)
        /// </summary>
        string CurrentString { get; }

        /// <summary>
        /// スコア(現在)
        /// </summary>
        double CurrentScore { get; }

        /// <summary>
        /// チューン成功回数
        /// </summary>
        int NumTunePassed { get; }

        /// <summary>
        /// チューン失敗回数
        /// </summary>
        int NumTuneFailed { get; }

        /// <summary>
        /// 最小スコア
        /// </summary>
        double CurrentMinimumScore { get; }

        /// <summary>
        /// 取込パラメータ
        /// </summary>
        IAcquireCondition AcqCondition { get; }

        /// <summary>
        /// 読取パラメータ
        /// </summary>
        IJobReadSettings ReadSettings { get; }

        /// <summary>
        /// 読取可否(最良スコア時)
        /// </summary>
        bool BestPassed { get; }

        /// <summary>
        /// 読取文字(最良スコア時)
        /// </summary>
        string BestString { get; }

        /// <summary>
        /// 最良スコア
        /// </summary>
        double BestScore { get; }

        /// <summary>
        /// ベスト最小スコア
        /// </summary>
        double BestMinimumScore { get; }

        /// <summary>
        /// ベスト取込パラメータ
        /// </summary>
        IAcquireCondition BestAcqCondition { get; }

        /// <summary>
        /// ベスト読取パラメータ
        /// </summary>
        IJobReadSettings BestReadSettings { get; }

        /// <summary>
        /// ベストのチューン時の画像
        /// </summary>
        IImage BestPassedImage { get; }

        /// <summary>
        /// ベストの実行番号
        /// </summary>
        int BestRecordNumber { get; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// クローンの生成
        /// </summary>
        /// <returns></returns>
        ITuneResult Clone();

        /// <summary>
        /// Astar付きCurrentStringの取得
        /// </summary>
        /// <param name="fieldStrNum">フィールド文字列の文字数</param>
        /// <returns></returns>
        string GetCurrentString(int fieldStrNum);

        /// <summary>
        /// Astar付きBestStringの取得
        /// </summary>
        /// <param name="fieldStrNum">フィールド文字列の文字数</param>
        /// <returns></returns>
        string GetBestString(int fieldStrNum);
    }
}
