
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// JobAcqSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// JobAcqSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIJobAcqSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIJobAcqSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyJobAcqSettings = WiaSystem.Job.SelectedConfig.Clone().AcquireSettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AcqOrient", ImageOrient.Normal, false };
                yield return new object[] { "WOI", copyJobAcqSettings.WOI, false };
                yield return new object[] { "Gain", 10, false };
                yield return new object[] { "Exposure", 10, false };
                yield return new object[] { "Rotate", 10.0, false };
                yield return new object[] { "AcqFilter", FilterType.Median, false };
                yield return new object[] { "AcqFilterSize", 10, false };
                yield return new object[] { "AcqFilterColor", MarkColor.Auto, false };
                yield return new object[] { "AcqFilterIteration", 10, false };
                yield return new object[] { "AcqMode", AcquireMethod.AdvancedAuto, false };
                yield return new object[] { "SelectedLightConfig", copyJobAcqSettings.SelectedLightConfig, false };
                yield return new object[] { "SelectedLightConfigIndex", 10, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIJobAcqSettingsData))]
        public void IJobAcqSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            IJobAcqSettings iJobAcqSettings = WiaSystem.Job.SelectedConfig.AcquireSettings;
            this.PropertyTest(iJobAcqSettings, name, value, isPrivate);
        }
    }
}