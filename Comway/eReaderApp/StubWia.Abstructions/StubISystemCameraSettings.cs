using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemCameraSettings : ISystemCameraSettings
    {

        public StubISystemCameraSettings() { }
        public IPAddress CameraIPAddress { get; set; }
        public string CameraIPAddressString { get; set; }
        public bool ConnectToSpecify { get; set; }
        public int PacketDelay { get; set; }
        public int PacketSize { get; set; }
        public string AuthenticationCode { get; set; }
        public bool SendImageToHost { get; set; }
        public string AcqImageSaveFileName { get; set; }
        public string AcqImageSaveFileNameHalf { get; set; }

    }
}
