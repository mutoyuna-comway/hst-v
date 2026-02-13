
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// JobReadSettingsのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// JobReadSettingsのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIJobReadSettings : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIJobReadSettingsData
        {
            get
            {
                // ここでテスト設定値用のインスタンスを生成
                IJobReadSettings ijobReadSettings = WiaSystem.Job.SelectedConfig.ReadSettings;
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Mark", MarkType.T7, false };
                yield return new object[] { "Checksum", ChecksumType.Semi, false };
                yield return new object[] { "CharSize", DeepCopy(ijobReadSettings.CharSize), false };
                yield return new object[] { "FieldString", "", false };
                yield return new object[] { "FieldDef", "", false };
                yield return new object[] { "Color", MarkColor.White, false };
                yield return new object[] { "AcceptThreshold", 10, false };
                yield return new object[] { "OCR", DeepCopy(ijobReadSettings.OCR), true };
                yield return new object[] { "T7", DeepCopy(ijobReadSettings.T7), true };
                yield return new object[] { "QR", DeepCopy(ijobReadSettings.QR), true };
                yield return new object[] { "DM", DeepCopy(ijobReadSettings.DM), true };
                yield return new object[] { "Barcode", DeepCopy(ijobReadSettings.Barcode), true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIJobReadSettingsData))]
        public void IJobReadSettingsPropertyTest(string name, object value, bool isPrivate)
        {
            IJobReadSettings ijobReadSettings = WiaSystem.Job.SelectedConfig.ReadSettings;
            this.PropertyTest(ijobReadSettings, name, value, isPrivate);
        }
    }
}