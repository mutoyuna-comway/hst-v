using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Wia.Abstractions;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

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
                yield return new object[] { nameof(iWiaSystem.Job), ShallowCopy(iWiaSystem.Job), true };
                yield return new object[] { nameof(iWiaSystem.LatestAcquireResult), ShallowCopy(iWiaSystem.LatestAcquireResult), true };
                yield return new object[] { nameof(iWiaSystem.LatestAcquiredImage), ShallowCopy(iWiaSystem.LatestAcquiredImage), true };


                // 値・文字列系プロパティ
                yield return new object[] { nameof(iWiaSystem.IsOnline), true, true };
                yield return new object[] { nameof(iWiaSystem.IsScreenLocked), true, false };
                yield return new object[] { nameof(iWiaSystem.IsAcquireDisabled), true, false };
                yield return new object[] { nameof(iWiaSystem.ActiveJobName), "test", true };
                yield return new object[] { nameof(iWiaSystem.ActiveJobLoadTime), default(DateTime), true };
                yield return new object[] { nameof(iWiaSystem.IsLiveViewActive), true, true };
                yield return new object[] { nameof(iWiaSystem.IsTuning), true, true };
                yield return new object[] { nameof(iWiaSystem.TuneCurrentState), TuneState.Waiting, true };
                yield return new object[] { nameof(iWiaSystem.TuneCurrentSeqNumber), 0, true };
                yield return new object[] { nameof(iWiaSystem.TuneCurrentConfigNumber), 0, true };


            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="isPrivate"></param>
        [TestMethod]
        [DynamicData(nameof(TestIWiaSystemData))]
        public void IWiaSystemPropertyTest(string name, object value, bool isPrivate)
        {
            // プロパティの取得確認（AbstractTestの実装利用を想定）
            IWiaSystem iWiaSystem = WiaSystem;
            this.PropertyTest(iWiaSystem, name, value, isPrivate);
        }

        /// <summary>
        /// ReadOnlyのプロパティのテスト 値が変更されることのないプロパティのテスト
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="isPrivate"></param>
        [TestMethod]
        public void IWiaSystemReadOnlyPropertyTest()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            // インスタンス
            Assert.IsNotNull(iWiaSystem.AcquisitionSettings, nameof(iWiaSystem.AcquisitionSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.SystemSettings, nameof(iWiaSystem.SystemSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.GUISettings, nameof(iWiaSystem.GUISettings) + " is null");
            Assert.IsNotNull(iWiaSystem.CommunicationSettings, nameof(iWiaSystem.CommunicationSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.ReadSettings, nameof(iWiaSystem.ReadSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.LogSettings, nameof(iWiaSystem.LogSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.Device, nameof(iWiaSystem.Device) + " is null");
            Assert.IsNotNull(iWiaSystem.ImageSource, nameof(iWiaSystem.ImageSource) + " is null");
            Assert.IsNotNull(iWiaSystem.MaintenanceServices, nameof(iWiaSystem.MaintenanceServices) + " is null");
            Assert.IsNotNull(iWiaSystem.IdReadingService, nameof(iWiaSystem.IdReadingService) + " is null");
            Assert.IsNotNull(iWiaSystem.TuningService, nameof(iWiaSystem.TuningService) + " is null");

            // 変数
            Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem) + nameof(iWiaSystem.AppVersion)), iWiaSystem.AppVersion);
            Assert.IsLessThanOrEqualTo(DateTime.Now, iWiaSystem.BootTime,"boot time is not before current time");//現在時刻よりも前のはず
        }

        // =========================================================
        // 各メソッドのテスト (1関数につき1テストメソッド)
        // =========================================================

        /// <summary>
        /// ApplicationExitのテスト
        /// </summary>
        [TestMethod]
        public void TestApplicationExit()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            //10msでApplicationExitを指定して実行、50ms後であればイベントは動いているはずなのでそこでイベントチェック
            try
            {
                iWiaSystem.ApplicationExit(10);
                bool eventFired = false;
                iWiaSystem.CloseApplicationRequested += (s, e) => {
                    eventFired = true;
                };
                Task.Delay(50).ContinueWith(t =>
                {
                    Assert.IsTrue(eventFired, "CloseApplicationRequested event is not fired");
                });
            }
            catch (Exception ex)
            {
                Assert.Fail($"ApplicationExit is fail: {ex.Message}");
            }
        }
        /// <summary>
        /// GetJobFolderのテスト
        /// </summary>
        [TestMethod]
        public void TestGetJobFolder()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string folder = iWiaSystem.GetJobFolder();
            Assert.IsFalse(string.IsNullOrEmpty(folder), "GetJobFolder is fail: returned null or empty");
            //　runsettingsから実行環境による期待値を取得して比較する
            Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem) + "JobFolder"), folder, "GetJobFolder path is incorrect");
        }
        /// <summary>
        /// GetDeviceFolderのテスト
        /// </summary>
        [TestMethod]
        public void TestGetDeviceFolder()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string folder = iWiaSystem.GetDeviceFolder();
            Assert.IsFalse(string.IsNullOrEmpty(folder), "GetDeviceFolder is fail: returned null or empty");
            //　runsettingsから実行環境による期待値を取得して比較する
            Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem) + "DeviceFolder"), folder, "GetJobFolder path is incorrect");
        }
        /// <summary>
        /// WriteCommandLogExceptionのテスト
        /// </summary>
        [TestMethod]
        public void TestWriteCommandLogException()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            // ログ出力中に例外がスローされないことを確認
            try
            {
                iWiaSystem.WriteCommandLogException(new Exception("Test Exception"), "Test Message");
            }
            catch (Exception ex)
            {
                Assert.Fail($"WriteCommandLogException is fail: {ex.Message}");
            }
            // 異常系
            ExceptionTest<ArgumentException>(() => iWiaSystem.WriteCommandLogException(null, ""));
        }
        /// <summary>
        /// SetScreenVisibilityのテスト
        /// </summary>
        [TestMethod]
        public void TestSetScreenVisibility()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            // イベントの発火と値の確認を行う
            bool eventFired = false;
            iWiaSystem.ScreenVisibilityChangeRequested += (s, e) => {
                eventFired = true;
                Assert.IsTrue(e.IsVisible, "IsVisible is incorrect in event args");
                Assert.AreEqual(50, e.LocationX, "LocationX is incorrect in event args");
                Assert.AreEqual(100, e.LocationY, "LocationY is incorrect in event args");
            };

            iWiaSystem.SetScreenVisibility(true, 50, 100);
            Assert.IsTrue(eventFired, "ScreenVisibilityChangeRequested event is not fired");
        }
        /// <summary>
        /// CreateNewJobのテスト
        /// </summary>
        [TestMethod]
        public void TestCreateNewJob()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            // イベントの発火と値の確認を行う
            DateTime time = DateTime.Now;
            bool eventFired1 = false;
            bool eventFired2 = false;
            iWiaSystem.JobChanging += (s, e) => {
                eventFired1 = true; //ジョブ変更中イベント
            };
            iWiaSystem.JobChanged += (s, e) => {
                eventFired2 = true; //ジョブ変更完了イベント
            };

            Assert.IsTrue(iWiaSystem.CreateNewJob(), "CreateNewJob is fail");
            // ロード時間が更新され、テスト開始時の時刻よりも後であること
            Assert.IsGreaterThanOrEqualTo(iWiaSystem.ActiveJobLoadTime, time, "ActiveJobLoadTime is not updated");
            // runsettingsから実行環境による期待値を取得して比較する
            Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem) + "NewJob"), iWiaSystem.ActiveJobName, "ActiveJobName is not updated to NewJob");
            Assert.IsTrue(eventFired1, "JobChanging event is not fired");
            Assert.IsTrue(eventFired2, "JobChanged event is not fired");
        }
        /// <summary>
        /// LoadJobFileのテスト
        /// </summary>
        [TestMethod]
        public void TestLoadJobFile()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string testPath = @"C:\Jobs\TestJob.wia";
            DateTime time = DateTime.Now;
            bool eventFired1 = false;
            bool eventFired2 = false;
            // イベントの発火と値の確認を行う
            iWiaSystem.JobChanging += (s, e) => {
                eventFired1 = true; //ジョブ変更中イベント
            };
            iWiaSystem.JobChanged += (s, e) => {
                eventFired2 = true; //ジョブ変更完了イベント
            };

            Assert.IsTrue(iWiaSystem.LoadJobFile(testPath), "LoadJobFile is fail");
            // ロード時間が更新され、テスト開始時の時刻よりも後であること
            Assert.IsGreaterThanOrEqualTo(iWiaSystem.ActiveJobLoadTime, time, "ActiveJobLoadTime is not updated");
            // Job名がパスが取り除かれファイル名だけになっている
            Assert.AreEqual(System.IO.Path.GetFileName(testPath), iWiaSystem.ActiveJobName, "ActiveJobName is not updated correctly");
            Assert.IsTrue(eventFired1, "JobChanging event is not fired");
            Assert.IsTrue(eventFired2, "JobChanged event is not fired");

            // 異常系 
            Assert.IsFalse(iWiaSystem.LoadJobFile(""), "LoadJobFile is not fail");
        }
        /// <summary>
        /// SaveJobFileのテスト
        /// </summary>
        [TestMethod]
        public void TestSaveJobFile()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string testPath = @"C:\Jobs\SavedJob.wia";
            DateTime time = DateTime.Now;

            Assert.IsTrue(iWiaSystem.SaveJobFile(testPath), "SaveJobFile is fail");
            // Job名がパスが取り除かれファイル名だけになっている
            Assert.AreEqual(System.IO.Path.GetFileName(testPath), iWiaSystem.ActiveJobName, "ActiveJobName is not updated correctly");
            // ロード時間が更新され、テスト開始時の時刻よりも後であること
            Assert.IsGreaterThanOrEqualTo(iWiaSystem.ActiveJobLoadTime, time, "ActiveJobLoadTime is not updated");

            // 異常系 
            Assert.IsFalse(iWiaSystem.SaveJobFile(""), "LoadJobFile is not fail");
        }
        /// <summary>
        /// SaveJobOverwriteのテスト
        /// </summary>
        [TestMethod]
        public void TestSaveJobOverwrite()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool eventFired = false;

            // 上書き用にダミーのジョブ名をセット
            iWiaSystem.CreateNewJob();

            iWiaSystem.PropertyChanged += (s, e) => {
                if (e.PropertyName == nameof(iWiaSystem.ActiveJobName)) eventFired = true;
            };

            Assert.IsTrue(iWiaSystem.SaveJobOverwrite(), "SaveJobOverwrite is fail");
            Assert.IsTrue(eventFired, "PropertyChanged event for ActiveJobName is not fired");

            // 異常系 
            privateSet(iWiaSystem,nameof(iWiaSystem.ActiveJobName),"");//エラーになるようにファイル名を空にする
            Assert.IsFalse(iWiaSystem.SaveJobOverwrite(), "SaveJobOverwrite is not fail");
        }
        /// <summary>
        /// LoadBitmapFileのテスト
        /// </summary>
        [TestMethod]
        public void TestLoadBitmapFile()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            //イベントの発火と値の変更確認
            bool acquireAvailableFired = false;
            iWiaSystem.AcquireImageAvailable += (s, e) => acquireAvailableFired = true;

            string path = @"C:\Images\test.bmp";
            Assert.IsTrue(iWiaSystem.LoadBitmapFile(path), "LoadBitmapFile is fail");
            Assert.IsTrue(iWiaSystem.IsAcquireDisabled, "IsAcquireDisabled is not true after loading bitmap");
            Assert.IsTrue(acquireAvailableFired, "AcquireImageAvailable event is not fired");
            // 異常系 
            Assert.IsFalse(iWiaSystem.LoadBitmapFile(""), "AcquireImageAvailable is not fail");
        }
        /// <summary>
        /// GoOnlineのテスト
        /// </summary>
        [TestMethod]
        public void TestGoOnline()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            //値の変更確認
            iWiaSystem.GoOnline();
            Assert.IsTrue(iWiaSystem.IsOnline, "GoOnline is fail: IsOnline is false");
        }
        /// <summary>
        /// GoOfflineのテスト
        /// </summary>
        [TestMethod]
        public void TestGoOffline()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            //値の変更確認
            iWiaSystem.GoOnline(); // 一度オンラインにする
            Assert.IsTrue(iWiaSystem.IsOnline, "GoOnline is fail: IsOnline is false");//一応trueになったことを見ておく
            iWiaSystem.GoOffline();
            Assert.IsFalse(iWiaSystem.IsOnline, "GoOffline is fail: IsOnline is true");
        }
        /// <summary>
        /// GetStatsResultsCountのテスト
        /// </summary>
        [TestMethod]
        public void TestGetStatsResultsCount()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int count = iWiaSystem.GetStatsResultsCount();
            // 0以上の数値が返ってくる
            Assert.IsGreaterThanOrEqualTo(0, count, "GetStatsResultsCount is fail: count is incorrect");
        }
        /// <summary>
        /// GetStatsResultsPassNumのテスト
        /// </summary>
        [TestMethod]
        public void TestGetStatsResultsPassNum()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            int validId = 1;
            // 0以上の数値が返ってくる
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsPassNum(validId), "GetStatsResultsPassNum is fail for valid ID");

            // 異常系 (configID > 50)
            int invalidId = 51;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsPassNum(invalidId));
        }
        /// <summary>
        /// GetStatsResultsFailNumのテスト
        /// </summary>
        [TestMethod]
        public void TestGetStatsResultsFailNum()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            int validId = 1;
            // 0以上の数値が返ってくる
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsFailNum(validId), "GetStatsResultsFailNum is fail for valid ID");

            // 異常系
            int invalidId = 51;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsFailNum(invalidId));
        }
        /// <summary>
        /// GetStatsResultsAvgScoreのテスト
        /// </summary>
        [TestMethod]
        public void TestGetStatsResultsAvgScore()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            int validId = 1;
            // 0以上の数値が返ってくる
            Assert.IsGreaterThanOrEqualTo(0.0, iWiaSystem.GetStatsResultsAvgScore(validId), "GetStatsResultsAvgScore is fail for valid ID");

            // 異常系
            int invalidId = 51;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsAvgScore(invalidId));
        }
        /// <summary>
        /// GetConfigNumPassedのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfigNumPassed()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string jobName = "Test.wia";

            // 正常系
            Assert.IsTrue(iWiaSystem.GetConfigNumPassed(1, jobName, out int num), "GetConfigNumPassed is fail for valid ID");
            // 0以上の数値が返ってくる
            Assert.IsGreaterThanOrEqualTo(0, num, "GetConfigNumPassed returned incorrect out parameter");
            //ジョブ名空文字
            Assert.IsTrue(iWiaSystem.GetConfigNumPassed(1, "", out int num2), "GetConfigNumPassed is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num2, "all GetConfigNumPassed returned incorrect out parameter");

            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumPassed(51, jobName, out _));
        }
        /// <summary>
        /// GetConfigNumFailedのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfigNumFailed()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string jobName = "Test.wia";

            // 正常系
            Assert.IsTrue(iWiaSystem.GetConfigNumFailed(1, jobName, out int num), "GetConfigNumFailed is fail for valid ID");
            // 0以上の数値が返ってくる
            Assert.IsGreaterThanOrEqualTo(0, num, "GetConfigNumFailed returned incorrect out parameter");
            //ジョブ名空文字
            Assert.IsTrue(iWiaSystem.GetConfigNumFailed(1, "", out int num2), "GetConfigNumFailed is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num2, "all GetConfigNumFailed returned incorrect out parameter");

            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumFailed(51, jobName, out _));
        }
        /// <summary>
        /// GetConfigAvgScoreのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfigAvgScore()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            string jobName = "Test.wia";

            // 正常系
            Assert.IsTrue(iWiaSystem.GetConfigAvgScore(1, jobName, out int score), "GetConfigAvgScore is fail for valid ID");
            // 0以上の数値が返ってくる
            Assert.IsGreaterThanOrEqualTo(0, score, "GetConfigAvgScore returned incorrect out parameter");
            //ジョブ名空文字
            Assert.IsTrue(iWiaSystem.GetConfigAvgScore(1, "", out int num2), "GetConfigAvgScore is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num2, "all GetConfigAvgScore returned incorrect out parameter");

            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigAvgScore(51, jobName, out _));
        }
        /// <summary>
        /// FindJobFilePathのテスト
        /// </summary>
        [TestMethod]
        public void TestFindJobFilePath()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            Assert.IsTrue(iWiaSystem.FindJobFilePath("JobA", out string path), "FindJobFilePath is fail for valid name");
            // ジョブフォルダ付きのパスになっている
            Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem) + "JobFolder") + $@"\JobA.wia", path, "FindJobFilePath returned incorrect path");

            // 異常系
            ExceptionTest<ArgumentException>(() => iWiaSystem.FindJobFilePath("", out _));
        }
        /// <summary>
        /// GetAllNumPassed(のテスト
        /// </summary>
        [TestMethod]
        public void TestGetAllNumPassed()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllNumPassed(1), "GetAllNumPassed is fail for valid ID");

            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumPassed(51));
        }
        /// <summary>
        /// GetAllNumFailedのテスト
        /// </summary>
        [TestMethod]
        public void TestGetAllNumFailed()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllNumFailed(1), "GetAllNumFailed is fail for valid ID");

            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumFailed(51));
        }
        /// <summary>
        /// GetAllAverageScoreのテスト
        /// </summary>
        [TestMethod]
        public void TestGetAllAverageScore()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllAverageScore(1), "GetAllAverageScore is fail for valid ID");

            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllAverageScore(51));
        }
        /// <summary>
        /// AllStatsClearのテスト
        /// </summary>
        [TestMethod]
        public void TestAllStatsClear()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            // 例外が発生しないことを確認
            try
            {
                iWiaSystem.AllStatsClear();
            }
            catch (Exception ex)
            {
                Assert.Fail($"AllStatsClear is fail: {ex.Message}");
            }
        }
        /// <summary>
        /// CreateRecogCondのテスト
        /// </summary>
        [TestMethod]
        public void TestCreateRecogCond()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            var cond = iWiaSystem.CreateRecogCond();
            Assert.IsNotNull(cond, "CreateRecogCond is fail: returned null");
        }
        /// <summary>
        /// GetCamInfoのテスト
        /// </summary>
        [TestMethod]
        public void TestGetCamInfo()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            var info = iWiaSystem.GetCamInfo();
            Assert.IsNotNull(info, "GetCamInfo is fail: returned null");
        }
        /// <summary>
        /// StartLiveViewのテスト
        /// </summary>
        [TestMethod]
        public void TestStartLiveView()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            //値の変更とイベントのチェック
            bool startedFired = false;
            bool acquireAvailableFired = false;
            bool acquisitionFailed = false;

            iWiaSystem.LiveViewStarted += (s, e) => startedFired = true;
            iWiaSystem.AcquireImageAvailable += (s, e) => acquireAvailableFired = true;
            iWiaSystem.ImageAcquisitionFailed += (s, e) => acquireAvailableFired = true;

            iWiaSystem.StartLiveView();

            Assert.IsTrue(iWiaSystem.IsLiveViewActive, "StartLiveView is fail: IsLiveViewActive is not true");
            // 開始イベントと成功イベントは発火すること
            Assert.IsTrue(startedFired, "LiveViewStarted event is not fired");
            Assert.IsTrue(acquireAvailableFired, "AcquireImageAvailable event is not fired at start");
            //失敗時イベントは発火しないはず;
            Assert.IsFalse(acquisitionFailed, "ImageAcquisitionFailed event is fired after successed");
            //スタート中にスタートをしたらエラーになりエラーイベントが発火するはず
            iWiaSystem.StartLiveView();
            Assert.IsFalse(acquisitionFailed, "ImageAcquisitionFailed event is fired after successed");

        }
        /// <summary>
        /// StopLiveViewのテスト
        /// </summary>
        [TestMethod]
        public void TestStopLiveView()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool stoppedFired = false;

            iWiaSystem.StartLiveView(); // まず開始する
            iWiaSystem.LiveViewStopped += (s, e) => stoppedFired = true;

            iWiaSystem.StopLiveView();

            Assert.IsFalse(iWiaSystem.IsLiveViewActive, "StopLiveView is fail: IsLiveViewActive is not false");
            Assert.IsTrue(stoppedFired, "LiveViewStopped event is not fired");
        }
        /// <summary>
        /// AcquireImageのテスト
        /// </summary>
        [TestMethod]
        public void TestAcquireImage()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool eventFired = false;
            bool eventfailed = false;
            iWiaSystem.AcquireImageAvailable += (s, e) => eventFired = true;
            iWiaSystem.ImageAcquisitionFailed += (s, e) => eventfailed = true;

            Assert.IsTrue(iWiaSystem.AcquireImage(1), "AcquireImage is fail");
            Assert.IsNotNull(iWiaSystem.LatestAcquireResult, "LatestAcquireResult is null after acquire");
            Assert.IsNotNull(iWiaSystem.LatestAcquiredImage, "LatestAcquiredImage is null after acquire");
            Assert.IsTrue(eventFired, "AcquireImageAvailable event is not fired");
            Assert.IsFalse(eventfailed, "ImageAcquisitionFailed event is fired after success");
            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.AcquireImage(51));
        }
        /// <summary>
        /// TuneStartのテスト
        /// </summary>
        [TestMethod]
        public void TestTuneStart()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            int configId = 10;
            int initialSeq = iWiaSystem.TuneCurrentSeqNumber;

            int tuneId = iWiaSystem.TuneStart(configId, false);

            Assert.IsGreaterThanOrEqualTo(0, tuneId, "TuneStart is fail: returned id is incorrect");
            Assert.IsTrue(iWiaSystem.IsTuning, "TuneStart is fail: IsTuning is not true");
            Assert.AreEqual(TuneState.Running, iWiaSystem.TuneCurrentState, "TuneCurrentState is not Running");
            Assert.AreEqual(configId, iWiaSystem.TuneCurrentConfigNumber, "TuneCurrentConfigNumber is not updated");
            Assert.AreEqual(initialSeq + 1, iWiaSystem.TuneCurrentSeqNumber, "TuneCurrentSeqNumber did not increment");
            // 異常系
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.TuneStart(51, false));
        }
        /// <summary>
        /// TuneAbortのテスト
        /// </summary>
        [TestMethod]
        public void TestTuneAbort()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            iWiaSystem.TuneStart(10, false); // 事前にチューニングを開始

            iWiaSystem.TuneAbort();

            Assert.IsFalse(iWiaSystem.IsTuning, "TuneAbort is fail: IsTuning is not false");
            Assert.AreEqual(TuneState.Completed, iWiaSystem.TuneCurrentState, "TuneCurrentState is not Completed");
        }
        /// <summary>
        /// TuneResultJudgeのテスト
        /// </summary>
        [TestMethod]
        public void TestTuneResultJudge()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            iWiaSystem.TuneStart(10, false); // 事前にチューニングを開始

            Assert.IsTrue(iWiaSystem.TuneResultJudge(), "TuneResultJudge is fail");
            Assert.IsFalse(iWiaSystem.IsTuning, "IsTuning is not false after judge");
            Assert.AreEqual(TuneState.Waiting, iWiaSystem.TuneCurrentState, "TuneCurrentState is not Waiting");

        }

    }
}