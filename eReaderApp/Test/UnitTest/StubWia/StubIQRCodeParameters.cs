using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubIQRCodeParameters : IQRCodeParameters
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIQRCodeParameters() { }
        //public CharacterLimitationType CharLimit { get; set; }
        private CharacterLimitationType _charLimit;
        public CharacterLimitationType CharLimit
        {
            get => _charLimit;
            set
            {
                _charLimit = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CharLimit)));
            }
        }
        //public int ErrorBitSize { get; set; }
        private int _errorBitSize;
        public int ErrorBitSize
        {
            get => _errorBitSize;
            set
            {
                _errorBitSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorBitSize)));
            }
        }
        //public bool SpecifiedGrids { get; set; }
        private bool _specifiedGrids;
        public bool SpecifiedGrids
        {
            get => _specifiedGrids;
            set
            {
                _specifiedGrids = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecifiedGrids)));
            }
        }
        //public QRGridSize Grid { get; set; }
        private QRGridSize _grid;
        public QRGridSize Grid
        {
            get => _grid;
            set
            {
                _grid = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Grid)));
            }
        }
        public void CopyFrom(IQRCodeParameters src) {
            this.CharLimit = src.CharLimit;
            this.ErrorBitSize = src.ErrorBitSize;
            this.SpecifiedGrids = src.SpecifiedGrids;
            this.Grid = src.Grid;
        }
    }
}
