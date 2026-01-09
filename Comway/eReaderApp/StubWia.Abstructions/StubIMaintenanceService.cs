using System;
using System.Collections.Generic;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIMaintenanceService : IMaintenanceService
    {
       
        public StubIMaintenanceService() { }
        public string SelfDiagnosisProcess { get; set; }
        public string CreatePCInfoProcess { get; set; }
        public string LogSaveZipDataProcess { get; set; }
        public void CreatePCInfo(ICameraInfo camInfo, CancellationToken token) { }
        public void LogCalculateInitialize() { }
        public int LogSaveZipData(CancellationToken token, string saveDirName) {  return 0; }
        public bool RunSelfDiagnosis(CancellationToken token, ref String outputString, Dictionary<string, string> retDic) { return true; }
        public void LogCalculateAllImage(bool isNum, int fileNum, DateTime date) { }
        public void LogCalculateFailImage(bool isNum, int fileNum, DateTime date) { }
        public long LogCalculateSum() { return 0; }
    }
}
