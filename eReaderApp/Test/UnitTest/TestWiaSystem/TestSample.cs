
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using Wia.Abstractions;

namespace TestWiaSystem
{

    [TestClass]
    public class TestSample : AbstractTest
    {

        [TestMethod]
        public void テストパターン1()
        {

            /***
             setter getterがあるときのテストサンプル
             */
            IBarcodeParameters iBarcodeParameters = WiaSystem.Job.SelectedConfig.ReadSettings.Barcode;

            VerifyProperty(
                iBarcodeParameters,
                nameof(iBarcodeParameters.DisableFieldString),
                true,
                val => iBarcodeParameters.DisableFieldString = val, // Setterの動きを渡す
                () => iBarcodeParameters.DisableFieldString         // Getterの動きを渡す
            );

            /***
             getterのみのテストサンプル
             */
            IJobConfig iJobConfig = new StubIJobConfig();

            VerifyProperty(
                iJobConfig,
                nameof(iJobConfig.ConfigID),
                10,
                val => this.privateSet(iJobConfig, nameof(iJobConfig.ConfigID), val), // Setterの動きを渡す
                () => iJobConfig.ConfigID         // Getterの動きを渡す
            );

        }

    }
}