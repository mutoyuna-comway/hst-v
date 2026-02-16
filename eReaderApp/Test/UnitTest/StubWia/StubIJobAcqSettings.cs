using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
    public class StubIJobAcqSettings : IJobAcqSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // 照明強度変更通知用のイベント
        public event EventHandler SelectedLightPowerChaneged;

        public StubIJobAcqSettings() { }

        // --- Backing Fields ---
        private ImageOrient _acqOrient;
        private IRegion _woi = new StubIRegion();
        private int _gain;
        private int _exposure;
        private double _rotate;
        private ImageSizeMode _sizeMode;
        private ImageExpandRate _expandRate;
        private FilterType _acqFilterType;
        private int _acqFilterSize;
        private MarkColor _acqFilterColor;
        private int _acqFilterIteration;
        private AcquireMethod _acqMode;
        private ILightConfig _selectedLightConfig = new StubILightConfig();
        private int _selectedLightConfigIndex;

        // ライト設定を保持するための内部リスト（Get/SetLightConfig用）
        private Dictionary<int, ILightConfig> _lightConfigs = new Dictionary<int, ILightConfig>();
        // 特殊モード用ライト設定
        private Dictionary<AcquireMethod, ILightConfig> _specialLightConfigs = new Dictionary<AcquireMethod, ILightConfig>();

        // --- Properties ---
        public ImageOrient AcqOrient
        {
            get => _acqOrient;
            set { _acqOrient = value; OnPropertyChanged(nameof(AcqOrient)); }
        }

        public IRegion WOI
        {
            get => _woi;
            set { _woi = value; OnPropertyChanged(nameof(WOI)); }
        }

        public int Gain
        {
            get => _gain;
            set { _gain = value; OnPropertyChanged(nameof(Gain)); }
        }

        public int Exposure
        {
            get => _exposure;
            set { _exposure = value; OnPropertyChanged(nameof(Exposure)); }
        }

        public double Rotate
        {
            get => _rotate;
            set { _rotate = value; OnPropertyChanged(nameof(Rotate)); }
        }

        public ImageSizeMode SizeMode
        {
            get => _sizeMode;
            set { _sizeMode = value; OnPropertyChanged(nameof(SizeMode)); }
        }

        public ImageExpandRate ExpandRate
        {
            get => _expandRate;
            set { _expandRate = value; OnPropertyChanged(nameof(ExpandRate)); }
        }

        public FilterType AcqFilterType
        {
            get => _acqFilterType;
            set { _acqFilterType = value; OnPropertyChanged(nameof(AcqFilterType)); }
        }

        public int AcqFilterSize
        {
            get => _acqFilterSize;
            set { _acqFilterSize = value; OnPropertyChanged(nameof(AcqFilterSize)); }
        }

        public MarkColor AcqFilterColor
        {
            get => _acqFilterColor;
            set { _acqFilterColor = value; OnPropertyChanged(nameof(AcqFilterColor)); }
        }

        public int AcqFilterIteration
        {
            get => _acqFilterIteration;
            set { _acqFilterIteration = value; OnPropertyChanged(nameof(AcqFilterIteration)); }
        }

        public AcquireMethod AcqMode
        {
            get => _acqMode;
            set { _acqMode = value; OnPropertyChanged(nameof(AcqMode)); }
        }

        public ILightConfig SelectedLightConfig
        {
            get => _selectedLightConfig;
            set { _selectedLightConfig = value; OnPropertyChanged(nameof(SelectedLightConfig)); }
        }

        public int SelectedLightConfigIndex
        {
            get => _selectedLightConfigIndex;
            set { _selectedLightConfigIndex = value; OnPropertyChanged(nameof(SelectedLightConfigIndex)); }
        }

        // --- Methods ---

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ILightConfig GetLightConfig(int index)
        {
            return _lightConfigs.TryGetValue(index, out var config) ? config : null;
        }

        public void SetLightConfig(int index, ILightConfig lightConfig)
        {
            _lightConfigs[index] = lightConfig;
        }

        public ILightConfig GetCurrentLightConfig() => this.SelectedLightConfig;

        public void SetSelectedLightPower(int power)
        {
            // スタブなので、もしSelectedLightConfigが設定されていればその値を更新する等のシミュレートが可能
            SelectedLightPowerChaneged?.Invoke(this, EventArgs.Empty);
        }

        public ILightConfig GetSpecialLightConfig(AcquireMethod acqMode)
        {
            return _specialLightConfigs.TryGetValue(acqMode, out var config) ? config : null;
        }

        public void SetSpecialLightConfig(AcquireMethod acqMode, ILightConfig lightConfig)
        {
            _specialLightConfigs[acqMode] = lightConfig;
        }

        public void SetAcquireCondition(IAcquireCondition cond)
        {
            if (cond == null) return;
            this.AcqOrient = cond.Orient;
            this.Rotate = cond.Rotate;
            this.SizeMode = cond.SizeMode;
            this.ExpandRate = cond.ExpandRate;
            this.WOI = cond.WOI;
            this.Exposure = cond.Exposure;
            this.Gain = cond.Gain;
            this.SelectedLightConfig = cond.AcqLightConfig;
        }

        public void CopyFrom(IJobAcqSettings src)
        {
            if (src == null) return;
            this.AcqOrient = src.AcqOrient;
            this.WOI = src.WOI;
            this.Gain = src.Gain;
            this.Exposure = src.Exposure;
            this.Rotate = src.Rotate;
            this.SizeMode = src.SizeMode;
            this.ExpandRate = src.ExpandRate;
            this.AcqFilterType = src.AcqFilterType;
            this.AcqFilterSize = src.AcqFilterSize;
            this.AcqFilterColor = src.AcqFilterColor;
            this.AcqFilterIteration = src.AcqFilterIteration;
            this.AcqMode = src.AcqMode;
            this.SelectedLightConfig = src.SelectedLightConfig;
            this.SelectedLightConfigIndex = src.SelectedLightConfigIndex;
        }

        public IJobAcqSettings Clone()
        {
            var clone = new StubIJobAcqSettings();
            clone.CopyFrom(this);
            return clone;
        }
    }
}