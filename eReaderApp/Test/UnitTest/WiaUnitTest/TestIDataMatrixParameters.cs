
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// DataMatrixParametersのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// DataMatrixParametersのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIDataMatrixParameters : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIDataMatrixParametersData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyDataMatrixParameters = getCopyIWiaSystem().Job.SelectedConfig.ReadSettings.DM;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "CharLimit", CharacterLimitationType.None, false };
                yield return new object[] { "ErrorBitSize", 10, false };
                yield return new object[] { "SpecifiedCellNum", true, false };
                yield return new object[] { "CellNum", DMGridSize.DMS10x10, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIDataMatrixParametersData))]
        public void IDataMatrixParametersPropertyTest(string name, object value, bool isPrivate)
        {
            IDataMatrixParameters iDataMatrixParameters = WiaSystem.Job.SelectedConfig.ReadSettings.DM;
            this.PropertyTest(iDataMatrixParameters, name, value, isPrivate);
        }
    }
}