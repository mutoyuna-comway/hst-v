using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISocketSettings : ISocketSettings
    {

        public StubISocketSettings() { }
        public IPAddress HostIPAddress { get; set; }
        public string HostIPAddressString { get; set; }
        public ulong SocketPort { get; set; }
        public int SocketBufferSize { get; set; }

    }
}
