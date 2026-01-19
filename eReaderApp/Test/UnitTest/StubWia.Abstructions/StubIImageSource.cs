using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
    /// <summary>
    /// バーコード読取り設定スタブ
    /// </summary>
    public class StubIImageSource : IImageSource
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// コンストラクタスタブ
        /// </summary>
        public StubIImageSource() { }
        public IAcquireResult AcquireImage(IJobAcqSettings prms) { return null; }



    }
}
