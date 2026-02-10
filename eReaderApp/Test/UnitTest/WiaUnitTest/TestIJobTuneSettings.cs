
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// JobTuneSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// JobTuneSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIJobTuneSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIJobTuneSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyJob = WiaSystem.Job.SelectedConfig.Clone().TuneSettings; ;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "MatchString", "", false };
                yield return new object[] { "TuneMode", TuneSelectMode.AverageBest, false };
                yield return new object[] { "TuneScanMode", TuneScanningMode.Normal, false };
                yield return new object[] { "LightEnable", true, false };
                yield return new object[] { "LightRange", 1, false };
                yield return new object[] { "LightMinimum", 1, false };
                yield return new object[] { "LightMaximum", 1, false };
                yield return new object[] { "SizeEnable", true, false };
                yield return new object[] { "WidthRange", 1, false };
                yield return new object[] { "HeightRange", 1, false };
                yield return new object[] { "ColorEnable", true, false };
                yield return new object[] { "PreprocessEnable", true, false };
                yield return new object[] { "InternalFilterEnable", true, false };
                yield return new object[] { "AvailableLightConfigNum", 1, false };
                yield return new object[] { "UseCurrentLightConfig", true, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIJobTuneSettingsData))]
        public void IJobTuneSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            IJobTuneSettings iJobTuneSettings = WiaSystem.Job.SelectedConfig.TuneSettings; ;
            this.PropertyTest(iJobTuneSettings, name, value, isPrivate);
        }
    }
}