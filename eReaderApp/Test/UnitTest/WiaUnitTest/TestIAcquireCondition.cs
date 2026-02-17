
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// AcquireResultのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// AcquireResultのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIAcquireCondition : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIAcquireConditionData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                IAcquireResult iAcquireResult = ReadCompletedEventArgs.AcqResult;
                yield return new object[] { "AcqParams", ShallowCopy(iAcquireResult.AcqParams), true };
                yield return new object[] { "ElapsedAcqTime", 10.0, true };
                yield return new object[] { "ElapsedProcTime", 10.0, true };
                yield return new object[] { "ProcessImage", ShallowCopy(iAcquireResult.ProcessImage), true };
                yield return new object[] { "DisplayImage", ShallowCopy(iAcquireResult.DisplayImage), true };
                yield return new object[] { "AcqSucceed", true, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIAcquireConditionData))]
        public void IAcquireResultPropertyTest(string name, object value, bool isPrivate)
        {
            IAcquireResult iAcquireResult = ReadCompletedEventArgs.AcqResult;
            this.PropertyTest(iAcquireResult, name, value, isPrivate);
        }
    }
}