
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// Jobのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// Jobのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIJob : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIJobData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyJob = getCopyIWiaSystem().Job;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ReadType", ReadMethod.All, false };
                yield return new object[] { "ScoreType", ScoreMode.MinScore, false };
                yield return new object[] { "SelectedConfig", copyJob.SelectedConfig, true };
                yield return new object[] { "SelectedConfigIndex", 10, false };
                yield return new object[] { "Configs", copyJob.Configs, true };
                yield return new object[] { "MaxNumConfig", MaxNumConfigType.Num16, false };
                yield return new object[] { "SystemService", getCopyIWiaSystem(), false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIJobData))]
        public void IJobPropertyTest(string name, object value, bool isPrivate)
        {
            IJob iJob = WiaSystem.Job;
            this.PropertyTest(iJob, name, value, isPrivate);
        }
    }
}