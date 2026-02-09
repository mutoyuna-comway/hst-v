using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubISocketSettings : ISocketSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubISocketSettings() { }
        //public IPAddress HostIPAddress { get; set; }
        private IPAddress _hostIPAddress;
        public IPAddress HostIPAddress
        {
            get => _hostIPAddress;
            set
            {
                _hostIPAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HostIPAddress)));
            }
        }
        //public string HostIPAddressString { get; set; }
        private string _hostIPAddressString;
        public string HostIPAddressString
        {
            get => _hostIPAddressString;
            set
            {
                _hostIPAddressString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HostIPAddressString)));
            }
        }
        //public ulong SocketPort { get; set; }
        private ulong _socketPort;
        public ulong SocketPort
        {
            get => _socketPort;
            set
            {
                _socketPort = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocketPort)));
            }
        }
        //public int SocketBufferSize { get; set; }
        private int _socketBufferSize;
        public int SocketBufferSize
        {
            get => _socketBufferSize;
            set
            {
                _socketBufferSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SocketBufferSize)));
            }
        }

    }
}
