
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// WiaSystemのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// WiaSystemのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIWiaSystem : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIWiaSystemData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyWiaSystem = getCopyIWiaSystem();
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AcquisitionSettings", copyWiaSystem.AcquisitionSettings, true };
                yield return new object[] { "SystemSettings", copyWiaSystem.SystemSettings, true };
                yield return new object[] { "GUISettings", copyWiaSystem.GUISettings, true };
                yield return new object[] { "CommunicationSettings", copyWiaSystem.CommunicationSettings, true };
                yield return new object[] { "ReadSettings", copyWiaSystem.ReadSettings, true };
                yield return new object[] { "LogSettings", copyWiaSystem.LogSettings, true };
                yield return new object[] { "Device", copyWiaSystem.Device, true };
                yield return new object[] { "ImageSource", copyWiaSystem.ImageSource, true };
                yield return new object[] { "CommManager", copyWiaSystem.CommManager, true };
                yield return new object[] { "Job", copyWiaSystem.Job, true };
                yield return new object[] { "MaintenanceServices", copyWiaSystem.MaintenanceServices, true };
                yield return new object[] { "AppVersion", "", true };
                yield return new object[] { "IsOnline", true, true };
                yield return new object[] { "IsScreenLocked", true, false };
                yield return new object[] { "IsAcquireDisabled", true, false };
                yield return new object[] { "ActiveJobName", "", true };
                yield return new object[] { "ActiveJobLoadTime", new DateTime(2025, 1, 1, 10, 30, 0), true };
                yield return new object[] { "BootTime", new DateTime(2025, 1, 1, 10, 30, 0), true };
                yield return new object[] { "IsTuning", true, true };
                yield return new object[] { "TuneCurrentState", TuneState.Waiting, true };
                yield return new object[] { "TuneCurrentSeqNumber", 10, true };
                yield return new object[] { "TuneCurrentConfigNumber", 10, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIWiaSystemData))]
        public void IWiaSystemPropertyTest(string name, object value, bool isPrivate)
        {
            IWiaSystem iWiaSystem = WiaSystem;
            this.PropertyTest(iWiaSystem, name, value, isPrivate);
        }
    }
}