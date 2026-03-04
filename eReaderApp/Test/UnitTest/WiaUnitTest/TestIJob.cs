
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                IJob iJob = WiaSystem.Job;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { nameof(WiaSystem.Job.ReadType), ReadMethod.All, false };
                yield return new object[] { nameof(WiaSystem.Job.ScoreType), ScoreMode.MinScore, false };
                yield return new object[] { nameof(WiaSystem.Job.SelectedConfig), ShallowCopy(iJob.SelectedConfig), true };
                yield return new object[] { nameof(WiaSystem.Job.SelectedConfigIndex), 10, false };
                yield return new object[] { nameof(WiaSystem.Job.MaxNumConfig), MaxNumConfigType.Num16, false };
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
        /// <summary>
        /// ReadOnlyのプロパティのテスト 値が変更されることのないプロパティのテスト
        /// </summary>
        /// <remarks>
        /// インターフェース上で { get; } のみ定義されており、実行中にインスタンスが不変（初期化時にのみ生成される）
        /// であるべきプロパティが、正しく初期化されてnullでないことを確認します。
        /// </remarks>
        [TestMethod]
        public void IJobReadOnlyPropertyTest()
        {
            IJob iJob = WiaSystem.Job;

            // 各種設定やサービスインスタンスが正しく生成されているか（nullでないか）を検証
            Assert.IsNotNull(iJob.Configs, nameof(WiaSystem.Job.Configs) + " is null");
            Assert.IsNotNull(iJob.SystemService, nameof(WiaSystem.Job.SystemService) + " is null");
        }
        /// <summary>
        /// GetConfigのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1)]
        public void TestGetConfig_Success(int index)
        {
            IJob iJob = WiaSystem.Job;
            var result = iJob.GetConfig(index);
            Assert.IsNotNull(result, $"GetConfig is fail: returned null");
            Assert.IsInstanceOfType(result, typeof(IJobConfig), "The return value must be of type IJobConfig.");

        }
        /// <summary>
        /// GetConfigのテスト
        /// </summary>
        [TestMethod]
        [DataRow(-1)]
        [DataRow(100)]
        public void TestGetConfig_ArgumentOutOfRangeException(int index)
        {
            IJob iJob = WiaSystem.Job;
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.GetConfig(index));
        }
        /// <summary>
        /// GetSortedEnableConfigArrayのテスト
        /// </summary>
        [TestMethod]
        public void TestGetSortedEnableConfigArray()
        {
            IJob iJob = WiaSystem.Job;
            Assert.IsNotNull(iJob.GetSortedEnableConfigArray(), "GetSortedEnableConfigArray is fail: returned null");

        }
        /// <summary>
        /// CheckFontIdValidityのテスト
        /// </summary>
        [TestMethod]
        public void TestCheckFontIdValidity()
        {
            IJob iJob = WiaSystem.Job;
            Assert.IsFalse(iJob.CheckFontIdValidity(), "The return value of CheckFontIdValidity must be false");

        }
        /// <summary>
        /// CopyConfigのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1, 3)]
        public void TestCopyConfig_success(int srcConfID, int dstConfID)
        {
            IJob iJob = WiaSystem.Job;
            Assert.IsTrue(iJob.CopyConfig(srcConfID, dstConfID), "The return value of CopyConfig must be true");
        }
        /// <summary>
        /// CopyConfigのテスト
        /// </summary>
        [TestMethod]
        [DataRow(-1, 3)]
        [DataRow(1, 18)]
        public void TestCopyConfig_fail(int srcConfID, int dstConfID)
        {
            IJob iJob = WiaSystem.Job;
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CopyConfig(srcConfID, dstConfID));

        }
        /// <summary>
        /// RunReadのテスト
        /// </summary>
        [TestMethod]
        public void TestRunRead_success()
        {
            IJob iJob = WiaSystem.Job;
            bool availableEventFired = false;
            bool completedEventFired = false;


            EventHandler<IReadCompletedEventArgs> availableHandler = (s, e) => availableEventFired = true;
            EventHandler<IReadCompletedEventArgs> completedHandler = (s, e) => completedEventFired = true;

            try
            {
                iJob.ConfigReadResultAvailable += availableHandler;
                iJob.ConfigReadCompleted += completedHandler;

                int result = iJob.RunRead();
                Assert.IsGreaterThanOrEqualTo(0, result);
                Assert.IsTrue(availableEventFired, "ConfigReadResultAvailable event is not fired");
                Assert.IsTrue(completedEventFired, "ConfigReadCompleted event is not fired");
            }
            finally
            {
                iJob.ConfigReadResultAvailable -= availableHandler;
                iJob.ConfigReadCompleted -= completedHandler;
            }


        }
        /// <summary>
        /// RunReadのテスト
        /// </summary>
        [TestMethod]
        public void TestRunRead_fail()
        {
            IJob iJob = new StubIJob();
            iJob.RunRead();
            iJob.RunRead();
            iJob.RunRead();
            Assert.AreEqual(-1, iJob.RunRead(), "If method RunRead's execution fails, the return value should be -1");

        }
        /// <summary>
        /// ClearTuneResultのテスト
        /// </summary>
        [TestMethod]
        public void TestClearTuneResult()
        {
            IJob iJob = WiaSystem.Job;
            iJob.ClearTuneResult();
            Assert.IsNull(iJob.SelectedConfig.TuneLatestResult, "TuneLatestResult should be null after clearing");

        }
        /// <summary>
        /// GetLastBestConfigIdのテスト
        /// </summary>
        [TestMethod]
        public void TestGetLastBestConfigId_beforeExecute()
        {
            IJob iJob = new StubIJob();
            int result = iJob.GetLastBestConfigId();
            Assert.AreEqual(0, result, "If reading has not been executed, the result must return 0");
        }
        /// <summary>
        /// GetLastBestConfigIdのテスト
        /// </summary>
        [TestMethod]
        public void TestGetLastBestConfigId_afterExecute()
        {

            IJob iJob = new StubIJob();
            iJob.RunRead();
            int result = iJob.GetLastBestConfigId();
            Assert.IsGreaterThanOrEqualTo(1, result, "The returned ID must be 1 or greater after reading has been executed");
        }
        /// <summary>
        /// GetReadBestResultのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1)]
        public void TestGetReadBestResult_success(int configID)
        {
            IJob iJob = WiaSystem.Job;
            IReadResult result = iJob.GetReadBestResult(configID);
            Assert.IsNotNull(result, "result must not be null");
            Assert.IsInstanceOfType(result, typeof(Wia.Abstractions.IReadResult), "the return value must be type of IReadResult.");

        }
        /// <summary>
        /// GetReadBestResultのテスト
        /// </summary>
        [TestMethod]
        [DataRow(17)]
        public void TestGetReadBestResult_fail(int configID)
        {
            IJob iJob = WiaSystem.Job;
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.GetReadBestResult(configID));

        }
        /// <summary>
        /// GetConfigMaxNumのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfigMaxNum()
        {
            IJob iJob = WiaSystem.Job;
            int maxNum = iJob.GetConfigMaxNum();
            Assert.AreEqual(WiaConstants.ConfigMaxNum, maxNum);
        }
        /// <summary>
        /// CheckValidConfigIDのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1)]
        public void TestCheckValidConfigID_success(int configID)
        {
            IJob iJob = WiaSystem.Job;
            Assert.IsTrue(iJob.CheckValidConfigID(configID), "The return value of CheckValidConfigID must be true");
        }
        /// <summary>
        /// CheckValidConfigIDのテスト
        /// </summary>
        [TestMethod]
        [DataRow(17)]
        public void TestCheckValidConfigID_fail(int configID)
        {
            IJob iJob = WiaSystem.Job;
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CheckValidConfigID(configID));
        }
        /// <summary>
        /// CheckExistenceConfigのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1)]
        public void TestCheckExistenceConfig_success(int targetConfig)
        {
            IJob iJob = WiaSystem.Job;
            Assert.IsTrue(iJob.CheckExistenceConfig(targetConfig), "The return value of CheckExistenceConfig must be true");

        }
        /// <summary>
        /// CheckExistenceConfigのテスト
        /// </summary>
        [TestMethod]
        [DataRow(17)]
        public void TestCheckExistenceConfig_fail(int targetConfig)
        {
            IJob iJob = WiaSystem.Job;
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CheckExistenceConfig(targetConfig));

        }
        /// <summary>
        /// RunReadRetryのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 1, 1, 1, null)]
        public void TestRunReadRetry_success(int configID, int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, IReadResult result)
        {
            IJob iJob = WiaSystem.Job;
            Assert.AreEqual(0, iJob.RunReadRetry(configID, lightRange, lightStep, sizeRange, sizeStep, internalFilter, timeOut, overwrite, out result));

        }
        /// <summary>
        /// RunReadRetryのテスト
        /// </summary>
        [TestMethod]
        [DataRow(17, 1, 1, 1, 1, 1, 1, 1, null)]
        public void TestRunReadRetry_fail(int configID, int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, IReadResult result)
        {
            IJob iJob = WiaSystem.Job;
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.RunReadRetry(configID, lightRange, lightStep, sizeRange, sizeStep, internalFilter, timeOut, overwrite, out result));

        }

    }
}