using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
    public class StubIJob : IJob
    {
       
        public StubIJob() { }       
        public ReadMethod ReadType { get; set; }
        public IJobConfig SelectedConfig { get; }
        public int SelectedConfigIndex { get; set; }
        public IEnumerable<IJobConfig> Configs { get; }
        public IJobConfig GetConfig(int index) { return null; }
        public IJobConfig[] GetSortedEnableConfigArray() {  return null; }
        public bool CheckFontIdValidity() { return true; }
        public bool CopyConfig(int srcConfID, int dstConfID) { return true; }
        public bool CheckValidConfigID(int configID) { return true; }
        public bool CheckExistenceConfig(int targetConfig) { return true; }
        public int GetConfigMaxNum() { return 0; }

    }
}
