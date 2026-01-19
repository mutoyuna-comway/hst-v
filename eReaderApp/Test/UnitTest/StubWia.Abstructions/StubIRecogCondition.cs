using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIRecogCondition : IRecogCondition
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubIRecogCondition() { }
        //public int ConfigId { get; set; }
        private int _configId;
        public int ConfigId
        {
            get => _configId;
            set
            {
                _configId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConfigId)));
            }
        }
        public bool Initialize(string paramString) { return true; }
        public void ReflectConfig(IJobConfig config) { }
      
    }
}
