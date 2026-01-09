using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemSettings : ISystemSettings
    {

        public StubISystemSettings() { }
        public string Password { get; set; }
        public string SystemRootFolderName { get; set; }
        public string SystemRoot { get; set; }
        public string SystemFolder { get; set; }
        public string DeviceFolder { get; set; }
        public int DeviceID { get; set; }
        public IProcessorSettings ProcSetting { get; set; } = new StubIProcessorSettings();
        public bool UseExternalLight { get; set; }
        public string UseLanguage { get; set; }
        public bool ExpandConfig { get; set; }
        public string JobTemplate { get; set; }
        public string StartupJob { get; set; }
        public ApplicationType AppOperationalSpec { get; set; }
        public string GetSystemFolder() { return ""; }
        public string GetDeviceFolder() { return ""; }
        public string GetAppFolder() { return ""; }
        public string GetJobFolder() { return ""; }
        public string GetDefaultAllImageFolder() { return ""; }
        public string GetDefaultFailImageFolder() { return ""; }
        public string GetLogFolder() { return ""; }
        public void ProhibitSettingSystemRootFolder() { }
    }
}
