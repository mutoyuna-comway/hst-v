
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SystemSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SystemSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISystemSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISystemSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                ISystemSettings iSystemSettings = WiaSystem.SystemSettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Password", "", false };
                yield return new object[] { "SystemRootFolderName", "", false };
                yield return new object[] { "SystemRoot", "", false };
                yield return new object[] { "SystemFolder", "", false };
                yield return new object[] { "DeviceFolder", "", false };
                yield return new object[] { "DeviceID", 10, false };
                yield return new object[] { "ProcSetting", DeepCopy(iSystemSettings.ProcSetting), false };
                yield return new object[] { "UseExternalLight", true, false };
                yield return new object[] { "UseLanguage", "", false };
                yield return new object[] { "ExpandConfig", true, false };
                yield return new object[] { "JobTemplate", "", false };
                yield return new object[] { "StartupJob", "", false };
                yield return new object[] { "AppOperationalSpec", ApplicationType.Er8000, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISystemSettingsData))]
        public void ISystemSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISystemSettings iSystemSettings = WiaSystem.SystemSettings;
            this.PropertyTest(iSystemSettings, name, value, isPrivate);
        }
    }
}