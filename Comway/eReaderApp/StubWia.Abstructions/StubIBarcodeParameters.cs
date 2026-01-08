using Wia.Abstractions;

namespace StubWia.Abstructions
{
    /// <summary>
    /// バーコード読取り設定スタブ
    /// </summary>
    public class StubIBarcodeParameters : IBarcodeParameters
    {
        /// <summary>
        /// コンストラクタスタブ
        /// </summary>
        public StubIBarcodeParameters() { }

        /// <summary>
        /// バーコード認識モードスタブ
        /// </summary>
        public BarcodeOperationMode Operation { get; set; }

        /// <summary>
        /// フィールド文字列の無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        public bool DisableFieldString { get; set; }

        /// <summary>
        /// チェックサムの無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        public bool DisableChecksum { get; set; }

        /// <summary>
        /// 色指定の無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        public bool DisableColorSpecified { get; set; }

        /// <summary>
        /// シンボル指定の無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        public bool DisableSymbolSpecified { get; set; }

        /// <summary>
        /// コピー機能スタブ
        /// </summary>
        public void CopyFrom(IBarcodeParameters src)
        {
            this.Operation = src.Operation;
            this.DisableFieldString = src.DisableFieldString;
            this.DisableChecksum = src.DisableChecksum;
            this.DisableColorSpecified = src.DisableColorSpecified;
            this.DisableSymbolSpecified = src.DisableSymbolSpecified;
        }
    }
}
