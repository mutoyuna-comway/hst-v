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
        public ICharacterSize CharSize { get; set; }
        public string FieldString { get; set; }
        public string FieldDef { get; set; }
        public MarkColor Color { get; set; }
        public int AcceptThreshold { get; set; }
        public IOCRParameters OCR { get; }
        public IT7Parameters T7 { get; }
        public IQRCodeParameters QR { get; }
        public IDataMatrixParameters DM { get; }
        public IBarcodeParameters Barcode { get; }
        public IReadResult LatestResult { get; set; }

    }
}
