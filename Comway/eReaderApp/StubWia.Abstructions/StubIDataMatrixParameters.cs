using Wia.Abstractions;

namespace StubWia.Abstructions
{
    public class StubIDataMatrixParameters : IDataMatrixParameters
    {
       
        public StubIDataMatrixParameters() { }

        
        public CharacterLimitationType CharLimit { get; set; }

       
        public int ErrorBitSize { get; set; }

       
        public bool SpecifiedCellNum { get; set; }

       
        public DMGridSize CellNum { get; set; }

       
        public void CopyFrom(IDataMatrixParameters src)
        {
            this.CharLimit = src.CharLimit;
            this.ErrorBitSize = src.ErrorBitSize;
            this.SpecifiedCellNum = src.SpecifiedCellNum;
            this.CellNum = src.CellNum;
        }
    }
}
