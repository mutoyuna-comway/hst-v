
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using Wia.Abstractions;

/// <summary>
/// MaintenanceServiceのユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// MaintenanceServiceのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIMaintenanceService : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIMaintenanceServiceData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "SelfDiagnosisProcess", "", false };
                yield return new object[] { "CreatePCInfoProcess", "", false };
                yield return new object[] { "LogSaveZipDataProcess", "", false };

            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIMaintenanceServiceData))]
        public void IMaintenanceServicePropertyTest(string name, object value, bool isPrivate)
        {
            IMaintenanceService iMaintenanceService = WiaSystem.MaintenanceServices;
            this.PropertyTest(iMaintenanceService, name, value, isPrivate);
        }
    }
}