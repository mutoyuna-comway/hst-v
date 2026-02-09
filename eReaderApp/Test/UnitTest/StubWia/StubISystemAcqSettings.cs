using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
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
        private ISystemCameraSettings _currentCameraSetting = new StubISystemCameraSettings();
        public ISystemCameraSettings CurrentCameraSetting {
            get { return this._currentCameraSetting; }
            private set
            {
                this._currentCameraSetting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentCameraSetting)));
            }
        }

    }
}
