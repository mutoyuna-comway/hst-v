using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ジョブ読取り設定
    /// </summary>
    public interface IJobReadSettings : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 読取りID種別
        /// </summary>
        MarkType Mark { get; set; }

        /// <summary>
        /// チェックサム種類
        /// </summary>
        ChecksumType Checksum { get; set; }

        /// <summary>
        /// 文字サイズ、コードサイズ
        /// </summary>
        ICharacterSize CharSize { get; set; }

        /// <summary>
        /// フィールディング文字列   OCRだけでは?
        /// </summary>
        string FieldString { get; set; }

        /// <summary>
        /// フィールド文字定義
        /// </summary>
        string FieldDef { get; set; }

        /// <summary>
        /// IDの前景色
        /// </summary>
        MarkColor Color { get; set; }

        /// <summary>
        /// アクセプトしきい値
        /// </summary>
        int AcceptThreshold { get; set; }

        /// <summary>
        /// OCR読取り設定
        /// </summary>
        IOCRParameters OCR { get; }
        
        /// <summary>
        /// T7読取り設定
        /// </summary>
        IT7Parameters T7 { get; }
        
        /// <summary>
        /// QR読取り設定
        /// </summary>
        IQRCodeParameters QR { get; }
        
        /// <summary>
        /// DataMatrix読取り設定
        /// </summary>
        IDataMatrixParameters DM { get; }

        /// <summary>
        /// バーコード読取り設定
        /// </summary>
        IBarcodeParameters Barcode { get; }

        // TODO: LatestResultはReadSettingsのメンバーではないのでは?

        IReadResult LatestResult { get; set; }
    }

}
