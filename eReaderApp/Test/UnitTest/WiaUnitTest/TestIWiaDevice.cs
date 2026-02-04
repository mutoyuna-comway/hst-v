
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// WiaDeviceのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// WiaDeviceのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TesIWiaDevice : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIWiaDeviceData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyWiaDevice = getCopyIWiaSystem().Device;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "IsCameraFound", true, true };
                yield return new object[] { "IsValidLicense", true, true };
                yield return new object[] { "ModelName", "", true };
                yield return new object[] { "FirmwareVersion", "", true };
                yield return new object[] { "MacAddress", "", true };
                yield return new object[] { "SerialNumber", "", true };
                yield return new object[] { "PacketSize", 10, true };
                yield return new object[] { "GainMax", 10, true };
                yield return new object[] { "GainMin", 10, true };
                yield return new object[] { "ExposureMin", 10, true };
                yield return new object[] { "ExposureMax", 10, true };
                yield return new object[] { "CameraInfo", copyWiaDevice.CameraInfo, true };
                yield return new object[] { "CurrentAcqSettings", copyWiaDevice.CurrentAcqSettings, true };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIWiaDeviceData))]
        public void IWiaDevicePropertyTest(string name, object value, bool isPrivate)
        {
            IWiaDevice iWiaDevice = WiaSystem.Device;
            this.PropertyTestWithoutINotifyPropertyChanged(iWiaDevice, name, value, isPrivate);
        }
    }
}