using System;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
 
    public class StubIImageSaveSettings : IImageSaveSettings
    {
       
        public StubIImageSaveSettings() { }       
        public bool EnableAllSaveImage { get; set; }
        public int NumOfAllSaveImage { get; set; }
        public String AllImageSaveDir { get; set; }
        public bool EnableFailSaveImage { get; set; }
        public int NumOfFailSaveImage { get; set; }
        public String FailImageSaveDir { get; set; }
    }
}
