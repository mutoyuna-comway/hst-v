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
        /// 照明数を返す
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 照明データの列挙
        /// </summary>
        IEnumerable<ILightData> LightItems { get; }

        /// <summary>
        /// 照明データのインデックス参照
        /// </summary>

        ILightData this[int key] { get; }

        /// <summary>
        /// 照明構成番号
        /// </summary>
        int LightConfigID { get; set; }

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
    }

    /// <summary>
    /// 照明データ
    /// </summary>
    public interface ILightData : INotifyPropertyChanged
    {

        /// <summary>
        /// 照明番号
        /// </summary>
        int LightNumber { get; }

        /// <summary>
        /// 照明の有効/無効
        /// </summary>
        bool Available { get; set; }

        /// <summary>
        /// 照明強度[0-255]
        /// </summary>
        int Power { get; set; }
    }
}
