using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
    public class StubIJobAcqSettings : IJobAcqSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubIJobAcqSettings() { }
        //public ImageOrient AcqOrient { get; set; }
        private ImageOrient _acqOrient;
        public ImageOrient AcqOrient
        {
            get => _acqOrient;
            set
            {
                _acqOrient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqOrient)));
            }
        }
        //public IRegion WOI { get; set; } = new StubIRegion();
        private IRegion _woi = new StubIRegion();
        public IRegion WOI
        {
            get => _woi;
            set
            {
                _woi = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WOI)));
            }
        }
        //public int Gain { get; set; }
        private int _gain;
        public int Gain
        {
            get => _gain;
            set
            {
                _gain = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Gain)));
            }
        }
        //public int Exposure { get; set; }
        private int _exposure;
        public int Exposure
        {
            get => _exposure;
            set
            {
                _exposure = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Exposure)));
            }
        }
        //public double Rotate { get; set; }
        private double _rotate;
        public double Rotate
        {
            get => _rotate;
            set
            {
                _rotate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rotate)));
            }
        }
        //public FilterType AcqFilter { get; set; }
        private FilterType _acqFilter;
        public FilterType AcqFilter
        {
            get => _acqFilter;
            set
            {
                _acqFilter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqFilter)));
            }
        }
        //public int AcqFilterSize { get; set; }
        private int _acqFilterSize;
        public int AcqFilterSize
        {
            get => _acqFilterSize;
            set
            {
                _acqFilterSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqFilterSize)));
            }
        }
        //public MarkColor AcqFilterColor { get; set; }
        private MarkColor _acqFilterColor;
        public MarkColor AcqFilterColor
        {
            get => _acqFilterColor;
            set
            {
                _acqFilterColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqFilterColor)));
            }
        }
        //public int AcqFilterIteration { get; set; }
        private int _acqFilterIteration;
        public int AcqFilterIteration
        {
            get => _acqFilterIteration;
            set
            {
                _acqFilterIteration = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqFilterIteration)));
            }
        }
        //public AcquireMethod AcqMode { get; set; }
        private AcquireMethod _acqMode;
        public AcquireMethod AcqMode
        {
            get => _acqMode;
            set
            {
                _acqMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AcqMode)));
            }
        }
        //public ILightConfig SelectedLightConfig { get; set; } = new StubILightConfig();
        private ILightConfig _selectedLightConfig = new StubILightConfig();
        public ILightConfig SelectedLightConfig
        {
            get => _selectedLightConfig;
            set
            {
                _selectedLightConfig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedLightConfig)));
            }
        }
        //public int SelectedLightConfigIndex { get; set; }
        private int _selectedLightConfigIndex;
        public int SelectedLightConfigIndex
        {
            get => _selectedLightConfigIndex;
            set
            {
                _selectedLightConfigIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedLightConfigIndex)));
            }
        }
        public ILightConfig GetLightConfig(int index) { return null; }
        public void SetCurrentCue(AcquireMethod method, MarkColor color) { }
        
    }
}
