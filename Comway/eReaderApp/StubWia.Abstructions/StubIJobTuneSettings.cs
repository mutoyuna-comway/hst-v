using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubIJobTuneSettings : IJobTuneSettings
    {
       
        public StubIJobTuneSettings() { }       
        public string MatchString { get; set; }
        public TuneSelectMode TuneMode { get; set; }
        public ICharacterSize CharSize { get; set; } = new StubICharacterSize();
        public TuneScanningMode TuneScanMode { get; set; }
        public bool LightEnable { get; set; }
        public int LightRange { get; set; }
        public int LightMinimum { get; set; }
        public int LightMaximum { get; set; }
        public bool SizeEnable { get; set; }
        public int WidthRange { get; set; }
        public int HeightRange { get; set; }
        public bool ColorEnable { get; set; }
        public bool PreprocessEnable { get; set; }
        public bool InternalFilterEnable { get; set; }
        public int AvailableLightConfigNum { get; }
        public bool UseCurrentLightConfig { get; set; }
        public bool GetAvailableLightConfigEnable(int index) { return true; }
        public void SetAvailableLightConfigEnable(int index, bool enable) { }

    }
}
