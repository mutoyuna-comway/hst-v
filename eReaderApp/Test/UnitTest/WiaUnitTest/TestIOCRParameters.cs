
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// OCRParametersのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// OCRParametersのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIOCRParameters : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIOCRParametersData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "CustomFontIDString", "", false };
                yield return new object[] { "Operation", OCROperationMode.Normal, false };
                yield return new object[] { "ConfusionThreshold", 10.0, false };
                yield return new object[] { "UseConfusionChecksum", true, false };
                yield return new object[] { "Preprocess", PreprocessType.Gaussian, false };
                yield return new object[] { "StrokeFilter", FilterType.BlackHat, false };
                yield return new object[] { "StrokeFilterSize", 10, false };
                yield return new object[] { "NominalPitchRatio", 10.0, false };
                yield return new object[] { "EnableWideRangeCharacter", true, false };
                yield return new object[] { "ReadingRetry", ReadRetryMode.HorizontalRemove, false };
                yield return new object[] { "CheckSumFirst", ChecksumFirstType.AddCS, false };
                yield return new object[] { "GridJudge", OCRGridJudgeMode.Auto, false };
                yield return new object[] { "SymbolAccept", 10.0, false };
                yield return new object[] { "SymbolReading", true, false };
                yield return new object[] { "CharacterThreshold", 10, false };
                yield return new object[] { "BaseLineError", 10, false };
                yield return new object[] { "SpaceError", 10, false };
                yield return new object[] { "InternalFilter", InternalFilterType.HorizontalRemoveFilter, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIOCRParametersData))]
        public void IOCRParametersPropertyTest(string name, object value, bool isPrivate)
        {
            IOCRParameters iOCRParameters = WiaSystem.Job.SelectedConfig.ReadSettings.OCR;
            this.PropertyTest(iOCRParameters, name, value, isPrivate);
        }
    }
}