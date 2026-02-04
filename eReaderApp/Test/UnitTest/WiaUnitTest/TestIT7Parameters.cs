
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// T7Parametersのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// T7Parametersのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIT7Parameters : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIT7ParametersData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyT7Parameters = getCopyIWiaSystem().Job.SelectedConfig.ReadSettings.T7;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Timeout", 10.0, false };
                yield return new object[] { "ErrorBit", 10, false };
                yield return new object[] { "ErrorNum", 10, false };
                yield return new object[] { "Operation", T7OperationMode.Normal, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIT7ParametersData))]
        public void IT7ParametersPropertyTest(string name, object value, bool isPrivate)
        {
            IT7Parameters iT7Parameters = WiaSystem.Job.SelectedConfig.ReadSettings.T7;
            this.PropertyTest(iT7Parameters, name, value, isPrivate);
        }
    }
}