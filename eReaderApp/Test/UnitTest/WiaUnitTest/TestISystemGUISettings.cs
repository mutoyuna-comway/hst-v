
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia.Abstructions;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// SystemGUISettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// SystemGUISettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestISystemGUISettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestISystemGUISettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copySystemGUISettings = getCopyIWiaSystem().GUISettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "LibraryMode", true, false };
                yield return new object[] { "ShowInTaskbar", true, false };
                yield return new object[] { "GUILock", true, false };
                yield return new object[] { "WindowMinimized", true, false };
                yield return new object[] { "DispMode", DisplayModeType.Monitor, false };
                yield return new object[] { "LogDispLines", 1, false };
                yield return new object[] { "AutoSaveScreen", true, false };
                yield return new object[] { "AppsCloseActionReborn", AppsCloseActionType.MoveToSystemTray, false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestISystemGUISettingsData))]
        public void ISystemGUISettingsPropertyTest(string name, object value, bool isPrivate)
        {
            ISystemGUISettings iSystemGUISettings = WiaSystem.GUISettings;
            this.PropertyTest(iSystemGUISettings, name, value, isPrivate);
        }
    }
}