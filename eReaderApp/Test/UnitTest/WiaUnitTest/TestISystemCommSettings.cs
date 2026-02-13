
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SystemCommSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SystemCommSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISystemCommSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISystemCommSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                ISystemCommSettings iSystemCommSettings = WiaSystem.CommunicationSettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Delimeter", DelimeterType.CRLF, false };
                yield return new object[] { "CommType", CommunicatorType.Serial, false };
                yield return new object[] { "Socket", DeepCopy(iSystemCommSettings.Socket), false };
                yield return new object[] { "Serial", DeepCopy(iSystemCommSettings.Serial), false };
                yield return new object[] { "Response", DeepCopy(iSystemCommSettings.Response), false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISystemCommSettingsData))]
        public void ISystemCommSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISystemCommSettings iSystemCommSettings = WiaSystem.CommunicationSettings;
            this.PropertyTest(iSystemCommSettings, name, value, isPrivate);
        }
    }
}