using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
    public class StubIJobAcqSettings : IJobAcqSettings
    {
       
        public StubIJobAcqSettings() { }       
        public ImageOrient AcqOrient { get; set; }
        public IRegion WOI { get; set; } = new StubIRegion();
        public int Gain { get; set; }
        public int Exposure { get; set; }
        public double Rotate { get; set; }
        public FilterType AcqFilter { get; set; }
        public int AcqFilterSize { get; set; }
        public MarkColor AcqFilterColor { get; set; }
        public int AcqFilterIteration { get; set; }
        public AcquireMethod AcqMode { get; set; }
        public ILightConfig SelectedLightConfig { get; set; } = new StubILightConfig();
        public int SelectedLightConfigIndex { get; set; }
        public ILightConfig GetLightConfig(int index) { return null; }
        public void SetCurrentCue(AcquireMethod method, MarkColor color) { }

    }
}
