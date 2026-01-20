
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using Wia.Abstractions;

namespace TestWiaSystem
{

    [TestClass]
    public class TestIJobConfig : AbstractTest
    {

        [TestMethod]
        public void テストパターン1()
        {
            IJobConfig iJobConfig = WiaSystem.Job.SelectedConfig;          
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.ConfigID),
                10,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.ConfigID), val), // Setterの動きを渡す
                () => iJobConfig.ConfigID         // Getterの動きを渡す
            );
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.AcquireSettings),
                WiaSystemCopy.Job.SelectedConfig.AcquireSettings,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.AcquireSettings), val), // Setterの動きを渡す
                () => iJobConfig.AcquireSettings         // Getterの動きを渡す
            );
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.ReadSettings),
                WiaSystemCopy.Job.SelectedConfig.ReadSettings,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.ReadSettings), val), // Setterの動きを渡す
                () => iJobConfig.ReadSettings         // Getterの動きを渡す
            );
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.TuneSettings),
                WiaSystemCopy.Job.SelectedConfig.TuneSettings,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.TuneSettings), val), // Setterの動きを渡す
                () => iJobConfig.TuneSettings         // Getterの動きを渡す
            );
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.TuneLatestResult),
                WiaSystemCopy.Job.SelectedConfig.TuneLatestResult,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.TuneLatestResult), val), // Setterの動きを渡す
                () => iJobConfig.TuneLatestResult         // Getterの動きを渡す
            );
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.Enable),
                true,
                val => iJobConfig.Enable = val, // Setterの動きを渡す
                () => iJobConfig.Enable        // Getterの動きを渡す
            );
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.IsReadCompletedEventEnabled),
                true,
                val => iJobConfig.IsReadCompletedEventEnabled = val, // Setterの動きを渡す
                () => iJobConfig.IsReadCompletedEventEnabled        // Getterの動きを渡す
            );
        }
    }
}