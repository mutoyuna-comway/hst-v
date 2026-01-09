using System;
using Wia.Abstractions;
using System.Net.NetworkInformation;

namespace StubWia.Abstructions
{
    public class StubICamContloler : ICamContloler
    {
        public StubICamContloler() { }
        public void Dispose() { }

        public bool IsRealDevice { get; }

        public void Initialize () { }
        public String GetModuleName() { return ""; }
        public int GetExposureMax() { return 0; }
        public int GetExposureMin() { return 0; }
        public int GetGainMin() { return 0; }
        public int GetGainMax() { return 0; }
        public ICameraInfo Connect(ISystemCameraSettings prms, ICameraInfo currentCamInfo, ICameraInfoFactory cameraInfoFactory, out String expString) { expString = ""; return null; }
        public bool Disconnect(out String expString) { expString = ""; return true; }
        public bool Acquire(IAcquireCondition cue, IImage image, out String expString) { expString = ""; return true; }
        public bool GetIsConnected() { return true; }
        public String GetCameraModelName() { return ""; }
        public String GetFirmwareVersion() { return ""; }
        public PhysicalAddress GetMacAddress() { return null; }
        public String GetSerialNumber() { return ""; }
        public ulong GetPacketSize() {  return 0; }
        public bool SetPacketSize(ulong packetSize, ref String expString) { return true; }
        public ulong GetPacketDelay() {  return 0; }
        public bool SetPacketDelay(ulong packetDelay, ref String expString) { return true; }
        public int GetGain() { return 0; }
        public bool SetGain(int gain, ref String expString) { return true; }
        public int GetExposure() {  return 0; }
        public bool SetExposure(int exposure, ref String expString) { return true; }
        public String GetDisplayDeviceTitle() { return ""; }
        public void SetAcquireTimeout(int acquireTimeout) { }
    }

        
}
