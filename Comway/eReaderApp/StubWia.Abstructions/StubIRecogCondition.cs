using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIRecogCondition : IRecogCondition
    {

        public StubIRecogCondition() { }
        public int ConfigId { get; set; }
        public bool Initialize(string paramString) { return true; }
        public void ReflectConfig(IJobConfig config) { }
      
    }
}
