using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemCommSettings : ISystemCommSettings
    {

        public StubISystemCommSettings() { }
        public DelimeterType Delimeter { get; set; }
        public CommunicatorType CommType { get; set; }
        public ISocketSettings Socket { get; set; } = new StubISocketSettings();
        public ISerialSettings Serial { get; set; } = new StubISerialSettings();
        public IDictionary<string, IWaitResponse> Response { get; set; }
    }
}
