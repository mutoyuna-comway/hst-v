using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// OCR読取り設定
    /// </summary>
    public interface IOCRParameters : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 追加フォントGuid文字列
        /// </summary>
        string CustomFontIDString { get; set; }

        /// <summary>
        /// 認識モード
        /// </summary>
        OCROperationMode Operation { get; set; }

        /// <summary>
        /// コンフュージョンしきい値
        /// </summary>
        double ConfusionThreshold { get; set; }

        /// <summary>
        /// コンフュージョンチェックサムの利用
        /// </summary>
        bool UseConfusionChecksum { get; set; }

        /// <summary>
        /// 前処理
        /// </summary>
        PreprocessType Preprocess { get; set; }


        /// <summary>
        /// 文字幅補正フィルタ
        /// </summary>
        FilterType StrokeFilter { get; set; }

        /// <summary>
        /// 文字幅補正フィルタサイズ
        /// </summary>
        int StrokeFilterSize { get; set; }

        /// <summary>
        /// 標準文字間隔
        /// </summary>
        double NominalPitchRatio { get; set; }

        /// <summary>
        /// 広い文字間隔の有効、無効
        /// </summary>
        bool EnableWideRangeCharacter { get; set; }
        
        /// <summary>
        /// 読取りリトライモード
        /// </summary>
        ReadRetryMode ReadingRetry { get; set; }

        /// <summary>
        /// チェックサムファーストモード
        /// </summary>
        ChecksumFirstType CheckSumFirst { get; set; }
        
        /// <summary>
        /// グリッド判定モード
        /// </summary>
        OCRGridJudgeMode GridJudge { get; set; }
        
        /// <summary>
        /// 記号認識のアクセプトしきい値
        /// </summary>
        double SymbolAccept { get; set; }

        /// <summary>
        /// 記号認識の有効、無効
        /// </summary>
        bool SymbolReading { get; set; }

        /// <summary>
        /// 文字しきい値
        /// </summary>
        int CharacterThreshold { get; set; }
        
        /// <summary>
        /// 基準線エラー
        /// </summary>
        int BaseLineError { get; set; }
        
        /// <summary>
        /// スペースエラー
        /// </summary>
        int SpaceError { get; set; }


        // 
        // 下記については再考が必要
        // 
        InternalFilterType InternalFilter { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        void CopyFrom(IOCRParameters src);


    }
}
