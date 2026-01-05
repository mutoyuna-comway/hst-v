using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    public interface IProcessorSettings
    {
        /// <summary>
        /// CPU割付
        /// </summary>
         ulong AffinityMask { get; set; }

        /// <summary>
        /// プロセッサの優先度
        /// </summary>
        ProcessPriorityClass ProcessorPriority { get; set; }

    }
}
