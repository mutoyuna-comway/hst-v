
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Wia.Abstractions;
/// <summary>
/// JobConfigのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    [TestClass]
    public class TestIJobConfig : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIJobConfigData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyConfig = getCopyIWiaSystem().Job.SelectedConfig;
                /*  プロパティ名。テスト用の設定値,プライベートプロパティか否か */
                yield return new object[] { "ConfigID", 10, true };
                yield return new object[] { "AcquireSettings", copyConfig.AcquireSettings, false };
                yield return new object[] { "ReadSettings", copyConfig.ReadSettings, false };
                yield return new object[] { "TuneSettings", copyConfig.TuneSettings, false };
                yield return new object[] { "TuneLatestResult", copyConfig.TuneLatestResult, false };
                yield return new object[] { "Enable", true, false };
                yield return new object[] { "IsReadCompletedEventEnabled", true, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        /// <param name="name">プロパティ名 </param>
        /// <param name="value">テスト用の設定値</param>
        /// <param name="isPrivate">プライベートプロパティか否か</param>
        [TestMethod]
        [DynamicData(nameof(TestIJobConfigData))]
        public void IJobConfigPropertyTest(string name, object value, Boolean isPrivate) {
            IJobConfig iJobConfig = WiaSystem.Job.SelectedConfig;
            this.PropertyTest(iJobConfig, name, value, isPrivate);
        }


    }
}