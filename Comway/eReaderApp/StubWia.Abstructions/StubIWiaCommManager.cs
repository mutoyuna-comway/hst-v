using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIWiaCommManager : IWiaCommManager
    {

        public StubIWiaCommManager() { }
        public DelimeterType Delimeter { get; set; }
        public ulong SocketPort { get; set; }
    }
}
