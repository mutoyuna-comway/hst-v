
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// QRCodeParametersのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// QRCodeParametersのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIQRCodeParameters : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIQRCodeParametersData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "CharLimit", CharacterLimitationType.None, false };
                yield return new object[] { "ErrorBitSize", 1, false };
                yield return new object[] { "SpecifiedGrids", true, false };
                yield return new object[] { "Grid", QRGridSize.QRS29x29, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIQRCodeParametersData))]
        public void tIQRCodeParametersPropertyTest(string name, object value, bool isPrivate)
        {
            IQRCodeParameters iIQRCodeParameters = WiaSystem.Job.SelectedConfig.ReadSettings.QR;
            this.PropertyTest(iIQRCodeParameters, name, value, isPrivate);
        }
    }
}