
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
                IJob iJob = WiaService.Job;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { nameof(iJob.ReadType), ReadMethod.All, false };
                yield return new object[] { nameof(iJob.ScoreType), ScoreMode.MinScore, false };
                yield return new object[] { nameof(iJob.SelectedConfig), ShallowCopy(iJob.SelectedConfig), true };
                yield return new object[] { nameof(iJob.SelectedConfigIndex), 10, false };
                yield return new object[] { nameof(iJob.MaxNumConfig), MaxNumConfigType.Num16, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIJobData))]
        public void IJobPropertyTest(string name, object value, bool isPrivate)
        {
            IJob iJob = WiaService.Job;
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
            IJob iJob = WiaService.Job;

            // 各種設定やサービスインスタンスが正しく生成されているか（nullでないか）を検証
            Assert.IsNotNull(iJob.Configs, nameof(WiaService.Job.Configs) + " is null");
            Assert.IsNotNull(iJob.SystemService, nameof(WiaService.Job.SystemService) + " is null");
        }
        /// <summary>
        /// GetConfigのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfig()
        {
            IJob iJob = WiaService.Job;
            var result = iJob.GetConfig(1);
            //取得したConfigがnull出ないことを確認する
            Assert.IsNotNull(result, $"GetConfig is fail: returned null");
            //取得したConfigがIJobConfigクラスを持っていることを確認する
            Assert.IsInstanceOfType(result, typeof(IJobConfig), "The return value must be of type IJobConfig.");
            // 【検証：異常系】最大数を超えるコンフィグID、またはマイナスのIDを指定した際に ArgumentOutOfRangeException が発生するか
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.GetConfig(getConfigMaxOverNum()));
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.GetConfig(-1));
        }
       
        /// <summary>
        /// GetSortedEnableConfigArrayのテスト
        /// </summary>
        [TestMethod]
        public void TestGetSortedEnableConfigArray()
        {
            IJob iJob = WiaService.Job;
            // 【検証】生成された配列がnullでないこと
            Assert.IsNotNull(iJob.GetSortedEnableConfigArray(), "GetSortedEnableConfigArray is fail: returned null");
        }
        /// <summary>
        /// CheckFontIdValidityのテスト
        /// </summary>
        [TestMethod]
        public void TestCheckFontIdValidity()
        {
            IJob iJob = WiaService.Job;
            // 【検証】カスタムフォントがシステムに存在しない場合に、正しくfalseを返すことを確認
            Assert.IsFalse(iJob.CheckFontIdValidity(), "The return value of CheckFontIdValidity must be false");
        }
        /// <summary>
        /// CopyConfigのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1, 3)]
        public void TestCopyConfig_success(int srcConfID, int dstConfID)
        {
            IJob iJob = WiaService.Job;
            // 【検証】有効なID範囲内でのコピーが正常に成功することを確認
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
            IJob iJob = WiaService.Job;

            // 【検証】
            // srcConfIDまたはdstConfIDに範囲外の値が指定された場合、
            // ArgumentOutOfRangeExceptionがスローされることを確認します。
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CopyConfig(srcConfID, dstConfID));
        }
        /// <summary>
        /// RunReadのテスト
        /// </summary>
        [TestMethod]
        public void TestRunRead()
        {
            IJob iJob = WiaService.Job;
            bool availableEventFired = false;
            bool completedEventFired = false;

            // イベントハンドラの定義：イベントが発火した際にフラグをtrueに書き換える
            EventHandler<IReadCompletedEventArgs> availableHandler = (s, e) => availableEventFired = true;
            EventHandler<IReadCompletedEventArgs> completedHandler = (s, e) => completedEventFired = true;

            try
            {
                // イベントの購読
                iJob.ConfigReadResultAvailable += availableHandler;
                iJob.ConfigReadCompleted += completedHandler;

                // 【実行】読み取り処理の実行
                int result = iJob.RunRead();

                // 【検証】読取り失敗時に戻り値が-1であることを確認
                Assert.AreEqual(-1, iJob.RunRead(), "If method RunRead's execution fails, the return value should be -1");
                // ConfigReadResultAvailableイベントが正しく発火したか
                Assert.IsTrue(availableEventFired, "ConfigReadResultAvailable event is not fired");
                // ConfigReadCompletedイベントが正しく発火したか
                Assert.IsTrue(completedEventFired, "ConfigReadCompleted event is not fired");
            }
            finally
            {
                // 【後処理】テスト終了後にイベント購読を解除する
                iJob.ConfigReadResultAvailable -= availableHandler;
                iJob.ConfigReadCompleted -= completedHandler;
            }
        }
        /// <summary>
        /// ClearTuneResultのテスト
        /// </summary>
        [TestMethod]
        public void TestClearTuneResult()
        {
            IJob iJob = WiaService.Job;
            // 【実行】チューニング結果のクリアメソッドを呼び出し
            iJob.ClearTuneResult();
            // 【検証】クリア実行後、SelectedConfig内のTuneLatestResultがnullになっていることを確認
            Assert.IsNull(iJob.SelectedConfig.TuneLatestResult, "TuneLatestResult should be null after clearing");

        }
        /// <summary>
        /// GetLastBestConfigIdのテスト
        /// </summary>
        [TestMethod]
        public void TestGetLastBestConfigId_beforeExecute()
        {
            IJob iJob = WiaService.Job;
            int result = iJob.GetLastBestConfigId();
            //【検証】読取り未実行の場合は0を返す
            Assert.IsGreaterThanOrEqualTo(0, result, "If reading has not been executed, the result must return greater than 0");
        }
        /// <summary>
        /// GetLastBestConfigIdのテスト
        /// </summary>
        [TestMethod]
        public void TestGetLastBestConfigId_afterExecute()
        {
            IJob iJob = WiaService.Job;
            // 【実行】読取り処理を実行
            iJob.RunRead();
            int result = iJob.GetLastBestConfigId();
            // 【検証】読取り実行後は、有効なコンフィグID（0以上）が返ることを確認
            Assert.IsGreaterThanOrEqualTo(0, result, "The returned ID must be 0 or greater after reading has been executed");
        }
        /// <summary>
        /// GetReadBestResultのテスト
        /// </summary>
        [TestMethod]
        public void TestGetReadBestResult_success()
        {
            IJob iJob = WiaService.Job;
            IReadResult result = iJob.GetReadBestResult(1);
            // 【検証】
            // 結果オブジェクトがnullでないことを確認
            Assert.IsNotNull(result, "result must not be null");
            // 戻り値が期待されるインターフェース型であることを確認
            Assert.IsInstanceOfType(result, typeof(Wia.Abstractions.IReadResult), "the return value must be type of IReadResult.");
            // 【検証：異常系】最大数を超えるコンフィグID、またはマイナスのIDを指定した際に ArgumentOutOfRangeException が発生するか
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.GetReadBestResult(getConfigMaxOverNum()));
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.GetReadBestResult(-1));
        }
       
        /// <summary>
        /// GetConfigMaxNumのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfigMaxNum()
        {
            IJob iJob = WiaService.Job;
            int maxNum = iJob.GetConfigMaxNum();
            // 【検証】取得した値が、定義済みの定数（WiaConstants.ConfigMaxNum）と一致することを確認
            if (WiaService.Job.MaxNumConfig == MaxNumConfigType.Num50)
            {
                Assert.AreEqual(WiaConstants.ExpandedConfigMaxNum, maxNum);
            } else
            {
                Assert.AreEqual(WiaConstants.ConfigMaxNum, maxNum);
            }
        }
        /// <summary>
        /// CheckValidConfigIDのテスト
        /// </summary>
        [TestMethod]
        public void TestCheckValidConfigID()
        {
            IJob iJob = WiaService.Job;
            // 【検証】戻り値が true であることが期待されます。
            Assert.IsTrue(iJob.CheckValidConfigID(1), "The return value of CheckValidConfigID must be true");
            // 【検証：異常系】最大数を超えるコンフィグID、またはマイナスのIDを指定した際に ArgumentOutOfRangeException が発生するか
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CheckValidConfigID(getConfigMaxOverNum()));
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CheckValidConfigID(-1));
        }
        
        /// <summary>
        /// CheckExistenceConfigのテスト
        /// </summary>
        [TestMethod]
        public void TestCheckExistenceConfig_success()
        {
            IJob iJob = WiaService.Job;
            // 【検証】戻り値が true であることが期待されます。
            Assert.IsTrue(iJob.CheckExistenceConfig(1), "The return value of CheckExistenceConfig must be true");
            // 【検証：異常系】最大数を超えるコンフィグID、またはマイナスのIDを指定した際に ArgumentOutOfRangeException が発生するか
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CheckExistenceConfig(getConfigMaxOverNum()));
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.CheckExistenceConfig(-1));

        }

        /// <summary>
        /// RunReadRetryのテスト TODO　検討中のため一旦書いておくだけのテスト
        /// </summary>
        [TestMethod]
        [DataRow(1, 1, 1, 1, 1, 1, 1, 1, null)]
        public void TestRunReadRetry_success(int configID, int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, IReadResult result)
        {
            IJob iJob = WiaService.Job;
            // 【検証】戻り値が 0 であることが期待されます。
            Assert.AreEqual(0, iJob.RunReadRetry(configID, lightRange, lightStep, sizeRange, sizeStep, internalFilter, timeOut, overwrite, out result));
            // 【検証：異常系】最大数を超えるコンフィグID、またはマイナスのIDを指定した際に ArgumentOutOfRangeException が発生するか
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.RunReadRetry(getConfigMaxOverNum(), lightRange, lightStep, sizeRange, sizeStep, internalFilter, timeOut, overwrite, out result));
            ExceptionTest<ArgumentOutOfRangeException>(() => iJob.RunReadRetry(-1, lightRange, lightStep, sizeRange, sizeStep, internalFilter, timeOut, overwrite, out result));
        }

        /// <summary>
        /// コンフィグ数最大値＋１を取得する
        /// </summary>
        /// <returns></returns>
        private int getConfigMaxOverNum()
        {
            if (WiaService.Job.MaxNumConfig == MaxNumConfigType.Num50)
            {
                return WiaConstants.ExpandedConfigMaxNum + 1;
            }
            return WiaConstants.ConfigMaxNum + 1;

        }
    }
}