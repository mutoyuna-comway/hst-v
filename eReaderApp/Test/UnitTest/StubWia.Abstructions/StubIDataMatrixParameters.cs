using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
    public class StubIDataMatrixParameters : IDataMatrixParameters
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIDataMatrixParameters() { }

        
        //public CharacterLimitationType CharLimit { get; set; }
        private CharacterLimitationType _charLimit;
        public CharacterLimitationType CharLimit
        {
            get => _charLimit;
            set
            {
                _charLimit = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CharLimit)));
            }
        }


        //public int ErrorBitSize { get; set; }
        private int _errorBitSize;
        public int ErrorBitSize
        {
            get => _errorBitSize;
            set
            {
                _errorBitSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorBitSize)));
            }
        }


        //public bool SpecifiedCellNum { get; set; }
        private bool _specifiedCellNum;
        public bool SpecifiedCellNum
        {
            get => _specifiedCellNum;
            set
            {
                _specifiedCellNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SpecifiedCellNum)));
            }
        }


        //public DMGridSize CellNum { get; set; }
        private DMGridSize _cellNum;
        public DMGridSize CellNum
        {
            get => _cellNum;
            set
            {
                _cellNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CellNum)));
            }
        }


        public void CopyFrom(IDataMatrixParameters src)
        {
            this.CharLimit = src.CharLimit;
            this.ErrorBitSize = src.ErrorBitSize;
            this.SpecifiedCellNum = src.SpecifiedCellNum;
            this.CellNum = src.CellNum;
        }
    }
}
