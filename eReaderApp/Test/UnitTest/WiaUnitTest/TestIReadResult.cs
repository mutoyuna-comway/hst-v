
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// ReadResultのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// ReadResultのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIReadResult : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIReadResultData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyReadResult = getCopyIWiaSystem().Job.SelectedConfig.ReadSettings.LatestResult;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Mark", MarkType.QR, true };
                yield return new object[] { "ReadString", "", true };
                yield return new object[] { "Score", 10.0, true };
                yield return new object[] { "MinScore", 10.0, true };
                yield return new object[] { "ElapsedTime", 10.0, true };
                yield return new object[] { "ConfigID", 10, true };
                yield return new object[] { "ROI", copyReadResult.ROI, true };
                yield return new object[] { "CharSize", copyReadResult.CharSize, true };
                yield return new object[] { "Pass", true, true };
                yield return new object[] { "IsTimeout", true, true };
                yield return new object[] { "ConfusionString", "", true };
                yield return new object[] { "IsCorrectConfChecksum", true, true };
                yield return new object[] { "OcrResults", copyReadResult.OcrResults, true };
                yield return new object[] { "ReadSettings", copyReadResult.ReadSettings, true };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIReadResultData))]
        public void IReadResultPropertyTest(string name, object value, bool isPrivate)
        {
            IReadResult iReadResult = WiaSystem.Job.SelectedConfig.ReadSettings.LatestResult;
            this.PropertyTest(iReadResult, name, value, isPrivate);
        }
    }

    /// <summary>
    /// ReadOcrResultのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIReadOcrResult : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIReadOcrResultData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyReadOcrResult = getCopyIWiaSystem().Job.SelectedConfig.ReadSettings.LatestResult.OcrResults[0];
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Character", 'A', true };
                yield return new object[] { "Value", 10, true };
                yield return new object[] { "Row", 10.0, true };
                yield return new object[] { "Col", 10.0, true };
                yield return new object[] { "PassCharTh", true, true };
                yield return new object[] { "FoundChecksumFirst", true, true };
                yield return new object[] { "IsSymbol", true, true };
                yield return new object[] { "IsFound", true, true };
                yield return new object[] { "IsConfusion", true, true };
                yield return new object[] { "LSError", 10, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIReadOcrResultData))]
        public void IReadOcrResultPropertyTest(string name, object value, bool isPrivate)
        {
            IReadOcrResult iReadOcrResult = WiaSystem.Job.SelectedConfig.ReadSettings.LatestResult.OcrResults[0];
            this.PropertyTest(iReadOcrResult, name, value, isPrivate);
        }
    }
}