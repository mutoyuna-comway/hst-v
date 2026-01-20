
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using Wia.Abstractions;

namespace TestWiaSystem
{

    [TestClass]
    public class TestIWiaSystem : AbstractTest
    {

        [TestMethod]
        public void テストパターン1()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.AcquisitionSettings),
                WiaSystemCopy.AcquisitionSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.AcquisitionSettings), val), // Setterの動きを渡す
                () => WiaSystem.AcquisitionSettings        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.SystemSettings),
                WiaSystemCopy.SystemSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.SystemSettings), val), // Setterの動きを渡す
                () => WiaSystem.SystemSettings        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.GUISettings),
                WiaSystemCopy.GUISettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.GUISettings), val), // Setterの動きを渡す
                () => WiaSystem.GUISettings        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.CommunicationSettings),
                WiaSystemCopy.CommunicationSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.CommunicationSettings), val), // Setterの動きを渡す
                () => WiaSystem.CommunicationSettings        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ReadSettings),
                WiaSystemCopy.ReadSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ReadSettings), val), // Setterの動きを渡す
                () => WiaSystem.ReadSettings        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.LogSettings),
                WiaSystemCopy.LogSettings,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.LogSettings), val), // Setterの動きを渡す
                () => WiaSystem.LogSettings        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.Device),
                WiaSystemCopy.Device,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.Device), val), // Setterの動きを渡す
                () => WiaSystem.Device        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ImageSource),
                WiaSystemCopy.ImageSource,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ImageSource), val), // Setterの動きを渡す
                () => WiaSystem.ImageSource        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.CommManager),
                WiaSystemCopy.CommManager,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.CommManager), val), // Setterの動きを渡す
                () => WiaSystem.CommManager        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.Job),
                WiaSystemCopy.Job,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.Job), val), // Setterの動きを渡す
                () => WiaSystem.Job        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.MaintenanceServices),
                WiaSystemCopy.MaintenanceServices,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.MaintenanceServices), val), // Setterの動きを渡す
                () => WiaSystem.MaintenanceServices        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.AppVersion),
                "",
                val => this.privateSet(WiaSystem, nameof(WiaSystem.AppVersion), val), // Setterの動きを渡す
                () => WiaSystem.AppVersion        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.IsOnline),
                true,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.IsOnline), val), // Setterの動きを渡す
                () => WiaSystem.IsOnline        // Getterの動きを渡す
            );
            VerifyProperty(
                iWiaSystem,
                nameof(iWiaSystem.IsScreenLocked),
                true,
                val => iWiaSystem.IsScreenLocked = val, // Setterの動きを渡す
                () => iWiaSystem.IsScreenLocked         // Getterの動きを渡す
            );
            VerifyProperty(
                iWiaSystem,
                nameof(iWiaSystem.IsAcquireDisabled),
                true,
                val => iWiaSystem.IsAcquireDisabled = val, // Setterの動きを渡す
                () => iWiaSystem.IsAcquireDisabled         // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ActiveJobName),
                "",
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ActiveJobName), val), // Setterの動きを渡す
                () => WiaSystem.ActiveJobName        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.ActiveJobLoadTime),
                new DateTime(2025, 1, 1, 10, 30, 0),
                val => this.privateSet(WiaSystem, nameof(WiaSystem.ActiveJobLoadTime), val), // Setterの動きを渡す
                () => WiaSystem.ActiveJobLoadTime        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.BootTime),
                new DateTime(2025, 1, 1, 10, 30, 0),
                val => this.privateSet(WiaSystem, nameof(WiaSystem.BootTime), val), // Setterの動きを渡す
                () => WiaSystem.BootTime        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.IsTuning),
                true,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.IsTuning), val), // Setterの動きを渡す
                () => WiaSystem.IsTuning        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.TuneCurrentState),
                TuneState.Waiting,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.TuneCurrentState), val), // Setterの動きを渡す
                () => WiaSystem.TuneCurrentState        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.TuneCurrentSeqNumber),
                10,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.TuneCurrentSeqNumber), val), // Setterの動きを渡す
                () => WiaSystem.TuneCurrentSeqNumber        // Getterの動きを渡す
            );
            VerifyProperty(
                WiaSystem,
                nameof(WiaSystem.TuneCurrentConfigNumber),
                10,
                val => this.privateSet(WiaSystem, nameof(WiaSystem.TuneCurrentConfigNumber), val), // Setterの動きを渡す
                () => WiaSystem.TuneCurrentConfigNumber        // Getterの動きを渡す
            );
        }
    }
}