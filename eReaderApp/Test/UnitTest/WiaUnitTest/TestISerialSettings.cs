
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SerialSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SerialSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISerialSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISerialSettingsData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Baudrate", SerialBaudrate.Rate2400, false };
                yield return new object[] { "DataBits", SerialDataBits.Bit7, false };
                yield return new object[] { "HandShake", SerialHandShake.None, false };
                yield return new object[] { "Parity", SerialParity.None, false };
                yield return new object[] { "Port", SerialPort.None, false };
                yield return new object[] { "StopBits", SerialStopBits.None, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISerialSettingsData))]
        public void ISerialSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISerialSettings iSerialSettings = WiaSystem.CommunicationSettings.Serial;
            this.PropertyTest(iSerialSettings, name, value, isPrivate);
        }
    }
}