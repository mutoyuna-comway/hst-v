using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ジョブコンフィグの画像取込み設定
    /// </summary>
    public interface IJobAcqSettings
    {
        /// <summary>
        /// 画像反転モード
        /// </summary>
        ImageOrient AcqOrient { get; set; }

        /// <summary>
        /// 検査領域
        /// </summary>
        IRegion WOI { get; set; }

        /// <summary>
        /// カメラ取込みゲイン
        /// </summary>
        int Gain { get; set; }

        /// <summary>
        /// カメラ取込み露光時間
        /// </summary>
        int Exposure { get; set; }
        
        /// <summary>
        /// 画像回転角度
        /// </summary>
        double Rotate { get; set; }

        /// <summary>
        /// 画像前処理フィルタ種類
        /// </summary>
        FilterType AcqFilter { get; set; }

        /// <summary>
        /// 画像前処理フィルタカーネルサイズ
        /// </summary>
        int AcqFilterSize { get; set; }

        /// <summary>
        /// フィルター極性　(利用目的が不明、現状は未使用と思われる。)
        /// </summary>
        MarkColor AcqFilterColor { get; set; }

        /// <summary>
        /// 反復数
        /// </summary>
        int AcqFilterIteration { get; set; }

        /// <summary>
        /// 画像取込みモード
        /// </summary>
        AcquireMethod AcqMode { get; set; }

        /// <summary>
        /// 現在選択されている照明構成
        /// </summary>
        ILightConfig SelectedLightConfig { get; set; }

        /// <summary>
        /// 現在選択されている照明構成番号
        /// </summary>
        int SelectedLightConfigIndex { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// 照明コンフィグの取得
        /// </summary>
        /// <param name="index">照明コンフィグ番号</param>
        /// <returns>照明コンフィグ</returns>
        ILightConfig GetLightConfig(int index);

        /// <summary>
        /// CurrentCueの設定
        /// </summary>
        /// <param name="method">読取手法</param>
        /// <param name="color">色</param>
        void SetCurrentCue(AcquireMethod method, MarkColor color);
    }
}
