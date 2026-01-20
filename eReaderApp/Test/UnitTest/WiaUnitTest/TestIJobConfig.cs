
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using Wia.Abstractions;
/// <summary>
/// JobConfigのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    [TestClass]
    public class TestIJobConfig : AbstractTest
    {

        [TestMethod]
        public void プロパティのテスト()
        {
            /* ConfigID */
            IJobConfig iJobConfig = WiaSystem.Job.SelectedConfig;          
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.ConfigID),
                10,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.ConfigID), val), 
                () => iJobConfig.ConfigID 
            );
            /* AcquireSettings */
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.AcquireSettings),
                WiaSystemCopy.Job.SelectedConfig.AcquireSettings,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.AcquireSettings), val), 
                () => iJobConfig.AcquireSettings  
            );
            /* ReadSettings */
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.ReadSettings),
                WiaSystemCopy.Job.SelectedConfig.ReadSettings,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.ReadSettings), val),
                () => iJobConfig.ReadSettings  
            );
            /* TuneSettings */
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.TuneSettings),
                WiaSystemCopy.Job.SelectedConfig.TuneSettings,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.TuneSettings), val),
                () => iJobConfig.TuneSettings  
            );
            /* TuneLatestResult */
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.TuneLatestResult),
                WiaSystemCopy.Job.SelectedConfig.TuneLatestResult,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.TuneLatestResult), val),
                () => iJobConfig.TuneLatestResult
            );
            /* Enable */
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.Enable),
                true,
                val => iJobConfig.Enable = val,
                () => iJobConfig.Enable 
            );
            /* IsReadCompletedEventEnabled */
            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.IsReadCompletedEventEnabled),
                true,
                val => iJobConfig.IsReadCompletedEventEnabled = val,
                () => iJobConfig.IsReadCompletedEventEnabled
            );
        }
    }
}