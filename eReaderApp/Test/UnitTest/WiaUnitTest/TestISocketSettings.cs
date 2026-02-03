
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SocketSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SocketSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISocketSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISocketSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copySocketSettingsData = getCopyIWiaSystem().CommunicationSettings.Socket;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "HostIPAddress", new System.Net.IPAddress(0), false };
                yield return new object[] { "HostIPAddressString", "", false };
                yield return new object[] { "SocketPort", 10UL, false };
                yield return new object[] { "SocketBufferSize", 10, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISocketSettingsData))]
        public void ISocketSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISocketSettings iSocketSettings = WiaSystem.CommunicationSettings.Socket;
            this.PropertyTest(iSocketSettings, name, value, isPrivate);
        }
    }
}