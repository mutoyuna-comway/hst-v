using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
    
    public class StubIAcquireResult : IAcquireResult
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        public StubIAcquireResult() { }

        private IJobAcqSettings _acqParams = new StubIJobAcqSettings();
        public IJobAcqSettings AcqParams
        {
            get { return this._acqParams; }
            private set
            {
                this._acqParams = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqParams)));
            }
        }
        private double _elapsedAcqTime;
        public double ElapsedAcqTime
        {
            get { return this._elapsedAcqTime; }
            private set
            {
                this._elapsedAcqTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ElapsedAcqTime)));
            }
        }
        private double _elapsedProcTime;
        public double ElapsedProcTime
        {
            get { return this._elapsedProcTime; }
            private set
            {
                this._elapsedProcTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ElapsedProcTime)));
            }
        }
        private IImage _processImage = new StubIImage();
        public IImage ProcessImage
        {
            get { return this._processImage; }
            private set
            {
                this._processImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcessImage)));
            }
        }
        private IImage _displayImage = new StubIImage();
        public IImage DisplayImage
        {
            get { return this._displayImage; }
            private set
            {
                this._displayImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayImage)));
            }
        }
        private bool _acqSucceed;
        public bool AcqSucceed
        {
            get { return this._acqSucceed; }
            private set
            {
                this._acqSucceed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqSucceed)));
            }
        }

    }
}
