
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SystemAcqSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SystemAcqSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISystemAcqSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISystemAcqSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyISystemAcqSettings = getCopyIWiaSystem().AcquisitionSettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AcquireTimeout", 10, false };
                yield return new object[] { "AutoReconnect", true, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISystemAcqSettingsData))]
        public void ISystemAcqSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISystemAcqSettings iSystemAcqSettings = WiaSystem.AcquisitionSettings;
            this.PropertyTest(iSystemAcqSettings, name, value, isPrivate);
        }
    }
}