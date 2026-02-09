using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{

    public class StubIJobReadSettings : IJobReadSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIJobReadSettings() { }
        //public MarkType Mark { get; set; }
        private MarkType _mark;
        public MarkType Mark
        {
            get => _mark;
            set
            {
                _mark = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mark)));
            }
        }
        //public ChecksumType Checksum { get; set; }
        private ChecksumType _checksum;
        public ChecksumType Checksum
        {
            get => _checksum;
            set
            {
                _checksum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Checksum)));
            }
        }
        //public ICharacterSize CharSize { get; set; } = new StubICharacterSize();
        private ICharacterSize _charSize = new StubICharacterSize();
        public ICharacterSize CharSize
        {
            get => _charSize;
            set
            {
                _charSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CharSize)));
            }
        }
        //public string FieldString { get; set; }
        private string _fieldString;
        public string FieldString
        {
            get => _fieldString;
            set
            {
                _fieldString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FieldString)));
            }
        }
        //public string FieldDef { get; set; }
        private string _fieldDef;
        public string FieldDef
        {
            get => _fieldDef;
            set
            {
                _fieldDef = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FieldDef)));
            }
        }
        //public MarkColor Color { get; set; }
        private MarkColor _color;
        public MarkColor Color
        {
            get => _color;
            set
            {
                _color = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }
        //public int AcceptThreshold { get; set; }
        private int _acceptThreshold;
        public int AcceptThreshold
        {
            get => _acceptThreshold;
            set
            {
                _acceptThreshold = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcceptThreshold)));
            }
        }
        private IOCRParameters _oCR = new StubIOCRParameters();
        public IOCRParameters OCR {
            get { return this._oCR; }
            private set
            {
                this._oCR = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OCR)));
            }
        }
        private IT7Parameters _t7 = new StubIT7Parameters();
        public IT7Parameters T7 {
            get { return this._t7; }
            private set
            {
                this._t7 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(T7)));
            }
        }
        private IQRCodeParameters _qR = new StubIQRCodeParameters();
        public IQRCodeParameters QR {
            get { return this._qR; }
            private set
            {
                this._qR = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(QR)));
            }
        }
        private IDataMatrixParameters _dM = new StubIDataMatrixParameters();
        public IDataMatrixParameters DM {
            get { return this._dM; }
            private set
            {
                this._dM = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DM)));
            }
        }
        private IBarcodeParameters _barcode = new StubIBarcodeParameters();
        public IBarcodeParameters Barcode {
            get { return this._barcode; }
            private set
            {
                this._barcode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Barcode)));
            }
        }
        //public IReadResult LatestResult { get; set; }= new StubIReadResult();
        private IReadResult _latestResult = new StubIReadResult();
        public IReadResult LatestResult
        {
            get => _latestResult;
            set
            {
                _latestResult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LatestResult)));
            }
        }

    }
}
