using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Linq;
using Wia.Abstractions;
using static TestWiaSystem.ParameterManager;
// StubWia への直接の参照は、Reflectionを使うなら必須ではありませんが、型変換などで使う場合は残します

namespace TestWiaSystem
{
    public static class ParameterManager
    {
        public static TestContext TestContext { get; set; }

        public static TValue getParam<TValue>(string settingKeyName)
        {
            if (TestContext == null)
            {
                throw new InvalidOperationException("TestContext is null .  InstanceManager.TestContext setting at TestInitialize or ClassInitialize");
            }



            // 1. 設定値（クラス名文字列）を取得
            if (!TestContext.Properties.ContainsKey(settingKeyName))
            {
                throw new ArgumentException($"in runsettings , '{settingKeyName}' is not defined");
            }

            return (TValue)TestContext.Properties[settingKeyName];

        }

        public static string getDeviceFolder()
        {

            return getParam<string>("SystemRoot") + @"\" + getParam<string>("SystemFolder") + @"\dev00";
        }
        public static string getJobFolder(){

            return getDeviceFolder() + @"\Job";
        }
    }
}