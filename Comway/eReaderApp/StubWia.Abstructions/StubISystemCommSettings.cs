using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemCommSettings : ISystemCommSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubISystemCommSettings() { }
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
        //public CommunicatorType CommType { get; set; }
        private CommunicatorType _commType;
        public CommunicatorType CommType
        {
            get => _commType;
            set
            {
                _commType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CommType)));
            }
        }
        //public ISocketSettings Socket { get; set; } = new StubISocketSettings();
        private ISocketSettings _socket = new StubISocketSettings();
        public ISocketSettings Socket
        {
            get => _socket;
            set
            {
                _socket = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Socket)));
            }
        }
        //public ISerialSettings Serial { get; set; } = new StubISerialSettings();
        private ISerialSettings _serial = new StubISerialSettings();
        public ISerialSettings Serial
        {
            get => _serial;
            set
            {
                _serial = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Serial)));
            }
        }
        //public IDictionary<string, IWaitResponse> Response { get; set; }
        private IDictionary<string, IWaitResponse> _response;
        public IDictionary<string, IWaitResponse> Response
        {
            get => _response;
            set
            {
                _response = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Response)));
            }
        }
    }
}
