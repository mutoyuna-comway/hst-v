using System;
using System.Collections.Generic;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubILightContloler : ILightContloler
    {
       
        public StubILightContloler() { }
        public void Dispose() { }
        public void Initialize() { }
        public bool LightOn(ILightConfig lc, out String expString) { expString = ""; return true; }
        public bool LightOff(out String expString) { expString = ""; return true;  }
        public String GetModuleName() { return ""; }
        public int GetLightNum() {  return 0; }
        public List<String> LightDisplayName() { return new List<String>(); }

    }
}
