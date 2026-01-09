using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemAcqSettings : ISystemAcqSettings
    {

        public StubISystemAcqSettings() { }
        public int AcquireTimeout { get; set; }
        public bool AutoReconnect { get; set; }
        public ISystemCameraSettings CurrentCameraSetting { get; }

    }
}
