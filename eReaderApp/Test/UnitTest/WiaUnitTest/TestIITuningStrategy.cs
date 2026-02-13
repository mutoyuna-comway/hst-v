
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.Runtime;
using Wia.Abstractions;

/// <summary>
/// TuneResultのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// TuneResultのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestITuningStrategy: AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestITuningStrategyData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                ITuningStrategy iTuningStrategy = TuningStrategy;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "IsMultiLightTuneForced", true, false };
                yield return new object[] { "Progress", 10.0, true };
                yield return new object[] { "LatestTuningResult", ShallowCopy(iTuningStrategy.LatestTuningResult), true };
                yield return new object[] { "TuneHistory", "tuneHistory", true };
                yield return new object[] { "ArchiveFolderName", "archiveFolderName", false };
                yield return new object[] { "IsArchiveAutoCleanup", true, false };
                yield return new object[] { "ScoreType", ScoreMode.MaxMinScore, false };
                yield return new object[] { "WaferScoreAs100", ScoreAs100.Include100, false };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestITuningStrategyData))]
        public void ITuneResultPropertyTest(string name, object value, bool isPrivate)
        {
            ITuningStrategy iTuningStrategy = TuningStrategy;
            this.PropertyTest(iTuningStrategy, name, value, isPrivate);
        }

        public static IEnumerable<object[]> TestIReadOperationStartedEventArgsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                IReadOperationStartedEventArgs iReadOperationCompletedEventArgs = ReadOperationStartedEventArgs;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ReadSettings", ShallowCopy(iReadOperationCompletedEventArgs.ReadSettings), true };
                yield return new object[] { "ProcessImage", ShallowCopy(iReadOperationCompletedEventArgs.ProcessImage), true };
            }
        }


        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIReadOperationStartedEventArgsData))]
        public void IReadOperationStartedEventArgsPropertyTest(string name, object value, bool isPrivate)
        {
            IReadOperationStartedEventArgs iReadOperationCompletedEventArgs = ReadOperationStartedEventArgs;
            this.PropertyTest(iReadOperationCompletedEventArgs, name, value, isPrivate);
        }


        public static IEnumerable<object[]> TestIReadOperationCompletedEventArgsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                IReadOperationCompletedEventArgs iReadOperationCompletedEventArgs = ReadOperationCompletedEventArgs;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ReadResult", ShallowCopy(iReadOperationCompletedEventArgs.ReadResult), true };
            }
        }

        
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIReadOperationCompletedEventArgsData))]
        public void IReadOperationCompletedEventArgsPropertyTest(string name, object value, bool isPrivate)
        {
            IReadOperationCompletedEventArgs iReadOperationCompletedEventArgs = ReadOperationCompletedEventArgs;
            this.PropertyTest(iReadOperationCompletedEventArgs, name, value, isPrivate);
        }


        public static IEnumerable<object[]> TestIAcquireImageStartedEventArgsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                IAcquireImageStartedEventArgs iAcquireImageStartedEventArgs = AcquireImageStartedEventArgs;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "RecordNumber", 1, true };
                yield return new object[] { "AcqSettings", ShallowCopy(iAcquireImageStartedEventArgs.AcqSettings), true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIAcquireImageStartedEventArgsData))]
        public void IAcquireImageStartedEventArgsPropertyTest(string name, object value, bool isPrivate)
        {
            IAcquireImageStartedEventArgs iAcquireImageStartedEventArgs = AcquireImageStartedEventArgs;
            this.PropertyTest(iAcquireImageStartedEventArgs, name, value, isPrivate);
        }


        public static IEnumerable<object[]> TestIAcquireImageCompletedEventArgsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                IAcquireImageCompletedEventArgs acquireImageCompletedEventArgs = AcquireImageCompletedEventArgs;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AcqResult", ShallowCopy(acquireImageCompletedEventArgs.AcqResult), true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>

        [TestMethod]
        [DynamicData(nameof(TestIAcquireImageCompletedEventArgsData))]
        public void IAcquireImageCompletedEventArgsPropertyTest(string name, object value, bool isPrivate)
        {
            IAcquireImageCompletedEventArgs acquireImageCompletedEventArgs = AcquireImageCompletedEventArgs;
            this.PropertyTest(acquireImageCompletedEventArgs, name, value, isPrivate);
        }

        public static IEnumerable<object[]> TestILogMessageEventArgsArgsData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "RecordNumber", 1, true };
                yield return new object[] { "Message", "Message", true };
                yield return new object[] { "MessageSub", "MessageSub", true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestILogMessageEventArgsArgsData))]
        public void ILogMessageEventArgsPropertyTest(string name, object value, bool isPrivate)
        {
            ILogMessageEventArgs iLogMessageEventArgs = LogMessageEventArgs;
            this.PropertyTest(iLogMessageEventArgs, name, value, isPrivate);
        }
    }
}