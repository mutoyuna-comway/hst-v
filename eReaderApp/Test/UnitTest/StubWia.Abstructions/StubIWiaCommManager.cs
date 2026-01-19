using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIWiaCommManager : IWiaCommManager
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubIWiaCommManager() { }
        //public DelimeterType Delimeter { get; set; }
        private DelimeterType _delimeter;
        public DelimeterType Delimeter
        {
            get => _delimeter;
            set
            {
                _delimeter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Delimeter)));
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
    }
}
