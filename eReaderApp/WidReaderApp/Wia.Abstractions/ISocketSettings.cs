using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ソケット通信設定
    /// </summary>
    public interface ISocketSettings : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// ホストのIPアドレス
        /// </summary>
        IPAddress HostIPAddress { get; set; }

        /// <summary>
        /// ホストのIPアドレス
        /// </summary>
        string HostIPAddressString { get; set; }

        /// <summary>
        /// ソケットポート
        /// </summary>
        ulong SocketPort { get; set; }

        /// <summary>
        /// ソケットバッファサイズ
        /// </summary>
        int SocketBufferSize { get; set; }
    }
}
