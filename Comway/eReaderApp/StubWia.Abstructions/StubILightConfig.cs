using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubILightConfig : ILightConfig
    {
       
        public StubILightConfig() { }       
        public int LightLevel { get; set; }
        public ReflectedColor ReflectedColor { get; set; }
        public int GetLightPower() { return 0; }
        public void SetLightPower(int power) { }
        public int GetLightCount() { return 0; }
        public void SetLightEnable(int index, bool enable) { }
        public void SetLightPower(int index, int power) { }
        public bool GetLightEnable(int index) {  return true; }
        public int GetLightPower(int index) { return 0; }
        public int GetLightId(int index) { return 0; }

    }
}
