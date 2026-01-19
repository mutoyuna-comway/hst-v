using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIT7Parameters : IT7Parameters
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubIT7Parameters() { }
        //public double Timeout { get; set; }
        private double _timeout;
        public double Timeout
        {
            get => _timeout;
            set
            {
                _timeout = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Timeout)));
            }
        }
        //public int ErrorBit { get; set; }
        private int _errorBit;
        public int ErrorBit
        {
            get => _errorBit;
            set
            {
                _errorBit = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorBit)));
            }
        }
        //public int ErrorNum { get; set; }
        private int _errorNum;
        public int ErrorNum
        {
            get => _errorNum;
            set
            {
                _errorNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorNum)));
            }
        }
        //public T7OperationMode Operation { get; set; }
        private T7OperationMode _operation;
        public T7OperationMode Operation
        {
            get => _operation;
            set
            {
                _operation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operation)));
            }
        }
        public void CopyFrom(IT7Parameters src)
        {
            this.Timeout = src.Timeout;
            this.ErrorBit = src.ErrorBit;
            this.ErrorNum = src.ErrorNum;
            this.Operation = src.Operation;
        }
    }
}
