
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// ImageSaveSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// ImageSaveSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIImageSaveSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIImageSaveSettingsData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "EnableAllSaveImage", true, false };
                yield return new object[] { "NumOfAllSaveImage", 10, false };
                yield return new object[] { "AllImageSaveDir", "", false };
                yield return new object[] { "EnableFailSaveImage", true, false };
                yield return new object[] { "NumOfFailSaveImage", 10, false };
                yield return new object[] { "FailImageSaveDir", "", false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIImageSaveSettingsData))]
        public void IImageSaveSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            IImageSaveSettings iImageSaveSettings = WiaSystem.LogSettings.ImgSaveSetting;
            this.PropertyTest(iImageSaveSettings, name, value, isPrivate);
        }
    }
}