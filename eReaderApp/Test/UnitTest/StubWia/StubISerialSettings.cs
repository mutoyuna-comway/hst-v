using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubISerialSettings : ISerialSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubISerialSettings() { }
        //public SerialBaudrate Baudrate { get; set; }
        private SerialBaudrate _baudrate;
        public SerialBaudrate Baudrate
        {
            get => _baudrate;
            set
            {
                _baudrate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Baudrate)));
            }
        }
        //public SerialDataBits DataBits { get; set; }
        private SerialDataBits _dataBits;
        public SerialDataBits DataBits
        {
            get => _dataBits;
            set
            {
                _dataBits = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataBits)));
            }
        }
        //public SerialHandShake HandShake { get; set; }
        private SerialHandShake _handShake;
        public SerialHandShake HandShake
        {
            get => _handShake;
            set
            {
                _handShake = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HandShake)));
            }
        }
        //public SerialParity Parity { get; set; }
        private SerialParity _parity;
        public SerialParity Parity
        {
            get => _parity;
            set
            {
                _parity = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Parity)));
            }
        }
        //public SerialPort Port { get; set; }
        private SerialPort _port;
        public SerialPort Port
        {
            get => _port;
            set
            {
                _port = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Port)));
            }
        }
        //public SerialStopBits StopBits { get; set; }
        private SerialStopBits _stopBitst;
        public SerialStopBits StopBits
        {
            get => _stopBitst;
            set
            {
                _stopBitst = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StopBits)));
            }
        }
    }
}
