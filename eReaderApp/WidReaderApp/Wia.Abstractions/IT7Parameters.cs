using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// T7読取り設定
    /// </summary>

    public interface IT7Parameters
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// タイムアウト時間(sec.)
        /// </summary>
        double Timeout { get; set; }

        /// <summary>
        /// エラービット数のアクセプトしきい値
        /// </summary>
        int ErrorBit { get; set; }

        /// <summary>
        /// エラー数[1-3]のアクセプトしきい値
        /// </summary>
        int ErrorNum { get; set; }

        /// <summary>
        /// 動作モード
        /// </summary>
        T7OperationMode Operation { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        void CopyFrom(IT7Parameters src);
    }
}
