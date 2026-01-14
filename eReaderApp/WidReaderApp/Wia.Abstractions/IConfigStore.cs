using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ジョブコンフィグのコレクション
    /// </summary>
    public interface IConfigStore : IEnumerable<IJobConfig>
    {
        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        event EventHandler CollectionChanging;
        event EventHandler CollectionChanged;
    }
}
