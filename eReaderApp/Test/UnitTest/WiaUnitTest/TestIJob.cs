
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using Wia.Abstractions;

/// <summary>
/// Jobのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    [TestClass]
    public class TestIJob : AbstractTest
    {
        [TestMethod]
        public void プロパティのテスト()
        {
            IJob iJob = WiaSystem.Job;
            /* ReadType */
            VerifyProperty(
                iJob,
                nameof(iJob.ReadType),
                ReadMethod.All,
                val => iJob.ReadType = val, 
                () => iJob.ReadType         
            );
            /* ScoreType */
            VerifyProperty(
                iJob,
                nameof(iJob.ScoreType),
                ScoreMode.MinScore,
                val => iJob.ScoreType = val, 
                () => iJob.ScoreType         
            );
            /* SelectedConfig */
            VerifyProperty(
                iJob,
                nameof(iJob.SelectedConfig),
               WiaSystemCopy.Job.SelectedConfig,
                val => this.privateSet(iJob, nameof(iJob.SelectedConfig), val), 
                () => iJob.SelectedConfig         
            );
            /* SelectedConfigIndex */
            VerifyProperty(
                iJob,
                nameof(iJob.SelectedConfigIndex),
                10,
                val => iJob.SelectedConfigIndex = val, 
                () => iJob.SelectedConfigIndex         
            );
            /* Configs */
            VerifyProperty(
                iJob,
                nameof(iJob.Configs),
               WiaSystemCopy.Job.Configs,
                val => this.privateSet(iJob, nameof(iJob.Configs), val), 
                () => iJob.Configs         
            );
        }
    }
}