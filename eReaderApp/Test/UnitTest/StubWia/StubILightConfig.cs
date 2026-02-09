using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{

    public class StubILightConfig : ILightConfig
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public StubILightConfig() { }
        private int _lightConfigID;
        public int LightConfigID {
            get { return this._lightConfigID; }
            private set
            {
                this._lightConfigID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightConfigID)));
            }
        }
        //public int LightLevel { get; set; }
        private int _lightLevel;
        public int LightLevel
        {
            get => _lightLevel;
            set
            {
                _lightLevel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LightLevel)));
            }
        }
        //public ReflectedColor ReflectedColor { get; set; }
        private ReflectedColor _reflectedColor;
        public ReflectedColor ReflectedColor
        {
            get => _reflectedColor;
            set
            {
                _reflectedColor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReflectedColor)));
            }
        }
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
