using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// データマトリックスコードの読取り設定
    /// </summary>
    public interface IDataMatrixParameters : INotifyPropertyChanged
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
        /// ErrorBitSizeエラービット数
        /// </summary>
        int ErrorBitSize { get; set; }

        /// <summary>
        /// セル数指定
        /// </summary>
        bool SpecifiedCellNum { get; set; }

        /// <summary>
        /// DMセル数
        /// </summary>
        DMGridSize CellNum { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        void CopyFrom(IDataMatrixParameters src);
    }
}
