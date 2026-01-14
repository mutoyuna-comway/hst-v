using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// QRコード読取り設定
    /// </summary>
    public interface IQRCodeParameters : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 文字制限
        /// </summary>
        CharacterLimitationType CharLimit { get; set; }

        /// <summary>
        /// エラービット数[1-10]アクセプトしきい値
        /// </summary>
        int ErrorBitSize { get; set; }

        /// <summary>
        /// グリッド指定の有無
        /// </summary>
        bool SpecifiedGrids { get; set; }

        /// <summary>
        /// グリッド指定
        /// </summary>
        QRGridSize Grid { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        void CopyFrom(IQRCodeParameters src);
    }
}
