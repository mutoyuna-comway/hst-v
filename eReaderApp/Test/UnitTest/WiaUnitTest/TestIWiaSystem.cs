
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// WiaSystemのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// WiaSystemのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIWiaSystem : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIWiaSystemData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                IWiaSystem iWiaSystem = WiaSystem;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AcquisitionSettings", ShallowCopy(iWiaSystem.AcquisitionSettings), true };
                yield return new object[] { "SystemSettings", ShallowCopy(iWiaSystem.SystemSettings), true };
                yield return new object[] { "GUISettings", ShallowCopy(iWiaSystem.GUISettings), true };
                yield return new object[] { "CommunicationSettings", ShallowCopy(iWiaSystem.CommunicationSettings), true };
                yield return new object[] { "ReadSettings", ShallowCopy(iWiaSystem.ReadSettings), true };
                yield return new object[] { "LogSettings", ShallowCopy(iWiaSystem.LogSettings), true };
                yield return new object[] { "Device", ShallowCopy(iWiaSystem.Device), true };
                yield return new object[] { "ImageSource", ShallowCopy(iWiaSystem.ImageSource), true };
                yield return new object[] { "CommManager", ShallowCopy(iWiaSystem.CommManager), true };
                yield return new object[] { "Job", ShallowCopy(iWiaSystem.Job), true };
                yield return new object[] { "MaintenanceServices", ShallowCopy(iWiaSystem.MaintenanceServices), true };
                yield return new object[] { "AppVersion", "", true };
                yield return new object[] { "IsOnline", true, true };
                yield return new object[] { "IsScreenLocked", true, false };
                yield return new object[] { "IsAcquireDisabled", true, false };
                yield return new object[] { "ActiveJobName", "", true };
                yield return new object[] { "ActiveJobLoadTime", new DateTime(2025, 1, 1, 10, 30, 0), true };
                yield return new object[] { "BootTime", new DateTime(2025, 1, 1, 10, 30, 0), true };
                yield return new object[] { "IsTuning", true, true };
                yield return new object[] { "TuneCurrentState", TuneState.Waiting, true };
                yield return new object[] { "TuneCurrentSeqNumber", 10, true };
                yield return new object[] { "TuneCurrentConfigNumber", 10, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIWiaSystemData))]
        public void IWiaSystemPropertyTest(string name, object value, bool isPrivate)
        {
            IWiaSystem iWiaSystem = WiaSystem;
            this.PropertyTest(iWiaSystem, name, value, isPrivate);
        }

        /// <summary>
        /// オンライン・オフライン切り替えのテスト
        /// </summary>
        [TestMethod]
        public void GoOnlineOffline_ShouldChangeIsOnline()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            iWiaSystem.GoOnline();
            Assert.IsTrue(iWiaSystem.IsOnline, "GoOnline後にIsOnlineがtrueになっていません。");

            iWiaSystem.GoOffline();
            Assert.IsFalse(iWiaSystem.IsOnline, "GoOffline後にIsOnlineがfalseになっていません。");
        }

        /// <summary>
        /// ライブビュー開始・停止とイベントのテスト
        /// </summary>
        [TestMethod]
        public void LiveView_ShouldChangeStateAndFireEvent()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool startedFired = false;
            bool stoppedFired = false;

            iWiaSystem.LiveViewStarted += (s, e) => startedFired = true;
            iWiaSystem.LiveViewStopped += (s, e) => stoppedFired = true;

            iWiaSystem.StartLiveView();
            Assert.IsTrue(iWiaSystem.IsLiveViewActive);
            Assert.IsTrue(startedFired, "LiveViewStartedイベントが発火していません。");

            iWiaSystem.StopLiveView();
            Assert.IsFalse(iWiaSystem.IsLiveViewActive);
            Assert.IsTrue(stoppedFired, "LiveViewStoppedイベントが発火していません。");
        }

        /// <summary>
        /// ジョブ読み込み時のプロパティ更新テスト
        /// </summary>
        [TestMethod]
        public void LoadJobFile_ShouldUpdateActiveJobInfo()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string testPath = @"C:\Jobs\TestJob.wia";

            bool result = iWiaSystem.LoadJobFile(testPath);

            Assert.IsTrue(result);
            Assert.AreEqual("TestJob.wia", iWiaSystem.ActiveJobName);
            // ロード時間が直近（1分以内）であることを確認
            Assert.IsLessThan(1, (DateTime.Now - iWiaSystem.ActiveJobLoadTime).TotalMinutes);
        }

        [TestMethod]
        public void Test_LoadBitmapFile_DisablesAcquire()
        {
            var system = WiaSystem;
            system.IsAcquireDisabled = false;

            bool result = system.LoadBitmapFile("test.bmp");

            Assert.IsTrue(result);
            Assert.IsTrue(system.IsAcquireDisabled, "ビットマップ読み込み後は取込みが無効になること");
        }

        [TestMethod]
        public void Test_SetScreenVisibility_EventWithArgs()
        {
            var system = WiaSystem;
            bool eventFired = false;

            system.ScreenVisibilityChangeRequested += (s, e) => {
                eventFired = true;
                Assert.IsTrue(e.IsVisible);
                Assert.AreEqual(100, e.LocationX);
                Assert.AreEqual(200, e.LocationY);
            };

            system.SetScreenVisibility(true, 100, 200);
            Assert.IsTrue(eventFired, "画面表示変更イベントが正しい引数で発行されること");
        }

        [TestMethod]
        public void Test_Tuning_StateManagement()
        {
            var system = WiaSystem;

            system.TuneStart(5, false);
            Assert.IsTrue(system.IsTuning);
            Assert.AreEqual(5, system.TuneCurrentConfigNumber);

            system.TuneAbort();
            Assert.IsFalse(system.IsTuning, "TuneAbort後はIsTuningがfalseになること");
        }

    }
}