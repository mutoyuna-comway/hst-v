using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
    public class StubIAcquireCondition : IAcquireCondition
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // --- Backing Fields ---
        private ImageOrient _orient;
        private double _rotate;
        private ImageSizeMode _sizeMode;
        private ImageExpandRate _expandRate;
        private IRegion _woi;
        private int _exposure;
        private int _gain;
        private ILightConfig _acqLightConfig;

        // --- Properties ---
        public ImageOrient Orient
        {
            get => _orient;
            set
            {
                _orient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Orient)));
            }
        }

        public double Rotate
        {
            get => _rotate;
            set
            {
                _rotate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rotate)));
            }
        }

        public ImageSizeMode SizeMode
        {
            get => _sizeMode;
            set
            {
                _sizeMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SizeMode)));
            }
        }

        public ImageExpandRate ExpandRate
        {
            get => _expandRate;
            set
            {
                _expandRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExpandRate)));
            }
        }

        public IRegion WOI
        {
            get => _woi;
            set
            {
                _woi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WOI)));
            }
        }

        public int Exposure
        {
            get => _exposure;
            set
            {
                _exposure = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Exposure)));
            }
        }

        public int Gain
        {
            get => _gain;
            set
            {
                _gain = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gain)));
            }
        }

        public ILightConfig AcqLightConfig
        {
            get => _acqLightConfig;
            set
            {
                _acqLightConfig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqLightConfig)));
            }
        }

        // --- Methods ---
        public IAcquireCondition Clone()
        {
            return new StubIAcquireCondition
            {
                Orient = this.Orient,
                Rotate = this.Rotate,
                SizeMode = this.SizeMode,
                ExpandRate = this.ExpandRate,
                WOI = this.WOI,
                Exposure = this.Exposure,
                Gain = this.Gain,
                AcqLightConfig = this.AcqLightConfig
            };
        }
    }
}