using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIQRCodeParameters : IQRCodeParameters
    {

        public StubIQRCodeParameters() { }
        public CharacterLimitationType CharLimit { get; set; }
        public int ErrorBitSize { get; set; }
        public bool SpecifiedGrids { get; set; }
        public QRGridSize Grid { get; set; }
        public void CopyFrom(IQRCodeParameters src) {
            this.CharLimit = src.CharLimit;
            this.ErrorBitSize = src.ErrorBitSize;
            this.SpecifiedGrids = src.SpecifiedGrids;
            this.Grid = src.Grid;
        }
    }
}
