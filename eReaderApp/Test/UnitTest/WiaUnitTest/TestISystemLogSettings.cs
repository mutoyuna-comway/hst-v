
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SystemLogSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SystemLogSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISystemLogSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISystemLogSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                ISystemLogSettings iSystemLogSettings = WiaSystem.LogSettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "CommandLogOutput",true, false };
                yield return new object[] { "LogOutput", DeepCopy(iSystemLogSettings.LogOutput), false };
                yield return new object[] { "LogUpdateCount", 10, false };
                yield return new object[] { "ImgSaveSetting", DeepCopy(iSystemLogSettings.ImgSaveSetting), false };
                yield return new object[] { "AppCameraLogEnabled", true, false };
                yield return new object[] { "ParamsBackupMode", ParamsBackupModeConstants.AutoCleanup, false };
                yield return new object[] { "ReadParamLog", ReadParamLogConstants.Always, false };
                yield return new object[] { "TuneAcceptImageSaveNum", 1, false };
                yield return new object[] { "TuneDetailLogOutput", true, false };
                yield return new object[] { "TuneDetailLogSortEnabled", true, false };
                yield return new object[] { "TuneDetailLogMaxNum", 10, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISystemLogSettingsData))]
        public void ISystemLogSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISystemLogSettings iSystemLogSettings = WiaSystem.LogSettings;
            this.PropertyTest(iSystemLogSettings, name, value, isPrivate);
        }
    }
}