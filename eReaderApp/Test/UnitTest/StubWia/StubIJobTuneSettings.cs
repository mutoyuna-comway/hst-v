using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{

    public class StubIJobTuneSettings : IJobTuneSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIJobTuneSettings() {
            AvailableLightConfigNum = 1;
        }
        //public string MatchString { get; set; }
        private string _matchString;
        public string MatchString
        {
            get => _matchString;
            set
            {
                _matchString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MatchString)));
            }
        }
        //public TuneSelectMode TuneMode { get; set; }
        private TuneSelectMode _tuneMode;
        public TuneSelectMode TuneMode
        {
            get => _tuneMode;
            set
            {
                _tuneMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneMode)));
            }
        }
        //public ICharacterSize CharSize { get; set; } = new StubICharacterSize();
        private ICharacterSize _charSize = new StubICharacterSize();
        public ICharacterSize CharSize
        {
            get => _charSize;
            set
            {
                _charSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CharSize)));
            }
        }
        //public TuneScanningMode TuneScanMode { get; set; }
        private TuneScanningMode _tuneScanMode;
        public TuneScanningMode TuneScanMode
        {
            get => _tuneScanMode;
            set
            {
                _tuneScanMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TuneScanMode)));
            }
        }
        //public bool LightEnable { get; set; }
        private bool _lightEnable;
        public bool LightEnable
        {
            get => _lightEnable;
            set
            {
                _lightEnable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightEnable)));
            }
        }
        //public int LightRange { get; set; }
        private int _lightRange;
        public int LightRange
        {
            get => _lightRange;
            set
            {
                _lightRange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightRange)));
            }
        }
        //public int LightMinimum { get; set; }
        private int _lightMinimum;
        public int LightMinimum
        {
            get => _lightMinimum;
            set
            {
                _lightMinimum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightMinimum)));
            }
        }
        //public int LightMaximum { get; set; }
        private int _lightMaximum;
        public int LightMaximum
        {
            get => _lightMaximum;
            set
            {
                _lightMaximum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightMaximum)));
            }
        }
        //public bool SizeEnable { get; set; }
        private bool _sizeEnable;
        public bool SizeEnable
        {
            get => _sizeEnable;
            set
            {
                _sizeEnable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SizeEnable)));
            }
        }
        //public int WidthRange { get; set; }
        private int _widthRange;
        public int WidthRange
        {
            get => _widthRange;
            set
            {
                _widthRange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WidthRange)));
            }
        }
        //public int HeightRange { get; set; }
        private int _heightRange;
        public int HeightRange
        {
            get => _heightRange;
            set
            {
                _heightRange = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HeightRange)));
            }
        }
        //public bool ColorEnable { get; set; }
        private bool _colorEnable;
        public bool ColorEnable
        {
            get => _colorEnable;
            set
            {
                _colorEnable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ColorEnable)));
            }
        }
        //public bool PreprocessEnable { get; set; }
        private bool _preprocessEnable;
        public bool PreprocessEnable
        {
            get => _preprocessEnable;
            set
            {
                _preprocessEnable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PreprocessEnable)));
            }
        }
        //public bool InternalFilterEnable { get; set; }
        private bool _internalFilterEnable;
        public bool InternalFilterEnable
        {
            get => _internalFilterEnable;
            set
            {
                _internalFilterEnable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InternalFilterEnable)));
            }
        }
        private int _availableLightConfigNum;
        public int AvailableLightConfigNum {
            get { return this._availableLightConfigNum; }
            private set
            {
                this._availableLightConfigNum = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AvailableLightConfigNum)));
            }
        }
        //public bool UseCurrentLightConfig { get; set; }
        private bool _useCurrentLightConfig;
        public bool UseCurrentLightConfig
        {
            get => _useCurrentLightConfig;
            set
            {
                _useCurrentLightConfig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UseCurrentLightConfig)));
            }
        }
        public bool GetAvailableLightConfigEnable(int index) { return true; }
        public void SetAvailableLightConfigEnable(int index, bool enable) { }

    }
}
