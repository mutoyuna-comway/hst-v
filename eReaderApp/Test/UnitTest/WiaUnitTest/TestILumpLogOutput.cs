
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// LumpLogOutputのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// LumpLogOutputのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestILumpLogOutput : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestILumpLogOutputData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyLumpLogOutput = getCopyIWiaSystem().LogSettings.LogOutput;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "AllImage", copyLumpLogOutput.AllImage, false };
                yield return new object[] { "FailImage", copyLumpLogOutput.FailImage, false };
                yield return new object[] { "JobData", copyLumpLogOutput.JobData, false };
                yield return new object[] { "LogData", copyLumpLogOutput.LogData, false };
                yield return new object[] { "ConfData", copyLumpLogOutput.ConfData, false };
                yield return new object[] { "PCInfo", copyLumpLogOutput.PCInfo, false };
                yield return new object[] { "SelfDiagnosisInfo", copyLumpLogOutput.SelfDiagnosisInfo, false };
                yield return new object[] { "SizeOfDevidedLog", 10, false };


            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestILumpLogOutputData))]
        public void ILumpLogOutputPropertyTest(string name, object value, bool isPrivate)
        {
            ILumpLogOutput iLumpLogOutput = WiaSystem.LogSettings.LogOutput;
            this.PropertyTest(iLumpLogOutput, name, value, isPrivate);
        }
    }
    /// <summary>
    /// LumpLogElementtのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestILumpLogElement : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestILumpLogElementData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                var copyILumpLogElement = getCopyIWiaSystem().LogSettings.LogOutput.AllImage;
                var expected = new DateTime(2026, 2, 2, 10, 30, 0);
                var list = new List<string> { };
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "IsSave", true, false };
                yield return new object[] { "IsFromDate", true, false };
                yield return new object[] { "FromDate", expected, false };
                yield return new object[] { "IsFileNum", true, false };
                yield return new object[] { "IsFileNum", true, false };
                yield return new object[] { "SaveFileNum", 10, false };
                yield return new object[] { "FileNum", 10L, false };
                yield return new object[] { "FileSize", 10L, false };
                yield return new object[] { "FileList", list, false };

            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestILumpLogElementData))]
        public void ILumpLogElementPropertyTest(string name, object value, bool isPrivate)
        {
            ILumpLogElement iILumpLogElement = WiaSystem.LogSettings.LogOutput.AllImage;
            this.PropertyTest(iILumpLogElement, name, value, isPrivate);
        }
    }
}