using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// 読取り結果
    /// </summary>
    public interface IReadResult
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// マークの種類
        /// </summary>
        MarkType Mark { get; }

        /// <summary>
        /// 読取文字
        /// </summary>
        string ReadString { get; }

        /// <summary>
        /// スコア
        /// </summary>
        double Score { get; }

        /// <summary>
        /// 最小スコア
        /// </summary>
        double MinScore { get; }

        /// <summary>
        /// 実行時間(msec.)
        /// </summary>
        double ElapsedTime { get; }

        /// <summary>
        /// ジョブコンフィグ番号
        /// </summary>
        int ConfigID { get; }

        /// <summary>
        /// 領域
        /// </summary>
        IRegion ROI { get; }

        /// <summary>
        /// 文字サイズ
        /// </summary>
        ICharacterSize CharSize { get; }

        /// <summary>
        /// 読取可否
        /// </summary>
        bool Pass { get; }

        /// <summary>
        /// タイムアウトが発生したかどうか true:タイムアウト発生
        /// </summary>
        bool IsTimeout { get; }

        /// <summary>
        /// コンフュージョン文字列
        /// </summary>
        string ConfusionString { get; }

        /// <summary>
        /// コンフュージョンチェックサム機能で訂正されたかどうか true:訂正された　
        /// </summary>
        bool IsCorrectConfChecksum { get; }

        /// <summary>
        /// 各文字結果
        /// </summary>
        IReadOcrResult[] OcrResults { get; }  //nullの場合あり、OCRの結果でない場合はnull

        /// <summary>
        /// 読取り条件
        /// </summary>
        IJobReadSettings ReadSettings { get; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// 加点スコアを取得する
        /// </summary>
        /// <param name="sr">スコアレンジ</param>
        /// <returns></returns>
        double GetAddedScore(ScoreRange sr);

        /// <summary>
        /// クローンの生成
        /// </summary>
        /// <returns></returns>
        IReadResult Clone();
    }

    /// <summary>
    /// 文字の読取り結果
    /// </summary>
    public interface IReadOcrResult
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 文字(ASCII値)
        /// </summary>
        char Character { get; }

        /// <summary>
        /// スコア値
        /// </summary>
        int Value { get; }

        /// <summary>
        /// 行
        /// </summary>
        double Row { get; }

        /// <summary>
        /// 列
        /// </summary>
        double Col { get; }

        /// <summary>
        /// 文字しきい値をパスしたかどうか
        /// </summary>
        bool PassCharTh { get; }

        /// <summary>
        /// チェックサムファーストによる検出
        /// </summary>
        bool FoundChecksumFirst { get; }

        /// <summary>
        /// 記号かどうか
        /// </summary>
        bool IsSymbol { get; }

        /// <summary>
        /// みつかったかどうか
        /// </summary>
        bool IsFound { get; }

        /// <summary>
        /// コンフュージョンかどうか
        /// </summary>
        bool IsConfusion { get; }

        /// <summary>
        /// ラインスペースエラーの発生を示す
        /// </summary>
        int LSError { get; }
    }

}
