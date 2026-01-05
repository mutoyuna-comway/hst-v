using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    public interface ISocketSettings
    {
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
