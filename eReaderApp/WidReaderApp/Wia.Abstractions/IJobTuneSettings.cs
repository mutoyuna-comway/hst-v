using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// チューニング設定
    /// </summary>
    public interface IJobTuneSettings
    {
        /// <summary>
        /// 適合文字列
        /// </summary>
        string MatchString { get; set; }

        /// <summary>
        /// チューンモード、比較するものがスコアの平均値か最低値を指定する
        /// </summary>
        TuneSelectMode TuneMode { get; set; }

        /// <summary>
        /// チューンスキャニングモード
        /// </summary>
        TuneScanningMode TuneScanMode { get; set; }

        /// <summary>
        /// 照明の有効可否
        /// </summary>
        bool LightEnable { get; set; }

        /// <summary>
        /// 照明幅
        /// </summary>
        int LightRange { get; set; }

        /// <summary>
        /// 照明の最小値
        /// </summary>
        int LightMinimum { get; set; }

        /// <summary>
        /// 照明の最大値
        /// </summary>
        int LightMaximum { get; set; }

        /// <summary>
        /// サイズ有効可否
        /// </summary>
        bool SizeEnable { get; set; }

        /// <summary>
        /// 文字/マーク幅範囲
        /// </summary>
        int WidthRange { get; set; }

        /// <summary>
        /// 文字/マーク高さ範囲
        /// </summary>
        int HeightRange { get; set; }

        /// <summary>
        /// マーク色有効可否
        /// </summary>
        bool ColorEnable { get; set; }

        /// <summary>
        /// 前処理有効可否
        /// </summary>
        bool PreprocessEnable { get; set; }

        /// <summary>
        /// 内部フィルタ有効可否
        /// </summary>
        bool InternalFilterEnable { get; set; }

        /// <summary>
        /// 有効な照明
        /// </summary>
        int AvailableLightConfigNum { get; }

        /// <summary>
        /// 現在の照明コンフィグ利用
        /// </summary>
        bool UseCurrentLightConfig { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        bool GetAvailableLightConfigEnable(int index);
        void SetAvailableLightConfigEnable(int index, bool enable);

    }

}
