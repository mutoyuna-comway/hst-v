using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubILumpLogOutput : ILumpLogOutput
    {
       
        public StubILumpLogOutput() { }
        public ILumpLogElement AllImage { get; set; }
        public ILumpLogElement FailImage { get; set; }
        public ILumpLogElement JobData { get; set; }
        public ILumpLogElement LogData { get; set; }
        public ILumpLogElement ConfData { get; set; }
        public ILumpLogElement PCInfo { get; set; }
        public ILumpLogElement SelfDiagnosisInfo { get; set; }
        public int SizeOfDevidedLog { get; set; }

    }

    public class StuILumpLogElement : ILumpLogElement
    {

        public StuILumpLogElement() { }
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
