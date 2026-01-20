
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using Wia.Abstractions;

/// <summary>
/// WiaSystemのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    [TestClass]
    public class TestIWiaSystem : AbstractTest
    {

        [TestMethod]
        public void プロパティのテスト()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            /* AcquisitionSettings */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.AcquisitionSettings),
                WiaSystemCopy.AcquisitionSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.AcquisitionSettings), val), 
                () => WiaSystem.AcquisitionSettings       
            );
            /* SystemSettings */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.SystemSettings),
                WiaSystemCopy.SystemSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.SystemSettings), val), 
                () => WiaSystem.SystemSettings       
            );
            /* GUISettings */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.GUISettings),
                WiaSystemCopy.GUISettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.GUISettings), val), 
                () => WiaSystem.GUISettings       
            );
            /* CommunicationSettings */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.CommunicationSettings),
                WiaSystemCopy.CommunicationSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.CommunicationSettings), val), 
                () => WiaSystem.CommunicationSettings       
            );
            /* ReadSettings */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ReadSettings),
                WiaSystemCopy.ReadSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ReadSettings), val), 
                () => WiaSystem.ReadSettings       
            );
            /* LogSettings */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.LogSettings),
                WiaSystemCopy.LogSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.LogSettings), val), 
                () => WiaSystem.LogSettings       
            );
            /* Device */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.Device),
                WiaSystemCopy.Device,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.Device), val), 
                () => WiaSystem.Device       
            );
            /* ImageSource */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ImageSource),
                WiaSystemCopy.ImageSource,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ImageSource), val), 
                () => WiaSystem.ImageSource       
            );
            /* CommManager */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.CommManager),
                WiaSystemCopy.CommManager,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.CommManager), val), 
                () => WiaSystem.CommManager       
            );
            /* Job */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.Job),
                WiaSystemCopy.Job,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.Job), val), 
                () => WiaSystem.Job       
            );
            /* MaintenanceServices */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.MaintenanceServices),
                WiaSystemCopy.MaintenanceServices,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.MaintenanceServices), val), 
                () => WiaSystem.MaintenanceServices       
            );
            /* AppVersion */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.AppVersion),
                "",
                val => this.privateSet(WiaSystem, nameof(WiaSystem.AppVersion), val), 
                () => WiaSystem.AppVersion       
            );
            /* IsOnline */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.IsOnline),
                true,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.IsOnline), val), 
                () => WiaSystem.IsOnline       
            );
            /* IsScreenLocked */
            VerifyProperty(
                iWiaSystem,
                nameof(iWiaSystem.IsScreenLocked),
                true,
                val => iWiaSystem.IsScreenLocked = val, 
                () => iWiaSystem.IsScreenLocked        
            );
            /* IsAcquireDisabled */
            VerifyProperty(
                iWiaSystem,
                nameof(iWiaSystem.IsAcquireDisabled),
                true,
                val => iWiaSystem.IsAcquireDisabled = val, 
                () => iWiaSystem.IsAcquireDisabled        
            );
            /* ActiveJobName */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ActiveJobName),
                "",
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ActiveJobName), val), 
                () => WiaSystem.ActiveJobName       
            );
            /* ActiveJobLoadTime */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ActiveJobLoadTime),
                new DateTime(2025, 1, 1, 10, 30, 0),
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ActiveJobLoadTime), val), 
                () => WiaSystem.ActiveJobLoadTime       
            );
            /* BootTime */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.BootTime),
                new DateTime(2025, 1, 1, 10, 30, 0),
                val => this.privateSet(WiaSystem, nameof(WiaSystem.BootTime), val), 
                () => WiaSystem.BootTime       
            );
            /* IsTuning */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.IsTuning),
                true,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.IsTuning), val), 
                () => WiaSystem.IsTuning       
            );
            /* TuneCurrentState */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.TuneCurrentState),
                TuneState.Waiting,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.TuneCurrentState), val), 
                () => WiaSystem.TuneCurrentState       
            );
            /* TuneCurrentSeqNumber */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.TuneCurrentSeqNumber),
                10,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.TuneCurrentSeqNumber), val), 
                () => WiaSystem.TuneCurrentSeqNumber       
            );
            /* TuneCurrentConfigNumber */
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.TuneCurrentConfigNumber),
                10,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.TuneCurrentConfigNumber), val), 
                () => WiaSystem.TuneCurrentConfigNumber       
            );
        }
    }
}