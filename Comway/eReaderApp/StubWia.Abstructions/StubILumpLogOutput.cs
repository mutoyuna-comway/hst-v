using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubILumpLogOutput : ILumpLogOutput
    {
       
        public StubILumpLogOutput() { }
        public ILumpLogElement AllImage { get; set; } = new StubILumpLogElement();
        public ILumpLogElement FailImage { get; set; } = new StubILumpLogElement();
        public ILumpLogElement JobData { get; set; } = new StubILumpLogElement();
        public ILumpLogElement LogData { get; set; } = new StubILumpLogElement();
        public ILumpLogElement ConfData { get; set; } = new StubILumpLogElement();
        public ILumpLogElement PCInfo { get; set; } = new StubILumpLogElement();
        public ILumpLogElement SelfDiagnosisInfo { get; set; } = new StubILumpLogElement();
        public int SizeOfDevidedLog { get; set; }

    }

    public class StubILumpLogElement : ILumpLogElement
    {

        public StubILumpLogElement() { }
        public bool IsSave { get; set; }
        public bool IsFromDate { get; set; }
        public DateTime FromDate { get; set; }
        public bool IsFileNum { get; set; }
        public int SaveFileNum { get; set; }
        public long FileNum { get; set; }
        public long FileSize { get; set; }
        public List<String> FileList { get; set; }

    }
}
