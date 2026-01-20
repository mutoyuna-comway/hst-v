using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubILumpLogOutput : ILumpLogOutput
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubILumpLogOutput() { }
        //public ILumpLogElement AllImage { get; set; } = new StubILumpLogElement();
        private ILumpLogElement _allImage = new StubILumpLogElement();
        public ILumpLogElement AllImage
        {
            get => _allImage;
            set
            {
                _allImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllImage)));
            }
        }
        //public ILumpLogElement FailImage { get; set; } = new StubILumpLogElement();
        private ILumpLogElement _failImage = new StubILumpLogElement();
        public ILumpLogElement FailImage
        {
            get => _failImage;
            set
            {
                _failImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FailImage)));
            }
        }
        //public ILumpLogElement JobData { get; set; } = new StubILumpLogElement();
        private ILumpLogElement _jobData = new StubILumpLogElement();
        public ILumpLogElement JobData
        {
            get => _jobData;
            set
            {
                _jobData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JobData)));
            }
        }
        //public ILumpLogElement LogData { get; set; } = new StubILumpLogElement();
        private ILumpLogElement _logData = new StubILumpLogElement();
        public ILumpLogElement LogData
        {
            get => _logData;
            set
            {
                _logData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogData)));
            }
        }
        //public ILumpLogElement ConfData { get; set; } = new StubILumpLogElement();
        private ILumpLogElement _confData = new StubILumpLogElement();
        public ILumpLogElement ConfData
        {
            get => _confData;
            set
            {
                _confData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfData)));
            }
        }
        //public ILumpLogElement PCInfo { get; set; } = new StubILumpLogElement();
        private ILumpLogElement _pcInfo = new StubILumpLogElement();
        public ILumpLogElement PCInfo
        {
            get => _pcInfo;
            set
            {
                _pcInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PCInfo)));
            }
        }
        //public ILumpLogElement SelfDiagnosisInfo { get; set; } = new StubILumpLogElement();
        private ILumpLogElement _selfDiagnosisInfo = new StubILumpLogElement();
        public ILumpLogElement SelfDiagnosisInfo
        {
            get => _selfDiagnosisInfo;
            set
            {
                _selfDiagnosisInfo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelfDiagnosisInfo)));
            }
        }
        //public int SizeOfDevidedLog { get; set; }
        private int _sizeOfDevidedLog;
        public int SizeOfDevidedLog
        {
            get => _sizeOfDevidedLog;
            set
            {
                _sizeOfDevidedLog = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SizeOfDevidedLog)));
            }
        }

    }

    public class StubILumpLogElement : ILumpLogElement
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubILumpLogElement() { }
        //public bool IsSave { get; set; }
        private bool _isSave;
        public bool IsSave
        {
            get => _isSave;
            set
            {
                _isSave = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSave)));
            }
        }
        //public bool IsFromDate { get; set; }
        private bool _isFromDate;
        public bool IsFromDate
        {
            get => _isFromDate;
            set
            {
                _isFromDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFromDate)));
            }
        }
        //public DateTime FromDate { get; set; }
        private DateTime _fromDate;
        public DateTime FromDate
        {
            get => _fromDate;
            set
            {
                _fromDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FromDate)));
            }
        }
        //public bool IsFileNum { get; set; }
        private bool _isFileNum;
        public bool IsFileNum
        {
            get => _isFileNum;
            set
            {
                _isFileNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFileNum)));
            }
        }
        //public int SaveFileNum { get; set; }
        private int _SaveFileNum;
        public int SaveFileNum
        {
            get => _SaveFileNum;
            set
            {
                _SaveFileNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SaveFileNum)));
            }
        }
        //public long FileNum { get; set; }
        private long _fileNum;
        public long FileNum
        {
            get => _fileNum;
            set
            {
                _fileNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileNum)));
            }
        }
        //public long FileSize { get; set; }
        private long _fileSize;
        public long FileSize
        {
            get => _fileSize;
            set
            {
                _fileSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileSize)));
            }
        }
        //public List<String> FileList { get; set; }
        private List<String> _fileList;
        public List<String> FileList
        {
            get => _fileList;
            set
            {
                _fileList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FileList)));
            }
        }

    }
}
