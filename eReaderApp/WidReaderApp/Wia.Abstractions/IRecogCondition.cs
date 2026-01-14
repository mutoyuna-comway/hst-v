using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    public interface IRecogCondition : INotifyPropertyChanged
    {
        int ConfigId { get; set; }           // 0..49

        bool Initialize(string paramString);

        void ReflectConfig(IJobConfig config);
    }
}
