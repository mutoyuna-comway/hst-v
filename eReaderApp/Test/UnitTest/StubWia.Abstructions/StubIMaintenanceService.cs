using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIMaintenanceService : IMaintenanceService
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StubIMaintenanceService() { }
        //public string SelfDiagnosisProcess { get; set; }
        private string _selfDiagnosisProcess;
        public string SelfDiagnosisProcess
        {
            get => _selfDiagnosisProcess;
            set
            {
                _selfDiagnosisProcess = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelfDiagnosisProcess)));
            }
        }
        //public string CreatePCInfoProcess { get; set; }
        private string _createPCInfoProcess;
        public string CreatePCInfoProcess
        {
            get => _createPCInfoProcess;
            set
            {
                _createPCInfoProcess = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CreatePCInfoProcess)));
            }
        }
        //public string LogSaveZipDataProcess { get; set; }
        private string _logSaveZipDataProcess;
        public string LogSaveZipDataProcess
        {
            get => _logSaveZipDataProcess;
            set
            {
                _logSaveZipDataProcess = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogSaveZipDataProcess)));
            }
        }
        public void CreatePCInfo(ICameraInfo camInfo, CancellationToken token) { }
        public void LogCalculateInitialize() { }
        public int LogSaveZipData(CancellationToken token, string saveDirName) {  return 0; }
        public bool RunSelfDiagnosis(CancellationToken token, ref String outputString, Dictionary<string, string> retDic) { return true; }
        public void LogCalculateAllImage(bool isNum, int fileNum, DateTime date) { }
        public void LogCalculateFailImage(bool isNum, int fileNum, DateTime date) { }
        public long LogCalculateSum() { return 0; }
    }
}
