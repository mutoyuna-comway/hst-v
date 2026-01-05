using System;
using System.Collections.Generic;

namespace Wia.Abstractions
{
    /// <summary>
    /// カメラインターフェース
    /// </summary>
    public interface ILightContloler : IDisposable
    {
        /// <summary>
        /// 初期化
        /// </summary>
        void Initialize();

        /// <summary>
        /// 照明点灯
        /// </summary>
        /// <param name="lc">照明構成</param>
        /// <param name="expString">返答文字列</param>
        /// <returns>実行可否</returns>
        bool LightOn(ILightConfig lc, out String expString);

        /// <summary>
        /// 消灯
        /// </summary>
        /// <param name="expString">返答文字列</param>
        /// <returns>実行可否</returns>
        bool LightOff(out String expString);

        /// <summary>
        /// モジュール名の取得
        /// </summary>
        /// <returns>モジュール名</returns>
        String GetModuleName();

        /// <summary>
        /// 照明数の取得
        /// </summary>
        /// <returns>照明数</returns>
        int GetLightNum();

        /// <summary>
        /// 照明の表示名
        /// </summary>
        /// <returns>照明表示名</returns>
        List<String> LightDisplayName();
    }

}
