using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
    /// <summary>
    /// バーコード読取り設定スタブ
    /// </summary>
    public class StubIBarcodeParameters : IBarcodeParameters
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// コンストラクタスタブ
        /// </summary>
        public StubIBarcodeParameters() { }

        /// <summary>
        /// バーコード認識モードスタブ
        /// </summary>
        //public BarcodeOperationMode Operation { get; set; }
        private BarcodeOperationMode _operation;
        public BarcodeOperationMode Operation
        {
            get => _operation;
            set
            {   
                _operation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Operation)));
            }
        }

        /// <summary>
        /// フィールド文字列の無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        //public bool DisableFieldString { get; set; }
        private bool _disableFieldString;
        public bool DisableFieldString
        {
            get => _disableFieldString;
            set
            {  
                _disableFieldString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisableFieldString)));
            }
        }

        /// <summary>
        /// チェックサムの無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        //public bool DisableChecksum { get; set; }
        private bool _disableChecksum;
        public bool DisableChecksum
        {
            get => _disableChecksum;
            set
            {
                _disableChecksum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisableChecksum)));
            }
        }

        /// <summary>
        /// 色指定の無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        //public bool DisableColorSpecified { get; set; }
        private bool _disableColorSpecified;
        public bool DisableColorSpecified
        {
            get => _disableColorSpecified;
            set
            {
                _disableChecksum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisableColorSpecified)));
            }
        }

        /// <summary>
        /// シンボル指定の無効化スタブ
        /// </summary>
        /// <remarks>シリアライズしない</remarks>
        //public bool DisableSymbolSpecified { get; set; }
        private bool _disableSymbolSpecified;
        public bool DisableSymbolSpecified
        {
            get => _disableSymbolSpecified;
            set
            {
                _disableColorSpecified = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisableSymbolSpecified)));
            }
        }

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
