using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemAcqSettings : ISystemAcqSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubISystemAcqSettings() { }
        //public int AcquireTimeout { get; set; }
        private int _acquireTimeout;
        public int AcquireTimeout
        {
            get => _acquireTimeout;
            set
            {
                _acquireTimeout = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcquireTimeout)));
            }
        }
        //public bool AutoReconnect { get; set; }
        private bool _autoReconnect;
        public bool AutoReconnect
        {
            get => _autoReconnect;
            set
            {
                _autoReconnect = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AutoReconnect)));
            }
        }
        public ISystemCameraSettings CurrentCameraSetting { get; } = new StubISystemCameraSettings();

    }
}
