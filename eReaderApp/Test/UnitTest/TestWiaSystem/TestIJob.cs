
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using Wia.Abstractions;

namespace TestWiaSystem
{

    [TestClass]
    public class TestIJob : AbstractTest
    {
        [TestMethod]
        public void テストパターン1()
        {
            IJob iJob = WiaSystem.Job;

            VerifyProperty(
                iJob,
                nameof(iJob.ReadType),
                ReadMethod.All,
                val => iJob.ReadType = val, // Setterの動きを渡す
                () => iJob.ReadType         // Getterの動きを渡す
            );
            VerifyProperty(
                iJob,
                nameof(iJob.ScoreType),
                ScoreMode.MinScore,
                val => iJob.ScoreType = val, // Setterの動きを渡す
                () => iJob.ScoreType         // Getterの動きを渡す
            );   
            VerifyProperty(
                iJob,
                nameof(iJob.SelectedConfig),
               WiaSystemCopy.Job.SelectedConfig,
                val => this.privateSet(iJob, nameof(iJob.SelectedConfig), val), // Setterの動きを渡す
                () => iJob.SelectedConfig         // Getterの動きを渡す
            );
            VerifyProperty(
                iJob,
                nameof(iJob.SelectedConfigIndex),
                10,
                val => iJob.SelectedConfigIndex = val, // Setterの動きを渡す
                () => iJob.SelectedConfigIndex         // Getterの動きを渡す
            );
            VerifyProperty(
                iJob,
                nameof(iJob.Configs),
               WiaSystemCopy.Job.Configs,
                val => this.privateSet(iJob, nameof(iJob.Configs), val), // Setterの動きを渡す
                () => iJob.Configs         // Getterの動きを渡す
            );
        }
    }
}