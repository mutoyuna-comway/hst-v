
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.ComponentModel;
using System.Reflection;
using Wia.Abstractions;

namespace TestWiaSystem
{
    /// <summary>
    /// テストクラスの基底クラス
    /// 汎用的なチェック関数などを持つ
    /// </summary>
    public static class InstanceManager
    {
        public static TestContext TestContext { get; set; }

        public static IWiaSystem WiaSystem;
        public static IReadCompletedEventArgs ReadCompletedEventArgs;
        public static IRecogCondition RecogCondition;
        public static ICamContloler CamContloler;
        public static IStatsResult StatsResult;
        public static IWaitResponse WaitResponse;
        public static IFilterConfig FilterConfig;
        public static IAcquireCondition AcquireCondition;
        
        public static void InitializeInstance()
        {
            // プロパティとしての TestContext にアクセスする（小文字の t でも可）
            if (TestContext == null)
            {
                throw new Exception("TestContext が正しく注入されていません。");
            }
            string mode = TestContext.Properties["ServiceMode"] as string;
            switch (mode)
            {
                case "Mock":
                    WiaSystem = new StubIWiaSystem();
                    ReadCompletedEventArgs = new StubIReadCompletedEventArgs();
                    RecogCondition = new StubIRecogCondition();
                    CamContloler = new StubICamContloler();
                    StatsResult = new StubIStatsResult();
                    WaitResponse = new StubIWaitResponse();
                    FilterConfig = new StubIFilterConfig();
                    AcquireCondition = new StubIAcquireCondition();
                    break;
                case "Real":
                    break;
                default:
                    throw new Exception($"設定されたモード '{mode}' は無効です。runsettingsファイルを確認してください。");
            }
        }
    }
}