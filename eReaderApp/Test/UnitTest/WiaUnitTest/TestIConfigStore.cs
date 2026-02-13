
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// ConfigStoreのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// ConfigStoreのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIConfigStore : AbstractTest
    {

        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIConfigStoreData
        {
            get
            {
                IConfigStore iConfigStore = WiaSystem.Job.Configs;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ParentJob", ShallowCopy(iConfigStore.ParentJob), true };
                yield return new object[] { "Count", 10, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIConfigStoreData))]
        public void IConfigStorePropertyTest(string name, object value, bool isPrivate)
        {
            IConfigStore iConfigStore = WiaSystem.Job.Configs;
            this.PropertyTest(iConfigStore, name, value, isPrivate);
        }

    }
}