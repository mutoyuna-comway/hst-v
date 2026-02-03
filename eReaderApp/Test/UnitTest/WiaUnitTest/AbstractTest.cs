
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using StubWia.Abstructions;
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
    public abstract class AbstractTest
    {
        /// <summary>
        /// 各インスタンスを保持
        /// これによりstubとの交換が容易になる
        /// </summary>
        protected IWiaSystem WiaSystem { get; set; } = new StubIWiaSystem();
        protected IReadCompletedEventArgs ReadCompletedEventArgs { get; set; } = new StubIReadCompletedEventArgs();
        protected IRecogCondition RecogCondition { get; set; } = new StubIRecogCondition();
        protected ICamContloler CamContloler { get; set; } = new StubICamContloler();
        protected IStatsResult StatsResult { get; set; } = new StubIStatsResult();
        protected IWaitResponse WaitResponse { get; set; } = new StubIWaitResponse();
        protected IFilterConfig FilterConfig { get; set; } = new StubIFilterConfig();
        protected IAcquireCondition AcquireCondition { get; set; } = new StubIAcquireCondition();
        //インスタンスのgetter setterテスト用
        protected static IWiaSystem getCopyIWiaSystem() { 
            return new StubIWiaSystem();
        }
        protected static IReadCompletedEventArgs getCopyIReadCompletedEventArgs()
        {
            return new StubIReadCompletedEventArgs();
        }
        protected static IRecogCondition getCopyIRecogCondition()
        {
            return new StubIRecogCondition();
        }
        protected static ICamContloler getCopyICamContloler()
        {
            return new StubICamContloler();
        }
        protected static IStatsResult getCopyIStatsResult()
        {
            return new StubIStatsResult();
        }
        protected static IWaitResponse getCopyIWaitResponse()
        {
            return new StubIWaitResponse();
        }
        protected static IFilterConfig getCopyIFilterConfig()
        {
            return new StubIFilterConfig();
        }
        protected static IAcquireCondition getCopyIAcquireCondition()
        {
            return new StubIAcquireCondition();
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
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        protected void propertyTestExe<TValue>(INotifyPropertyChanged viewModel, string propertyName, TValue newValue)
        {
            VerifyProperty(
                viewModel,
                propertyName,
                newValue,
                value => this.publicSet(viewModel, propertyName, value),
                () => this.publicGet<TValue>(viewModel, propertyName)
            );
        }

        /// <summary>
        /// プロパティのテスト実行 privateプロパティ用
        /// </summary>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        protected void propertyTestExeWithPrivate<TValue>(INotifyPropertyChanged viewModel, string propertyName, TValue newValue)
        {
            VerifyProperty(
                viewModel,
                propertyName,
                newValue,
                value => this.privateSet(viewModel, propertyName, value),
                () => this.publicGet<TValue>(viewModel, propertyName)
            );
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        /// <typeparam name="TValue">プロパティの型</typeparam>
        /// <param name="viewModel">テスト対象のインスタンス</param>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="newValue">セットするテスト値</param>
        /// <param name="isPrivate">プロパティがprivateかどうか</param>
        protected void PropertyTest<TValue>(INotifyPropertyChanged viewModel, string propertyName, TValue newValue, Boolean isPrivate) {

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

    }
}