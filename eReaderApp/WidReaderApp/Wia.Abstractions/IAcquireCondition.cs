using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// 画像取込み実行条件
    /// </summary>
    public interface IAcquireCondition
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 画像反転方向
        /// </summary>
        ImageOrient Orient { get; }

        /// <summary>
        /// 画像回転
        /// </summary>
        double Rotate { get; }

        /// <summary>
        /// 画像拡大サイズモード設定
        /// </summary>
        ImageSizeMode SizeMode { get; }

        /// <summary>
        /// 画像拡大拡大率
        /// </summary>
        ImageExpandRate ExpandRate { get; }

        /// <summary>
        /// 対象領域
        /// </summary>
        IRegion WOI { get; }

        /// <summary>
        /// 露光時間
        /// </summary>
        int Exposure { get; }
        /// <summary>
        /// ゲイン
        /// </summary>
        int Gain { get; }

        /// <summary>
        /// 照明コンフィグ情報
        /// </summary>
        ILightConfig AcqLightConfig { get; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------
        
        /// <summary>
        /// クローン作成
        /// </summary>
        /// <returns></returns>
        IAcquireCondition Clone();

    }
}
