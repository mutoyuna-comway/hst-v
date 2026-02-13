
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
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
                IWiaSystem iWiaSystem = WiaSystem;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AcquisitionSettings", DeepCopy(iWiaSystem.AcquisitionSettings), true };
                yield return new object[] { "SystemSettings", DeepCopy(iWiaSystem.SystemSettings), true };
                yield return new object[] { "GUISettings", DeepCopy(iWiaSystem.GUISettings), true };
                yield return new object[] { "CommunicationSettings", DeepCopy(iWiaSystem.CommunicationSettings), true };
                yield return new object[] { "ReadSettings", DeepCopy(iWiaSystem.ReadSettings), true };
                yield return new object[] { "LogSettings", DeepCopy(iWiaSystem.LogSettings), true };
                yield return new object[] { "Device", DeepCopy(iWiaSystem.Device), true };
                yield return new object[] { "ImageSource", DeepCopy(iWiaSystem.ImageSource), true };
                yield return new object[] { "CommManager", DeepCopy(iWiaSystem.CommManager), true };
                yield return new object[] { "Job", DeepCopy(iWiaSystem.Job), true };
                yield return new object[] { "MaintenanceServices", DeepCopy(iWiaSystem.MaintenanceServices), true };
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