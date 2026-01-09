using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIProcessorSettings : IProcessorSettings
    {
       
        public StubIProcessorSettings() { }
        public ulong AffinityMask { get; set; }
        public ProcessPriorityClass ProcessorPriority { get; set; }
    }
}
