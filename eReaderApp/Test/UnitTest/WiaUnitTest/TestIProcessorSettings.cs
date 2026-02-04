
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Wia.Abstractions;

/// <summary>
/// ProcessorSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// ProcessorSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIProcessorSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIProcessorSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyProcessorSettings = getCopyIWiaSystem().SystemSettings.ProcSetting;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AffinityMask", 1UL, false };
                yield return new object[] { "ProcessorPriority", ProcessPriorityClass.Normal, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIProcessorSettingsData))]
        public void IProcessorSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            IProcessorSettings iProcessorSettings = WiaSystem.SystemSettings.ProcSetting;
            this.PropertyTest(iProcessorSettings, name, value, isPrivate);
        }
    }
}