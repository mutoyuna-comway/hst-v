using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    public interface ISerialSettings
    {
        /// <summary>
        /// ボーレート
        /// </summary>

        SerialBaudrate Baudrate { get; set; }

        /// <summary>
        /// データビット
        /// </summary>
        SerialDataBits DataBits { get; set; }

        /// <summary>
        /// ハンドシェイク
        /// </summary>
        SerialHandShake HandShake { get; set; }

        /// <summary>
        /// パリティ
        /// </summary>
        SerialParity Parity { get; set; }

        /// <summary>
        /// ポート
        /// </summary>
        SerialPort Port { get; set; }

        /// <summary>
        /// ストップビット
        /// </summary>
        SerialStopBits StopBits { get; set; }
    }
}
