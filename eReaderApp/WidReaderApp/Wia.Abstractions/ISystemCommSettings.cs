using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// 通信設定
    /// </summary>
    public interface ISystemCommSettings : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// デリミタ設定
        /// </summary>
        DelimeterType Delimeter { get; set; }

        /// <summary>
        /// 通信設定
        /// </summary>
        CommunicatorType CommType { get; set; }

        /// <summary>
        /// ソケット通信設定
        /// </summary>
        ISocketSettings Socket { get; set; }

        /// <summary>
        /// シリアル通信設定
        /// </summary>
        ISerialSettings Serial { get; set; }

        /// <summary>
        /// コマンド応答
        /// </summary>
        IDictionary<string, IWaitResponse> Response { get; set; }
}
}
