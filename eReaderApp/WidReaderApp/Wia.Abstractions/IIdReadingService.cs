using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ID読取り管理
    /// </summary>
    public interface IIdReadingService
    {
        /// <summary>
        /// 現在の構成で初期化する
        /// </summary>
        void Initialize();
    }
}
