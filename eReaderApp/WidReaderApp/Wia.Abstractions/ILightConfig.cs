using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    /// <summary>
    /// 照明コンフィグ
    /// </summary>
    public interface ILightConfig : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 照明構成番号
        /// </summary>
        int LightConfigID { get; }

        /// <summary>
        /// 照明強度
        /// </summary>
        /// <remarks>
        /// 取得は有効なライトの最後の値を返す。
        /// セットは有効なライト全てに値を設定する。
        /// </remarks>
        int LightLevel { get; set; }

        /// <summary>
        /// 反射色
        /// </summary>
        ReflectedColor ReflectedColor { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// 照明強度の取得
        /// </summary>
        /// <returns>照明強度</returns>
        /// <remarks>
        /// CmdEvGetConfigLightPowerで利用するメソッド、照明でチェック入っている中で, 
        /// 場所として一番下のものの値を返す。チェックがない場合は-1を返す。
        /// </remarks>
        int GetLightPower();

        /// <summary>
        /// 照明強度の設定
        /// </summary>
        /// <param name="power">照明強度</param>
        /// <remarks>有効なLight全てに値を指定</remarks>
        void SetLightPower(int power);

        /// <summary>
        /// 照明の数を取得する
        /// </summary>
        /// <returns>照明数</returns>
        int GetLightCount();

        /// <summary>
        /// 個別照明の有効無効の取得
        /// </summary>
        /// <param name="index">照明インデックス番号</param>
        /// <return>true: 有効、false:無効</return>
        bool GetLightEnable(int index);

        /// <summary>
        /// 個別照明の有効無効の設定
        /// </summary>
        /// <param name="index">照明インデックス番号</param>
        /// <param name="enable">true: 有効、false:無効</param>
        void SetLightEnable(int index, bool enable);

        /// <summary>
        /// 個別照明の照明強度の取得
        /// </summary>
        /// <param name="index">照明インデックス番号</param>
        /// <return>照明強度</return>
        int GetLightPower(int index);

        /// <summary>
        /// 個別照明の照明強度の設定
        /// </summary>
        /// <param name="index">照明インデックス番号</param>
        /// <param name="power">照明強度</param>
        void SetLightPower(int index, int power);

        /// <summary>
        /// 個別照明のIDの取得
        /// </summary>
        /// <param name="index">照明インデックス番号</param>
        /// <returns>ID番号</returns>
        int GetLightId(int index);

    }
}
