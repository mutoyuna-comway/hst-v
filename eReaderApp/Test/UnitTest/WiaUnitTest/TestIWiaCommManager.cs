
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// WiaCommManagerのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// WiaCommManagerのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIWiaCommManager : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIWiaCommManagerData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Delimeter", DelimeterType.CR, false };
                yield return new object[] { "SocketPort",10UL, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIWiaCommManagerData))]
        public void IWiaCommManagerPropertyTest(string name, object value, bool isPrivate)
        {
            IWiaCommManager iWiaCommManager = WiaSystem.CommManager;
            this.PropertyTest(iWiaCommManager, name, value, isPrivate);
        }
    }
}