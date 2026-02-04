
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SystemReadSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SystemReadSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISystemReadSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISystemReadSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copySystemReadSettings = getCopyIWiaSystem().ReadSettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ChecksumOmmission",true, false };
                yield return new object[] { "ScoreSetting", ScoreRange.Range1000, false };
                yield return new object[] { "WaferScoreAs100", ScoreAs100.Include100, false };
                yield return new object[] { "DisableOutputResultString", true, false };
                yield return new object[] { "DisableOutputResultOKNG", true, false };
                yield return new object[] { "DisableOutputResultScore", true, false };
                yield return new object[] { "DisplayChecksumFirstAsAstah", true, false };
                yield return new object[] { "TuneCompleteTimeout", 10, false };
                yield return new object[] { "TuneContinueInterval", 10, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISystemReadSettingsData))]
        public void ISystemReadSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISystemReadSettings iSystemReadSettings = WiaSystem.ReadSettings;
            this.PropertyTest(iSystemReadSettings, name, value, isPrivate);
        }
    }
}