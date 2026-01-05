using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    public interface ILightConfig
    {
        int LightLevel { get; set; }

        ReflectedColor ReflectedColor { get; set; }

        // CmdEvGetConfigLightPowerで利用するメソッド、照明でチェック入っている中で, 場所として一番下のものの値を返す。チェックがない場合は-1を返す。
        int GetLightPower();

        //有効なLight全てに値を指定
        void SetLightPower(int power);

        int GetLightCount();

        void SetLightEnable(int index, bool enable);
        void SetLightPower(int index, int power);
        bool GetLightEnable(int index);
        int GetLightPower(int index);
        int GetLightId(int index);

    }
}
