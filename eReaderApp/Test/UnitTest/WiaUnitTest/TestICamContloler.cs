
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// CamContlolerのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// CamContlolerのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestICamContloler : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestICamContlolerData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyCamContloler = getCopyICamContloler();
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "IsRealDevice", true, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestICamContlolerData))]
        public void ICamContlolerPropertyTest(string name, object value, bool isPrivate)
        {
            ICamContloler iCamContloler = CamContloler;
            this.PropertyTestWithoutINotifyPropertyChanged(iCamContloler, name, value, isPrivate);
        }
    }
}