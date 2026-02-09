
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
    public class TestIAcquireResult : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIAcquireResultData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyAcquireResult = getCopyIReadCompletedEventArgs().AcqResult;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AcqParams", copyAcquireResult.AcqParams, true };
                yield return new object[] { "ElapsedAcqTime", 10.0, true };
                yield return new object[] { "ElapsedProcTime", 10.0, true };
                yield return new object[] { "ProcessImage", copyAcquireResult.ProcessImage, true };
                yield return new object[] { "DisplayImage", copyAcquireResult.DisplayImage, true };
                yield return new object[] { "AcqSucceed", true, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIAcquireResultData))]
        public void IAcquireResultPropertyTest(string name, object value, bool isPrivate)
        {
            IAcquireResult iAcquireResult = ReadCompletedEventArgs.AcqResult;
            this.PropertyTest(iAcquireResult, name, value, isPrivate);
        }
    }
}