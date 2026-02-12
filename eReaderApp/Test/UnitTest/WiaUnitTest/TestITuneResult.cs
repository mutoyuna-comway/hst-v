
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.Runtime;
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
                var copyTuneResult = WiaSystem.Job.SelectedConfig.Clone().TuneLatestResult;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Mark", MarkType.QR, true };
                yield return new object[] { "NumRead", 10, true };
                yield return new object[] { "CurrentPassed", true, true };
                yield return new object[] { "CurrentString", "", true };
                yield return new object[] { "CurrentScore", 10.0, true };
                yield return new object[] { "NumTunePassed", 10, true };
                yield return new object[] { "NumTuneFailed", 10, true };
                yield return new object[] { "CurrentMinimumScore", 10.0, true };
                yield return new object[] { "BestMinimumScore", 10.0, true };
                yield return new object[] { "AcqSettings", copyTuneResult.AcqSettings.Clone(), true };
                yield return new object[] { "ReadSettings", copyTuneResult.ReadSettings.Clone(), true };
                yield return new object[] { "BestAcqSettings", copyTuneResult.BestAcqSettings.Clone(), true };
                yield return new object[] { "BestReadSettings", copyTuneResult.BestReadSettings.Clone(), true };
                yield return new object[] { "BestPassedImage", copyTuneResult.Clone().BestPassedImage, true };
                yield return new object[] { "BestRecordNumber", 2, true };
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