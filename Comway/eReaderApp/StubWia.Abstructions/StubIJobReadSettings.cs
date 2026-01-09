using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIJobReadSettings : IJobReadSettings
    {
       
        public StubIJobReadSettings() { }       
        public MarkType Mark { get; set; }
        public ChecksumType Checksum { get; set; }
        public ICharacterSize CharSize { get; set; } = new StubICharacterSize();
        public string FieldString { get; set; }
        public string FieldDef { get; set; }
        public MarkColor Color { get; set; }
        public int AcceptThreshold { get; set; }
        public IOCRParameters OCR { get; } = new StubIOCRParameters();
        public IT7Parameters T7 { get; } = new StubIT7Parameters();
        public IQRCodeParameters QR { get; } = new StubIQRCodeParameters();
        public IDataMatrixParameters DM { get; } = new StubIDataMatrixParameters();
        public IBarcodeParameters Barcode { get; }= new StubIBarcodeParameters();
        public IReadResult LatestResult { get; set; }= new StubIReadResult();

    }
}
