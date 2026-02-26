using Microsoft.Testing.Platform.OutputDevice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
                
                bool eventFired = false;
                
                iWiaSystem.CloseApplicationRequested += (s, e) => {
                    eventFired = true;
                };
                iWiaSystem.ApplicationExit(1000);
                Task.Delay(500).ContinueWith(t =>
                {
                    Assert.IsFalse(eventFired, "CloseApplicationRequested event is fired before 1000ms");
                });
                Task.Delay(1500).ContinueWith(t =>
                {
                    Assert.IsTrue(eventFired, "CloseApplicationRequested event is not fired after 1000ms");
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
            Assert.AreEqual(ParameterManager.getJobFolder(), folder, "GetJobFolder path is incorrect");
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
            Assert.AreEqual(ParameterManager.getDeviceFolder(), folder, "GetJobFolder path is incorrect");
        }
        /// <summary>
        /// WriteCommandLogExceptionのテスト
        /// </summary>
        [TestMethod]
        public void TestWriteCommandLogException()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            DateTime now = DateTime.Now;

            string format = "yyyy.MM.dd_hh.mm.ss";
            string dateString = "Seq_" + now.ToString(format) + ".000.log";
            string format2 = "yyyyMMdd_hh";
            string dateString2 = "AssertionLog_" + now.ToString(format2) + ".log";
            // ログ出力中に例外がスローされないことを確認
            try
            {
                iWiaSystem.WriteCommandLogException(new Exception("Test Exception"), "Test Message");
                Assert.IsTrue(File.Exists(ParameterManager.getDeviceFolder() + "/log/" + dateString));
                Assert.IsTrue(File.Exists(ParameterManager.getDeviceFolder() + "/log/" + dateString2));
            }
            catch (Exception ex)
            {
                Assert.Fail($"WriteCommandLogException is fail: {ex.Message}");
            }
            finally
            {
                CleanupFromBaseTime(now, ParameterManager.getDeviceFolder() + "/Log");
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
            string beforeJobName = WiaSystem.ActiveJobName;
            IJob beforeJob = WiaSystem.Job;

            EventHandler JobChangingHandler = (s, e) => {
                eventFired1 = true; //ジョブ変更中イベント
                Assert.AreEqual(beforeJobName, WiaSystem.ActiveJobName, "ActiveJobName is changed in Chengging event");
                Assert.AreEqual(beforeJob, WiaSystem.Job, "Job is changed in Chengging event");
            };
            EventHandler JobChangedHandler = (s, e) => {
                eventFired2 = true; //ジョブ変更完了イベント
                Assert.AreNotEqual(beforeJobName, WiaSystem.ActiveJobName, "ActiveJobName is changed in Chengging event");
                Assert.AreNotEqual(beforeJob, WiaSystem.Job, "Job is changed in Chengging event");
            };
            iWiaSystem.JobChanging += JobChangingHandler;
            iWiaSystem.JobChanged += JobChangedHandler;

            Assert.IsTrue(iWiaSystem.CreateNewJob(), "CreateNewJob is fail");
            // ロード時間が更新され、テスト開始時の時刻よりも後であること
            Assert.IsGreaterThanOrEqualTo(time, iWiaSystem.ActiveJobLoadTime, "ActiveJobLoadTime is not updated");
            // runsettingsから実行環境による期待値を取得して比較する
            Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem) + "NewJob"), iWiaSystem.ActiveJobName, "ActiveJobName is not updated to NewJob");
            Assert.IsTrue(eventFired1, "JobChanging event is not fired");
            Assert.IsTrue(eventFired2, "JobChanged event is not fired");
            iWiaSystem.JobChanging -= JobChangingHandler;
            iWiaSystem.JobChanged -= JobChangedHandler;
        }
        /// <summary>
        /// LoadJobFileのテスト
        /// </summary>
        [TestMethod]
        public void TestLoadJobFile()
        {
            IWiaSystem iWiaSystem = WiaSystem;
           
            DateTime time = DateTime.Now;
            bool eventFired1 = false;
            bool eventFired2 = false;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".job";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            // ジョブを保存しておく
            iWiaSystem.SaveJobFile(testPath);
            //一度新規作成
            iWiaSystem.CreateNewJob();
            string beforeJobName = WiaSystem.ActiveJobName;
            IJob beforeJob = WiaSystem.Job;
            EventHandler JobChangingHandler = (s, e) => {
                eventFired1 = true; //ジョブ変更中イベント
                Assert.AreEqual(beforeJobName, WiaSystem.ActiveJobName, "ActiveJobName is changed in Chengging event");
                Assert.AreEqual(beforeJob, WiaSystem.Job, "Job is changed in Chengging event");
            };
            EventHandler JobChangedHandler = (s, e) => {
                eventFired2 = true; //ジョブ変更完了イベント
                Assert.AreNotEqual(beforeJobName, WiaSystem.ActiveJobName, "ActiveJobName is changed in Chengging event");
                Assert.AreNotEqual(beforeJob, WiaSystem.Job, "Job is changed in Chengging event");
            };
            try
            {
                
                // イベントの発火と値の確認を行う
                
                iWiaSystem.JobChanging += JobChangingHandler;
                iWiaSystem.JobChanged += JobChangedHandler;

                Assert.IsTrue(iWiaSystem.LoadJobFile(testPath), "LoadJobFile is fail");
                // ロード時間が更新され、テスト開始時の時刻よりも後であること
                Assert.IsGreaterThanOrEqualTo(time, iWiaSystem.ActiveJobLoadTime, "ActiveJobLoadTime is not updated");
                // Job名がパスが取り除かれファイル名だけになっている
                Assert.AreEqual(System.IO.Path.GetFileName(testPath), iWiaSystem.ActiveJobName, "ActiveJobName is not updated correctly");
                Assert.IsTrue(eventFired1, "JobChanging event is not fired");
                Assert.IsTrue(eventFired2, "JobChanged event is not fired");
            }
            finally {
                System.IO.File.Delete(testPath);
                iWiaSystem.JobChanging -= JobChangingHandler;
                iWiaSystem.JobChanged -= JobChangedHandler;
            }
            

            // 異常系 
            Assert.IsFalse(iWiaSystem.LoadJobFile(""), "LoadJobFile is not fail");
            Assert.IsFalse(iWiaSystem.LoadJobFile(testPath + "fail"), "LoadJobFile unknown path is not failed");
        }
        /// <summary>
        /// SaveJobFileのテスト
        /// </summary>
        [TestMethod]
        public void TestSaveJobFile()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".job";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            bool isEventRaised = false;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(iWiaSystem.ActiveJobName))
                {
                    isEventRaised = true;
                }
            }
            try
            {
                iWiaSystem.PropertyChanged += Handler;
                Assert.IsTrue(iWiaSystem.SaveJobFile(testPath), "SaveJobFile is fail");
                // Job名がパスが取り除かれファイル名だけになっている
                Assert.AreEqual(System.IO.Path.GetFileName(testPath), iWiaSystem.ActiveJobName, "ActiveJobName is not updated correctly");
                // ロード時間が更新され、テスト開始時の時刻よりも後であること
                Assert.IsGreaterThanOrEqualTo(time, iWiaSystem.ActiveJobLoadTime, "ActiveJobLoadTime is not updated");
                Assert.IsTrue(isEventRaised, "ActiveJobLoadTime property event not fired");
            }
            finally
            {
                // 後始末：イベント購読解除
                WiaSystem.PropertyChanged -= Handler;
                System.IO.File.Delete(testPath);
            }

            // 異常系 
            Assert.IsFalse(iWiaSystem.SaveJobFile(""), "LoadJobFile is not fail");
            Assert.IsFalse(iWiaSystem.SaveJobFile(@"C:\存在しないフォルダ/test.job"), "LoadJobFile is not fail unknown folder");
        }
        /// <summary>
        /// SaveJobOverwriteのテスト
        /// </summary>
        [TestMethod]
        public void TestSaveJobOverwrite()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool isEventRaised = false;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".job";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(iWiaSystem.ActiveJobName))
                {
                    isEventRaised = true;
                }
            }
            try
            {
                // 上書き用にダミーのジョブ名をセット
                iWiaSystem.SaveJobFile(testPath);

                iWiaSystem.PropertyChanged += Handler;

                Assert.IsTrue(iWiaSystem.SaveJobOverwrite(), "SaveJobOverwrite is fail");
                Assert.IsTrue(isEventRaised, "PropertyChanged event for ActiveJobName is not fired");

            }
            finally {
                WiaSystem.PropertyChanged -= Handler;
                System.IO.File.Delete(testPath);
            }


            // 異常系 
            iWiaSystem.CreateNewJob();//エラーになるようにファイル名を無題にする
            Assert.IsFalse(iWiaSystem.SaveJobOverwrite(), "SaveJobOverwrite is not fail");
        }
        /// <summary>
        /// LoadBitmapFileのテスト
        /// </summary>
        [TestMethod]
        public void TestLoadBitmapFile()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            //イベントの発火と値の変更確認
            bool acquireAvailableFired = false;
            EventHandler handler = (s, e) => acquireAvailableFired = true;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.AcquireImageAvailable += handler;
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");
                Assert.IsTrue(iWiaSystem.IsAcquireDisabled, "IsAcquireDisabled is not true after loading bitmap");
                Assert.IsTrue(acquireAvailableFired, "AcquireImageAvailable event is not fired");

            }
            finally {
                System.IO.File.Delete(testPath);
                iWiaSystem.AcquireImageAvailable -= handler;
            }

            
            // 異常系 
            Assert.IsFalse(iWiaSystem.LoadBitmapFile(""), "AcquireImageAvailable is not fail");
            Assert.IsFalse(iWiaSystem.LoadBitmapFile(@"C:\存在しないフォルダ/test.job"), "LoadBitmapFile is not fail unknown folder");
        }
        /// <summary>
        /// GoOnlineのテスト
        /// </summary>
        [TestMethod]
        public void TestGoOnline()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool isEventRaised = false;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(iWiaSystem.IsOnline))
                {
                    isEventRaised = true;
                }
            }
            //値の変更確認
            try
            {
                iWiaSystem.PropertyChanged += Handler;
                iWiaSystem.GoOnline();
            }
            finally
            {
                // 後始末：イベント購読解除
                WiaSystem.PropertyChanged -= Handler;
            }

            // 1. イベントを購読
            Assert.IsTrue(isEventRaised, "isEventRaised is false");
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
            bool isEventRaised = false;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(iWiaSystem.IsOnline))
                {
                    isEventRaised = true;
                }
            }
            //値の変更確認
            try
            {
                iWiaSystem.PropertyChanged += Handler;
                iWiaSystem.GoOffline();
            }
            finally
            {
                // 後始末：イベント購読解除
                WiaSystem.PropertyChanged -= Handler;
            }
            Assert.IsTrue(isEventRaised, "isEventRaised is false");
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
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");
                // 正常系
                iWiaSystem.Job.RunRead(); //統計情報を更新させる
                int validId = 1;
                // 0以上の数値が返ってくる
                Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsPassNum(validId), "GetStatsResultsPassNum is fail for valid ID");

            }
            finally
            {
                System.IO.File.Delete(testPath);
            }

            // 異常系 (configID > 50)
            int invalidId = iWiaSystem.Job.GetConfigMaxNum()+1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsPassNum(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsPassNum(-1));
        }
        /// <summary>
        /// GetStatsResultsFailNumのテスト
        /// </summary>
        [TestMethod]
        public void TestGetStatsResultsFailNum()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            int validId = 1;
            int before = iWiaSystem.GetStatsResultsFailNum(validId);
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");
                // 正常系
                iWiaSystem.Job.RunRead(); //統計情報を更新させる
                
                // 0以上の数値が返ってくる 失敗しているはずなので1以上
                Assert.IsGreaterThan(before, iWiaSystem.GetStatsResultsFailNum(validId), "GetStatsResultsFailNum is fail for valid ID");

            }
            finally
            {
                System.IO.File.Delete(testPath);
            }
           
            // 異常系
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsFailNum(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsFailNum(-1));
        }
        /// <summary>
        /// GetStatsResultsAvgScoreのテスト
        /// </summary>
        [TestMethod]
        public void TestGetStatsResultsAvgScore()
        {
            IWiaSystem iWiaSystem = WiaSystem;

            // 正常系
            
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");
                // 正常系
                iWiaSystem.Job.RunRead(); //統計情報を更新させる
                int validId = 1;
                // 0以上の数値が返ってくる 失敗しているはずなので1以上
                Assert.IsGreaterThanOrEqualTo(0.0, iWiaSystem.GetStatsResultsAvgScore(validId), "GetStatsResultsAvgScore is fail for valid ID");

            }
            finally
            {
                System.IO.File.Delete(testPath);
            }

            // 異常系
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsAvgScore(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsAvgScore(-1));
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
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumPassed(invalidId, jobName, out _));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumPassed(-1, jobName, out _));
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
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumFailed(invalidId, jobName, out _));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumFailed(-1, jobName, out _));
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
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigAvgScore(invalidId, jobName, out _));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigAvgScore(-1, jobName, out _));
        }
        /// <summary>
        /// FindJobFilePathのテスト
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestFindJobFilePath()
        {
            // TODO TEST＿TBD
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
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumPassed(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumPassed(-1));
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
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumFailed(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumFailed(-1));
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
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllAverageScore(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllAverageScore(-1));
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
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);
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
            }
            finally
            {
                System.IO.File.Delete(testPath);
            }

            //スタート中にスタートをしたらエラーになりエラーイベントが発火するはず
            iWiaSystem.StartLiveView();
            Assert.IsFalse(acquisitionFailed, "ImageAcquisitionFailed event is fired after successed");
            iWiaSystem.StopLiveView();//最後止めておく
            TestUtils.DelaySample(500); // 処理完了待ち

        }
        /// <summary>
        /// StopLiveViewのテスト
        /// </summary>
        [TestMethod]
        public void TestStopLiveView()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            bool stoppedFired = false;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);
                iWiaSystem.StartLiveView(); // まず開始する
                iWiaSystem.LiveViewStopped += (s, e) => stoppedFired = true;

                iWiaSystem.StopLiveView();

                Assert.IsFalse(iWiaSystem.IsLiveViewActive, "StopLiveView is fail: IsLiveViewActive is not false");
                Assert.IsTrue(stoppedFired, "LiveViewStopped event is not fired");
            }
            finally
            {
                System.IO.File.Delete(testPath);
            }
            
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
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);
                Assert.IsTrue(iWiaSystem.AcquireImage(1), "AcquireImage is fail");
                Assert.IsNotNull(iWiaSystem.LatestAcquireResult, "LatestAcquireResult is null after acquire");
                Assert.IsNotNull(iWiaSystem.LatestAcquiredImage, "LatestAcquiredImage is null after acquire");
                Assert.IsTrue(eventFired, "AcquireImageAvailable event is not fired");
                Assert.IsFalse(eventfailed, "ImageAcquisitionFailed event is fired after success");

            }
            finally
            {
                System.IO.File.Delete(testPath);
            }
            
            // 異常系
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.AcquireImage(invalidId));
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

            
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);
                int tuneId = iWiaSystem.TuneStart(configId, false);
                Assert.IsGreaterThanOrEqualTo(0, tuneId, "TuneStart is fail: returned id is incorrect");
                Assert.IsTrue(iWiaSystem.IsTuning, "TuneStart is fail: IsTuning is not true");
                Assert.AreEqual(TuneState.Running, iWiaSystem.TuneCurrentState, "TuneCurrentState is not Running");
                Assert.AreEqual(configId, iWiaSystem.TuneCurrentConfigNumber, "TuneCurrentConfigNumber is not updated");
                Assert.AreEqual(initialSeq + 1, iWiaSystem.TuneCurrentSeqNumber, "TuneCurrentSeqNumber did not increment");

            }
            finally
            {
                System.IO.File.Delete(testPath);
            }
            
            // 異常系
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.TuneStart(invalidId, false));
        }
        /// <summary>
        /// TuneAbortのテスト
        /// </summary>
        [TestMethod]
        public void TestTuneAbort()
        {
            IWiaSystem iWiaSystem = WiaSystem;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);


            }
            finally
            {
                System.IO.File.Delete(testPath);
            }
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
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);


            }
            finally
            {
                System.IO.File.Delete(testPath);
            }
            Assert.IsTrue(iWiaSystem.TuneResultJudge(), "TuneResultJudge is fail");
            Assert.IsFalse(iWiaSystem.IsTuning, "IsTuning is not false after judge");
            Assert.AreEqual(TuneState.Waiting, iWiaSystem.TuneCurrentState, "TuneCurrentState is not Waiting");

        }

    }
}