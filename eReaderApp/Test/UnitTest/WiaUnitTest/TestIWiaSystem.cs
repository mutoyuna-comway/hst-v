using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using Wia.Abstractions;

namespace TestWiaSystem
{
    [TestClass]
    public class TestIWiaSystem : AbstractTest
    {
        /// <summary>
        /// 全プロパティの定義チェック用データ
        /// </summary>
        public static IEnumerable<object[]> TestIWiaSystemData
        {
            get
            {
                IWiaSystem iWiaSystem = WiaSystem;

                // インターフェイス上 {get;} のものは isPrivate=true として扱います
                // インターフェイス上 {get; set;} のものは isPrivate=false として扱います

                // オブジェクト系プロパティ
                yield return new object[] { nameof(iWiaSystem.AcquisitionSettings), ShallowCopy(iWiaSystem.AcquisitionSettings), true };
                yield return new object[] { nameof(iWiaSystem.SystemSettings), ShallowCopy(iWiaSystem.SystemSettings), true };
                yield return new object[] { nameof(iWiaSystem.GUISettings), ShallowCopy(iWiaSystem.GUISettings), true };
                yield return new object[] { nameof(iWiaSystem.CommunicationSettings), ShallowCopy(iWiaSystem.CommunicationSettings), true };
                yield return new object[] { nameof(iWiaSystem.ReadSettings), ShallowCopy(iWiaSystem.ReadSettings), true };
                yield return new object[] { nameof(iWiaSystem.LogSettings), ShallowCopy(iWiaSystem.LogSettings), true };
                yield return new object[] { nameof(iWiaSystem.Device), ShallowCopy(iWiaSystem.Device), true };
                yield return new object[] { nameof(iWiaSystem.ImageSource), ShallowCopy(iWiaSystem.ImageSource), true }; // インターフェイスはGetOnly
                yield return new object[] { nameof(iWiaSystem.Job), ShallowCopy(iWiaSystem.Job), true };
                yield return new object[] { nameof(iWiaSystem.MaintenanceServices), ShallowCopy(iWiaSystem.MaintenanceServices), true };
                yield return new object[] { nameof(iWiaSystem.IdReadingService), ShallowCopy(iWiaSystem.IdReadingService), true };
                yield return new object[] { nameof(iWiaSystem.TuningService), ShallowCopy(iWiaSystem.TuningService), true };
                yield return new object[] { nameof(iWiaSystem.LatestAcquireResult), ShallowCopy(iWiaSystem.LatestAcquireResult), true };
                yield return new object[] { nameof(iWiaSystem.LatestAcquiredImage), ShallowCopy(iWiaSystem.LatestAcquiredImage), true };


                // 値・文字列系プロパティ
                yield return new object[] { nameof(iWiaSystem.AppVersion), "test", true };
                yield return new object[] { nameof(iWiaSystem.IsOnline), true, true };
                yield return new object[] { nameof(iWiaSystem.IsScreenLocked), true, false }; // Public Set
                yield return new object[] { nameof(iWiaSystem.IsAcquireDisabled), true, false }; // Public Set
                yield return new object[] { nameof(iWiaSystem.ActiveJobName), "test", true };
                yield return new object[] { nameof(iWiaSystem.ActiveJobLoadTime), default(DateTime), true };
                yield return new object[] { nameof(iWiaSystem.BootTime), default(DateTime), true };
                yield return new object[] { nameof(iWiaSystem.IsLiveViewActive), true, true };
                yield return new object[] { nameof(iWiaSystem.IsTuning), true, true };
                yield return new object[] { nameof(iWiaSystem.TuneCurrentState), TuneState.Waiting, true };
                yield return new object[] { nameof(iWiaSystem.TuneCurrentSeqNumber), 0, true };
                yield return new object[] { nameof(iWiaSystem.TuneCurrentConfigNumber), 0, true };


            }
        }

        [TestMethod]
        [DynamicData(nameof(TestIWiaSystemData))]
        public void IWiaSystemPropertyTest(string name, object value, bool isPrivate)
        {
            // プロパティの取得確認（AbstractTestの実装利用を想定）
            IWiaSystem iWiaSystem = WiaSystem;
            this.PropertyTest(iWiaSystem, name, value, isPrivate);
        }

        /// <summary>
        /// 単純実行可能なメソッドのテスト
        /// </summary>
        [TestMethod]
        public void TestEventTest()
        {
            IWiaSystem iWiaSystem = new StubIWiaSystem();
            bool eventFired = false;
            iWiaSystem.ScreenVisibilityChangeRequested += (s, e) => {
                eventFired = true;
            };
            iWiaSystem.SetScreenVisibility(true,50,100);
            Assert.IsTrue(eventFired);

            Assert.IsTrue(iWiaSystem.CreateNewJob());
            Assert.IsTrue(iWiaSystem.LoadJobFile("test"));
            Assert.IsTrue(iWiaSystem.SaveJobFile("test"));
            Assert.IsTrue(iWiaSystem.SaveJobOverwrite());
        }

        [TestMethod]
        public void TestGetFolder()
        {
            IWiaSystem iWiaSystem = new StubIWiaSystem();
            Assert.IsNotEmpty(iWiaSystem.GetJobFolder());
            Assert.IsNotEmpty(iWiaSystem.GetDeviceFolder());
        }
        //WriteCommandLogException
        [TestMethod]
        public void TestGoOnline_ShouldChangeIsOnline()
        {
            IWiaSystem iWiaSystem = new StubIWiaSystem();
            bool eventFired = false;
            iWiaSystem.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(iWiaSystem.IsOnline)) eventFired = true;
            };

            iWiaSystem.GoOnline();
            Assert.IsTrue(iWiaSystem.IsOnline);
            Assert.IsTrue(eventFired);

            eventFired = false;
            iWiaSystem.GoOffline();
            Assert.IsFalse(iWiaSystem.IsOnline);
            Assert.IsTrue(eventFired);
        }

        // 他の既存テスト（LoadJobFileなど）はそのまま利用可能です
        [TestMethod]
        public void TestLoadJobFile_ShouldUpdateActiveJobInfo()
        {
            IWiaSystem iWiaSystem = new StubIWiaSystem();
            string testPath = @"C:\Jobs\TestJob.wia";

            bool result = iWiaSystem.LoadJobFile(testPath);

            Assert.IsTrue(result);
            Assert.AreEqual("TestJob.wia", iWiaSystem.ActiveJobName);
            Assert.IsLessThan(1, (DateTime.Now - iWiaSystem.ActiveJobLoadTime).TotalMinutes);
        }



        // ------------------------------
        // 画像読み込み関連
        // ------------------------------

        [TestMethod]
        public void TestLoadBitmapFile_ShouldFireEventsAndDisableAcquire()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool acquireAvailableFired = false;

            iWiaSystem.AcquireImageAvailable += (s, e) => acquireAvailableFired = true;

            string path = @"C:\Images\test.bmp";
            bool result = iWiaSystem.LoadBitmapFile(path);

            Assert.IsTrue(result);
            Assert.IsTrue(iWiaSystem.IsAcquireDisabled, "IsAcquireDisabled is not true");
            Assert.IsTrue(acquireAvailableFired, "AcquireImageAvailable event not done");
        }

        // ------------------------------
        // 統計情報関連 (Stats)
        // ------------------------------

        [TestMethod]
        public void TestGetStatsResults_ShouldReturnCorrectValues()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int validConfigId = 1;

            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsCount());
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsPassNum(validConfigId));
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsFailNum(validConfigId));
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsAvgScore(validConfigId));
        }

        [TestMethod]
        public void TestGetStatsResults_OutOfRange_ShouldThrowException()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int invalidConfigId = 51; // Stub defines > 50 as error
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsPassNum(invalidConfigId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsFailNum(invalidConfigId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsAvgScore(invalidConfigId));
        }

        [TestMethod]
        public void TestConfigStats_ShouldReturnValues()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int validConfigId = 1;
            string dummyJob = "Test.wia";

            int numPassed, numFailed, score;

            Assert.IsTrue(iWiaSystem.GetConfigNumPassed(validConfigId, dummyJob, out numPassed));
            Assert.IsGreaterThanOrEqualTo(0, numPassed);

            Assert.IsTrue(iWiaSystem.GetConfigNumFailed(validConfigId, dummyJob, out numFailed));
            Assert.IsGreaterThanOrEqualTo(0, numFailed);

            Assert.IsTrue(iWiaSystem.GetConfigAvgScore(validConfigId, dummyJob, out score));
            Assert.IsGreaterThanOrEqualTo(0, score);
        }

        [TestMethod]
        public void TestConfigStats_OutOfRange_ShouldThrowException()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int invalidConfigId = 51;
            string dummyJob = "Test.wia";
            int outVal;

            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumPassed(invalidConfigId, dummyJob, out outVal));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumFailed(invalidConfigId, dummyJob, out outVal));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigAvgScore(invalidConfigId, dummyJob, out outVal));
        }

        [TestMethod]
        public void TestFindJobFilePath_ShouldReturnPath()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string dispName = "JobA";
            string path;

            bool result = iWiaSystem.FindJobFilePath(dispName, out path);

            Assert.IsTrue(result);
            Assert.AreEqual(@"C:\Jobs\JobA.wia", path);
        }

        [TestMethod]
        public void TestGetAllStats_ShouldReturnValues()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int validConfigId = 1;

            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllNumPassed(validConfigId));
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllNumFailed(validConfigId));
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllAverageScore(validConfigId));
        }

        [TestMethod]
        public void TestAllStatsClear_ApplicationExit_ShouldNotThrow()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            try
            {
                iWiaSystem.AllStatsClear();
                iWiaSystem.ApplicationExit(100);
            }
            catch (Exception ex)
            {
                Assert.Fail($"AllStatsClear threw exception: {ex.Message}");
            }
        }

        // ------------------------------
        // オブジェクト生成・取得関連
        // ------------------------------

        [TestMethod]
        public void TestCreateRecogCond_ShouldReturnInstance()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            var cond = iWiaSystem.CreateRecogCond();
            Assert.IsNotNull(cond);
        }

        [TestMethod]
        public void TestGetCamInfo_ShouldReturnInstance()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            var info = iWiaSystem.GetCamInfo();
            Assert.IsNotNull(info);
        }

        // ------------------------------
        // ライブビュー・画像取込関連
        // ------------------------------

        [TestMethod]
        public void TestLiveView_ShouldChangeStateAndFireEvents()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool startedFired = false;
            bool stoppedFired = false;
            bool acquireAvailableFired = false;

            iWiaSystem.LiveViewStarted += (s, e) => startedFired = true;
            iWiaSystem.LiveViewStopped += (s, e) => stoppedFired = true;
            iWiaSystem.AcquireImageAvailable += (s, e) => acquireAvailableFired = true;

            // Start Live View
            iWiaSystem.StartLiveView();

            Assert.IsTrue(iWiaSystem.IsLiveViewActive, "IsLiveViewActive is not true");
            Assert.IsTrue(startedFired, "LiveViewStarted event");
            Assert.IsTrue(acquireAvailableFired, "AcquireImageAvailable at start");

            // Stop Live View
            iWiaSystem.StopLiveView();

            Assert.IsFalse(iWiaSystem.IsLiveViewActive, "IsLiveViewActive is not false");
            Assert.IsTrue(stoppedFired, "LiveViewStopped event");
        }

        [TestMethod]
        public void TestAcquireImage_ShouldFireEvent()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool eventFired = false;

            iWiaSystem.AcquireImageAvailable += (s, e) => eventFired = true;

            bool result = iWiaSystem.AcquireImage(1);

            Assert.IsTrue(result);
            Assert.IsTrue(eventFired);
        }

        // ------------------------------
        // チューニング関連
        // ------------------------------

        [TestMethod]
        public void TestTuning_Lifecycle_ShouldWorkCorrectly()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int configId = 10;

            // 1. Tune Start
            int tuneId = iWiaSystem.TuneStart(configId, false);

            Assert.IsTrue(iWiaSystem.IsTuning, "in TuneStart. IsTuning is not true");
            Assert.AreEqual(TuneState.Running, iWiaSystem.TuneCurrentState);
            Assert.AreEqual(configId, iWiaSystem.TuneCurrentConfigNumber);
            Assert.IsTrue(iWiaSystem.TuneCurrentSeqNumber > 0);

            // 2. Tune Abort
            iWiaSystem.TuneAbort();

            Assert.IsFalse(iWiaSystem.IsTuning, "at TuneAbort. IsTuning is not false");
            Assert.AreEqual(TuneState.Completed, iWiaSystem.TuneCurrentState);

            // 3. Tune Start Again to test Judge
            iWiaSystem.TuneStart(configId, false);
            Assert.IsTrue(iWiaSystem.IsTuning);

            // 4. Tune Result Judge
            bool judgeResult = iWiaSystem.TuneResultJudge();

            Assert.IsTrue(judgeResult); // Stub returns true
            Assert.IsFalse(iWiaSystem.IsTuning, "after Judge. IsTuningis not false");
            Assert.AreEqual(TuneState.Waiting, iWiaSystem.TuneCurrentState);
        }
    }
}