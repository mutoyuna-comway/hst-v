using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemGUISettings : ISystemGUISettings
    {

        public StubISystemGUISettings() { }
        public bool LibraryMode { get; set; }
        public bool ShowInTaskbar { get; set; }
        public bool GUILock { get; set; }
        public bool WindowMinimized { get; set; }
        public DisplayModeType DispMode { get; set; }
        public int LogDispLines { get; set; }
        public bool AutoSaveScreen { get; set; }
        public AppsCloseActionType AppsCloseActionReborn { get; set; }
    }
}
