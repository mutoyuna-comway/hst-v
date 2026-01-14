using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIProcessorSettings : IProcessorSettings
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubIProcessorSettings() { }
        //public ulong AffinityMask { get; set; }
        private ulong _affinityMask;
        public ulong AffinityMask
        {
            get => _affinityMask;
            set
            {
                _affinityMask = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AffinityMask)));
            }
        }
        //public ProcessPriorityClass ProcessorPriority { get; set; }
        private ProcessPriorityClass _processorPriority;
        public ProcessPriorityClass ProcessorPriority
        {
            get => _processorPriority;
            set
            {
                _processorPriority = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcessorPriority)));
            }
        }
    }
}
