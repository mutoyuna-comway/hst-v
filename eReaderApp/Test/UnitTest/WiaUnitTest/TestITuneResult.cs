
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// TuneResultのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// TuneResultのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TesITuneResult : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestITuneResultData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyTuneResult = getCopyIWiaSystem().Job.SelectedConfig.TuneLatestResult;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Mark", MarkType.QR, true };
                yield return new object[] { "Progress", 10.0, true };
                yield return new object[] { "NumRead", 10, true };
                yield return new object[] { "CurrentPassed", true, true };
                yield return new object[] { "CurrentString", "", true };
                yield return new object[] { "CurrentScore", 10.0, true };
                yield return new object[] { "BestPassed", true, true };
                yield return new object[] { "BestString", "", true };
                yield return new object[] { "BestScore", 10.0, true };
                yield return new object[] { "NumTunePassed", 10, true };
                yield return new object[] { "NumTuneFailed", 10, true };
                yield return new object[] { "CurrentMinimumScore", 10.0, true };
                yield return new object[] { "BestMinimumScore", 10.0, true };
                yield return new object[] { "BestRead", copyTuneResult.BestRead, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestITuneResultData))]
        public void ITuneResultPropertyTest(string name, object value, bool isPrivate)
        {
            ITuneResult iTuneResult = WiaSystem.Job.SelectedConfig.TuneLatestResult;
            this.PropertyTest(iTuneResult, name, value, isPrivate);
        }
    }
}