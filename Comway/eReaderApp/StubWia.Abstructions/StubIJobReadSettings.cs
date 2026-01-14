using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia.Abstructions
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
        public IOCRParameters OCR { get; } = new StubIOCRParameters();
        public IT7Parameters T7 { get; } = new StubIT7Parameters();
        public IQRCodeParameters QR { get; } = new StubIQRCodeParameters();
        public IDataMatrixParameters DM { get; } = new StubIDataMatrixParameters();
        public IBarcodeParameters Barcode { get; }= new StubIBarcodeParameters();
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
