using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia.Abstructions
{

    public class StubISystemLogSettings : ISystemLogSettings
    {

        public StubISystemLogSettings() { }
        public bool CommandLogOutput { get; set; }
        public ILumpLogOutput LogOutput { get; set; } = new StubILumpLogOutput();
        public int LogUpdateCount { get; set; }
        public IImageSaveSettings ImgSaveSetting { get; set; } = new StubIImageSaveSettings();
        public bool AppCameraLogEnabled { get; set; }
        public bool AppStartupLogEnabled { get; set; }
        public ParamsBackupModeConstants ParamsBackupMode { get; set; }
        public ReadParamLogConstants ReadParamLog { get; set; }
        public int TuneAcceptImageSaveNum { get; set; }
        public bool TuneDetailLogOutput { get; set; }
        public bool TuneDetailLogSortEnabled { get; set; }
        public int TuneDetailLogMaxNum { get; set; }
    }
}
