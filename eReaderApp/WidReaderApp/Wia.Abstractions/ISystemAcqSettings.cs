using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    public interface ISystemAcqSettings
    {
        /// <summary>
        /// 画像取得タイムアウト時間 ミリ秒単位
        /// </summary>
        int AcquireTimeout { get; set; }

        /// <summary>
        /// 自動再接続
        /// </summary>
        bool AutoReconnect { get; set; }

        /// <summary>
        /// 現在のカメラ設定
        /// </summary>

        ISystemCameraSettings CurrentCameraSetting { get; }
    }
}
