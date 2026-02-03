
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// RecogConditionのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// RecogConditionのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIRecogCondition : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIRecogConditionData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyRecogCondition = getCopyIRecogCondition();
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ConfigId", 10, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIRecogConditionData))]
        public void IRecogConditionPropertyTest(string name, object value, bool isPrivate)
        {
            IRecogCondition iRecogCondition = RecogCondition;
            this.PropertyTest(iRecogCondition, name, value, isPrivate);
        }
    }
}