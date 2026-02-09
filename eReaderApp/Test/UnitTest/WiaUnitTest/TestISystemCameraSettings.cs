
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SystemCameraSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SystemCameraSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISystemCameraSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISystemCameraSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copySystemCameraSettings = getCopyIWiaSystem().AcquisitionSettings.CurrentCameraSetting;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "CameraIPAddress", new System.Net.IPAddress(0), false };
                yield return new object[] { "CameraIPAddressString", "", false };
                yield return new object[] { "ConnectToSpecify", true, false };
                yield return new object[] { "PacketSize", 10, false };
                yield return new object[] { "AuthenticationCode", "", false };
                yield return new object[] { "SendImageToHost", true, false };
                yield return new object[] { "AcqImageSaveFileName", "", false };
                yield return new object[] { "AcqImageSaveFileNameHalf", "", false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISystemCameraSettingsData))]
        public void ISystemCameraSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISystemCameraSettings iSystemCameraSettings = WiaSystem.AcquisitionSettings.CurrentCameraSetting;
            this.PropertyTest(iSystemCameraSettings, name, value, isPrivate);
        }
    }
}