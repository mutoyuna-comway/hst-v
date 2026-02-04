
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// LightConfigのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// LightConfigのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestILightConfig : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestILightConfigData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyLightConfig = getCopyIWiaSystem().Job.SelectedConfig.AcquireSettings.SelectedLightConfig;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "LightConfigID", 10, true };
                yield return new object[] { "LightLevel", 10, false };
                yield return new object[] { "ReflectedColor", ReflectedColor.Any, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestILightConfigData))]
        public void ILightConfigPropertyTest(string name, object value, bool isPrivate)
        {
            ILightConfig iLightConfig = WiaSystem.Job.SelectedConfig.AcquireSettings.SelectedLightConfig;
            this.PropertyTest(iLightConfig, name, value, isPrivate);
        }
    }
}