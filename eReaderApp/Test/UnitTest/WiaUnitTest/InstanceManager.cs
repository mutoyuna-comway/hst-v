using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Linq;
using Wia.Abstractions;
// StubWia への直接の参照は、Reflectionを使うなら必須ではありませんが、型変換などで使う場合は残します

namespace TestWiaSystem
{
    public static class InstanceManager
    {
        public static TestContext TestContext { get; set; }

        private static IWiaSystem _wiaSystem;
        public static IWiaSystem WiaSystem
        {
            get
            {
                if (_wiaSystem == null)
                {
                    // .runsettings のキー名を指定してインスタンス化
                    _wiaSystem = getInstance<IWiaSystem>("WiaSystemImpl");
                    var privateObject = new PrivateObject(_wiaSystem.Job.Configs);
                    privateObject.SetProperty(nameof(_wiaSystem.Job.Configs.ParentJob), _wiaSystem.Job);
                }
                return _wiaSystem;
            }
        }

        private static IReadCompletedEventArgs _readCompletedEventArgs;
        public static IReadCompletedEventArgs ReadCompletedEventArgs
        {
            get
            {
                if (_readCompletedEventArgs == null)
                {
                    _readCompletedEventArgs = getInstance<IReadCompletedEventArgs>("ReadCompletedEventArgsImpl");
                }
                return _readCompletedEventArgs;
            }
        }

        private static IRecogCondition _recogCondition;
        public static IRecogCondition RecogCondition
        {
            get
            {
                if (_recogCondition == null)
                {
                    _recogCondition = getInstance<IRecogCondition>("RecogConditionImpl");
                }
                return _recogCondition;
            }
        }


        private static ICamContloler _camContloler;
        public static ICamContloler CamContloler
        {
            get
            {
                if (_camContloler == null)
                    _camContloler = getInstance<ICamContloler>("CamContlolerImpl");
                return _camContloler;
            }
        }

        private static IStatsResult _statsResult;
        public static IStatsResult StatsResult
        {
            get
            {
                if (_statsResult == null)
                    _statsResult = getInstance<IStatsResult>("StatsResultImpl");
                return _statsResult;
            }
        }

        private static IWaitResponse _waitResponse;
        public static IWaitResponse WaitResponse
        {
            get
            {
                if (_waitResponse == null)
                    _waitResponse = getInstance<IWaitResponse>("WaitResponseImpl");
                return _waitResponse;
            }
        }

        private static IFilterConfig _filterConfig;
        public static IFilterConfig FilterConfig
        {
            get
            {
                if (_filterConfig == null)
                    _filterConfig = getInstance<IFilterConfig>("FilterConfigImpl");
                return _filterConfig;
            }
        }

        private static IAcquireCondition _acquireCondition;
        public static IAcquireCondition AcquireCondition
        {
            get
            {
                if (_acquireCondition == null)
                    _acquireCondition = getInstance<IAcquireCondition>("AcquireConditionImpl");
                return _acquireCondition;
            }
        }

        private static ITuningStrategy _tuningStrategy;
        public static ITuningStrategy TuningStrategy
        {
            get
            {
                if (_tuningStrategy == null)
                    _tuningStrategy = getInstance<ITuningStrategy>("TuningStrategyImpl");
                return _tuningStrategy;
            }
        }

        private static IReadOperationStartedEventArgs _readOperationStartedEventArgs;
        public static IReadOperationStartedEventArgs ReadOperationStartedEventArgs
        {
            get
            {
                if (_readOperationStartedEventArgs == null)
                    _readOperationStartedEventArgs = getInstance<IReadOperationStartedEventArgs>("ReadOperationStartedEventArgsImpl");
                return _readOperationStartedEventArgs;
            }
        }

        private static IReadOperationCompletedEventArgs _readOperationCompletedEventArgs;
        public static IReadOperationCompletedEventArgs ReadOperationCompletedEventArgs
        {
            get
            {
                if (_readOperationCompletedEventArgs == null)
                    _readOperationCompletedEventArgs = getInstance<IReadOperationCompletedEventArgs>("ReadOperationCompletedEventArgsImpl");
                return _readOperationCompletedEventArgs;
            }
        }

        private static IAcquireImageStartedEventArgs _acquireImageStartedEventArgs;
        public static IAcquireImageStartedEventArgs AcquireImageStartedEventArgs
        {
            get
            {
                if (_acquireImageStartedEventArgs == null)
                    _acquireImageStartedEventArgs = getInstance<IAcquireImageStartedEventArgs>("AcquireImageStartedEventArgsImpl");
                return _acquireImageStartedEventArgs;
            }
        }

        private static IAcquireImageCompletedEventArgs _acquireImageCompletedEventArgs;
        public static IAcquireImageCompletedEventArgs AcquireImageCompletedEventArgs
        {
            get
            {
                if (_acquireImageCompletedEventArgs == null)
                    _acquireImageCompletedEventArgs = getInstance<IAcquireImageCompletedEventArgs>("AcquireImageCompletedEventArgsImpl");
                return _acquireImageCompletedEventArgs;
            }
        }

        private static ILogMessageEventArgs _logMessageEventArgs;
        public static ILogMessageEventArgs LogMessageEventArgs
        {
            get
            {
                if (_logMessageEventArgs == null)
                    _logMessageEventArgs = getInstance<ILogMessageEventArgs>("LogMessageEventArgsImpl");
                return _logMessageEventArgs;
            }
        }

        /// <summary>
        /// runsettingsの設定値からクラス名を読み取り、リフレクションでインスタンスを生成する
        /// </summary>
        /// <typeparam name="TValue">キャストするインターフェース型</typeparam>
        /// <param name="settingKeyName">runsettings内のParameter名</param>
        /// <returns>生成されたインスタンス</returns>
        private static TValue getInstance<TValue>(string settingKeyName)
        {
            if (TestContext == null)
            {
                throw new InvalidOperationException("TestContext が null です。TestInitialize または ClassInitialize で InstanceManager.TestContext を設定してください。");
            }

            // 1. 設定値（クラス名文字列）を取得
            if (!TestContext.Properties.ContainsKey(settingKeyName))
            {
                throw new ArgumentException($"runsettings にパラメータ '{settingKeyName}' が定義されていません。");
            }

            string className = TestContext.Properties[settingKeyName] as string;

            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException($"パラメータ '{settingKeyName}' の値が空です。");
            }

            // 2. 型情報を取得 (アセンブリ修飾名なら別DLLでもロード可能)
            Type type = Type.GetType(className);

            if (type == null)
            {
                throw new TypeLoadException($"クラス '{className}' が見つかりません。アセンブリ名が含まれているか確認してください。(例: 'Namespace.Class, AssemblyName')");
            }

            // 3. インスタンス生成
            try
            {
                return (TValue)Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"クラス '{className}' のインスタンス生成に失敗しました。デフォルトコンストラクタが存在するか確認してください。", ex);
            }
        }
    }
}