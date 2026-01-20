
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using StubWia.Abstructions;
using System;
using System.ComponentModel;
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
        protected IWiaSystem WiaSystemCopy { get; set; } = new StubIWiaSystem();

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

    }
}