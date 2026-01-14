using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// 画像取込み
    /// </summary>
    public interface IImageSource
    {

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        IAcquireResult AcquireImage(IJobAcqSettings prms);

    }
}
