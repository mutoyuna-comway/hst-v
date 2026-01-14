using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// バーコード読取り設定
    /// </summary>
    public interface IBarcodeParameters : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// バーコード認識モード
        /// </summary>
        BarcodeOperationMode Operation { get; set; }

        /// <summary>
        /// フィールド文字列の無効化
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        bool DisableFieldString { get; set; }

        /// <summary>
        /// チェックサムの無効化
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        bool DisableChecksum { get; set; }

        /// <summary>
        /// 色指定の無効化
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        bool DisableColorSpecified { get; set; }

        /// <summary>
        /// シンボル指定の無効化
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        bool DisableSymbolSpecified { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        void CopyFrom(IBarcodeParameters src);
    }


}
