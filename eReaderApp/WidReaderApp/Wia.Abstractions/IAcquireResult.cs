using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    /// <summary>
    /// 画像取込み結果
    /// </summary>
    public interface IAcquireResult
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 撮像設定
        /// </summary>
        IJobAcqSettings AcqParams { get; }

        /// <summary>
        /// 撮像時間
        /// </summary>
        double ElapsedAcqTime { get; }

        /// <summary>
        /// 処理時間
        /// </summary>
        double ElapsedProcTime { get; }

        /// <summary>
        /// 処理画像(フィルタ適用画像)
        /// </summary>
        IImage ProcessImage { get; }

        /// <summary>
        /// 表示画像(回転まで適用)
        /// </summary>
        IImage DisplayImage { get; }

        /// <summary>
        /// 取込成否
        /// </summary>
        bool AcqSucceed { get; }


    }
}
