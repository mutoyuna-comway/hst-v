using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISerialSettings : ISerialSettings
    {

        public StubISerialSettings() { }
        public SerialBaudrate Baudrate { get; set; }
        public SerialDataBits DataBits { get; set; }
        public SerialHandShake HandShake { get; set; }
        public SerialParity Parity { get; set; }
        public SerialPort Port { get; set; }
        public SerialStopBits StopBits { get; set; }
    }
}
