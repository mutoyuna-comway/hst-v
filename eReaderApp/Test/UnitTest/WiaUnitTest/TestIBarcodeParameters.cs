
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// BarcodeParametersのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// BarcodeParametersのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIBarcodeParameters : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIBarcodeParametersData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyBarcodeParameters = getCopyIWiaSystem().Job.SelectedConfig.ReadSettings.Barcode;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Operation", BarcodeOperationMode.Normal, false };
                yield return new object[] { "DisableFieldString", true, false };
                yield return new object[] { "DisableChecksum", true, false };
                yield return new object[] { "DisableColorSpecified", true, false };
                yield return new object[] { "DisableSymbolSpecified", true, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIBarcodeParametersData))]
        public void IJobPropertyTest(string name, object value, bool isPrivate)
        {
            IBarcodeParameters iBarcodeParameters = WiaSystem.Job.SelectedConfig.ReadSettings.Barcode;
            this.PropertyTest(iBarcodeParameters, name, value, isPrivate);
        }
    }
}