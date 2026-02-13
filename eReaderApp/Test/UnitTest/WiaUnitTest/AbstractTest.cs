
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StubWia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Wia.Abstractions;

namespace TestWiaSystem
{
    /// <summary>
    /// テストクラスの基底クラス
    /// 汎用的なチェック関数などを持つ
    /// </summary>
    public abstract class AbstractTest
    {
        /// <summary>
        /// 各インスタンスを保持
        /// これによりstubとの交換が容易になる
        /// </summary>
        protected static IWiaSystem WiaSystem => InstanceManager.WiaSystem;
        protected static IReadCompletedEventArgs ReadCompletedEventArgs => InstanceManager.ReadCompletedEventArgs;
        protected static IRecogCondition RecogCondition => InstanceManager.RecogCondition;
        protected static ICamContloler CamContloler => InstanceManager.CamContloler;
        protected static IStatsResult StatsResult => InstanceManager.StatsResult;
        protected static IWaitResponse WaitResponse => InstanceManager.WaitResponse;
        protected static IFilterConfig FilterConfig => InstanceManager.FilterConfig;
        protected static IAcquireCondition AcquireCondition => InstanceManager.AcquireCondition;
        protected static ITuningStrategy TuningStrategy => InstanceManager.TuningStrategy;
        protected static IReadOperationStartedEventArgs ReadOperationStartedEventArgs => InstanceManager.ReadOperationStartedEventArgs;
        protected static IReadOperationCompletedEventArgs ReadOperationCompletedEventArgs => InstanceManager.ReadOperationCompletedEventArgs;
        protected static IAcquireImageStartedEventArgs AcquireImageStartedEventArgs => InstanceManager.AcquireImageStartedEventArgs;
        protected static IAcquireImageCompletedEventArgs AcquireImageCompletedEventArgs => InstanceManager.AcquireImageCompletedEventArgs;
        protected static ILogMessageEventArgs LogMessageEventArgs => InstanceManager.LogMessageEventArgs;

        //インスタンスのgetter setterテスト用
        protected static IWiaSystem getCopyIWiaSystem()
        {
            return WiaSystem;
        }
        protected static IReadCompletedEventArgs getCopyIReadCompletedEventArgs()
        {
            return new StubIReadCompletedEventArgs();
        }
        /// <summary>
        /// プロパティのGetter/SetterおよびINotifyPropertyChangedを検証する汎用メソッド
        /// </summary>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        /// <param name="setter">値をセットするアクション (x => obj.Prop = x)</param>
        /// <param name="getter">値を取得する関数 (() => obj.Prop)</param>
        protected void VerifyProperty<TValue>(
            INotifyPropertyChanged viewModel,
            string propertyName,
            TValue newValue,
            Action<TValue> setter,
            Func<TValue> getter)
        {
            bool isEventRaised = false;
            // イベントハンドラを定義
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == propertyName)
                {
                    isEventRaised = true;
                }
            }

            // 1. イベントを購読
            viewModel.PropertyChanged += Handler;
            try
            {
                // 2. Setterを実行
                setter(newValue);

                // 3. 値が正しく更新されたか確認 (Getterのテスト)
                Assert.AreEqual(newValue, getter(), $"プロパティ '{propertyName}' の値が正しく更新されていません。");

                // 4. イベントが発火したか確認 (INotifyPropertyChangedのテスト)
                Assert.IsTrue(isEventRaised, $"プロパティ '{propertyName}' の変更通知(INotifyPropertyChanged)が発火しませんでした。");
            }
            finally
            {
                // 後始末：イベント購読解除
                viewModel.PropertyChanged -= Handler;
            }
        }

        /// <summary>
        /// プロパティのGetter/Setterを検証する汎用メソッド
        /// </summary>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        /// <param name="setter">値をセットするアクション (x => obj.Prop = x)</param>
        /// <param name="getter">値を取得する関数 (() => obj.Prop)</param>
        protected void VerifyPropertyWithoutINotifyPropertyChanged<TValue>(
            string propertyName,
            TValue newValue,
            Action<TValue> setter,
            Func<TValue> getter)
        {
            // Setterを実行
            setter(newValue);
            // 値が正しく更新されたか確認 (Getterのテスト)
            Assert.AreEqual(newValue, getter(), $"プロパティ '{propertyName}' の値が正しく更新されていません。");
        }


        /// <summary>
        /// プライベートプロパティへのSetメソッド
        /// </summary>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        protected void privateSet<TValue>(Object instance, string propertyName, TValue newValue)
        {
            var privateObject = new PrivateObject(instance);
            privateObject.SetProperty(propertyName, newValue);
        }


        /// <summary>
        /// パブリックプロパティのgetterメソッド
        /// </summary>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        protected TValue publicGet<TValue>(Object viewModel, string propertyName)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            // オブジェクトの型情報を取得
            Type type = viewModel.GetType();
            // 指定した名前のフィールド情報を取得（public, インスタンスフィールドを対象）
            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"フィールド '{propertyName}' が型 '{type.FullName}' に見つかりませんでした。");
            }

            // 値をセット
            return (TValue)property?.GetValue(viewModel);
        }

        /// <summary>
        /// パブリックプロパティのsetterメソッド
        /// </summary>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        protected void publicSet<TValue>(Object viewModel, string propertyName, TValue newValue)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));

            // オブジェクトの型情報を取得
            Type type = viewModel.GetType();
            // 指定した名前のフィールド情報を取得（public, インスタンスフィールドを対象）
            PropertyInfo property = type.GetProperty(propertyName);
            if (property == null)
            {
                throw new ArgumentException($"フィールド '{propertyName}' が型 '{type.FullName}' に見つかりませんでした。");
            }

            // 値をセット
            property?.SetValue(viewModel, newValue);
        }

        /// <summary>
        /// プロパティのテスト実行
        /// </summary>
        /// <typeparam name="TModel">プロパティの型</typeparam>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        protected void propertyTestExe<TModel, TValue>(TModel viewModel, string propertyName, TValue newValue)
        {
            // TModelがINotifyPropertyChangedを実装しているかどうかを判定し、
            // 検証処理を分岐する。
            if (viewModel is INotifyPropertyChanged INotifyPropertyChangedViewModel)
            {
                VerifyProperty(
                    INotifyPropertyChangedViewModel,
                    propertyName,
                    newValue,
                    value => this.publicSet(viewModel, propertyName, value),
                    () => this.publicGet<TValue>(viewModel, propertyName)
                );
            }
            else
            {
                VerifyPropertyWithoutINotifyPropertyChanged(
                    propertyName,
                    newValue,
                    value => this.publicSet(viewModel, propertyName, value),
                    () => this.publicGet<TValue>(viewModel, propertyName)
                );
            } 
                
                
        }

        /// <summary>
        /// プロパティのテスト実行 privateプロパティ用
        /// </summary>
        /// <typeparam name="TModel">プロパティの型</typeparam>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        protected void propertyTestExeWithPrivate<TModel, TValue>(TModel viewModel, string propertyName, TValue newValue)
        {
            // TModelがINotifyPropertyChangedを実装しているかどうかを判定し、
            // 検証処理を分岐する。
            if (viewModel is INotifyPropertyChanged INotifyPropertyChangedViewModel)
            {
                VerifyProperty(
                    INotifyPropertyChangedViewModel,
                    propertyName,
                    newValue,
                    value => this.privateSet(viewModel, propertyName, value),
                    () => this.publicGet<TValue>(viewModel, propertyName)
                );
            }
            else
            {
                VerifyPropertyWithoutINotifyPropertyChanged(
                    propertyName,
                    newValue,
                    value => this.privateSet(viewModel, propertyName, value),
                    () => this.publicGet<TValue>(viewModel, propertyName)
                );
            }
            
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        /// <typeparam name="TModel">プロパティの型</typeparam>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        /// <param name="isPrivate">プロパティがprivateかどうか</param>
        protected void PropertyTest<TModel, TValue>(TModel viewModel, string propertyName, TValue newValue, Boolean isPrivate) {

            System.Console.WriteLine("{0}のメンバ[{1}]のgetter setterテスト private={2}", nameof(viewModel), propertyName, isPrivate);

            if (isPrivate)
            {
                this.propertyTestExeWithPrivate(viewModel, propertyName, newValue);
            } 
            else
            {
                this.propertyTestExe(viewModel, propertyName, newValue);
            } 
        }

        /// <summary>
        /// オブジェクトのディープコピーを作成します。
        /// </summary>
        /// <typeparam name="T">コピーする型</typeparam>
        /// <param name="source">コピー元インスタンス</param>
        /// <returns>複製されたインスタンス</returns>
        public static T DeepCopy<T>(T source)
        {
            if (ReferenceEquals(source, null)) return default;
            
            // 型情報を含めてシリアライズ・デシリアライズする設定
            try
            {
                var settings = new JsonSerializerSettings
                {
                    ObjectCreationHandling = ObjectCreationHandling.Replace,
                    TypeNameHandling = TypeNameHandling.All,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,

                    // 【追加】ここでIPAddress用のコンバーターを登録する
                    Converters = new System.Collections.Generic.List<JsonConverter> { new IPAddressConverter() },
                    // エラーが発生した際、どのパスで起きたか詳細を出す設定
                    Error = (sender, args) => {
                        System.Diagnostics.Debug.WriteLine($"Serialization Error: {args.ErrorContext.Path}");
                    }
                };

                // Serialize時にも必ず settings を渡す
                var json = JsonConvert.SerializeObject(source, settings);
                return JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception ex)
            {
                var messages = new List<string>();
                var currentEx = ex;
                while (currentEx != null)
                {
                    messages.Add($"{currentEx.GetType().Name}: {currentEx.Message}\n{currentEx.StackTrace}");
                    currentEx = currentEx.InnerException;
                }

                string fullMessage = string.Join("\n\n--- Inner Exception ---\n\n", messages);
                throw new Exception($"{typeof(T).Name} のコピー中に致命的なエラーが発生しました。\n{fullMessage}", ex);
            }

        }
    }
}