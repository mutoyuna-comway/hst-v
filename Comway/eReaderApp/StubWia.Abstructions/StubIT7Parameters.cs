using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIT7Parameters : IT7Parameters
    {

        public StubIT7Parameters() { }
        public double Timeout { get; set; }
        public int ErrorBit { get; set; }
        public int ErrorNum { get; set; }
        public T7OperationMode Operation { get; set; }
        public void CopyFrom(IT7Parameters src)
        {
            this.Timeout = src.Timeout;
            this.ErrorBit = src.ErrorBit;
            this.ErrorNum = src.ErrorNum;
            this.Operation = src.Operation;
        }
    }
}
