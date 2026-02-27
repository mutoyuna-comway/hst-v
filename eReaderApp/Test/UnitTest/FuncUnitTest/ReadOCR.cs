using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// ReadOCRのユニットテストクラス
/// </summary>
namespace FuncUnitTest
{
    /// <summary>
    /// ReadOCRのユニットテストクラス
    /// </summary>
    [TestClass]
    public class ReadOCR
    {
        /// <summary>
        /// チェックサム
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ジョブ設定 - チェックサム</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_CheckSum() 
        {
        }

        /// <summary>
        /// マーク色
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ジョブ設定 - マーク色</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_MarkColor()
        {
        }

        /// <summary>
        /// フィールド文字列
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ジョブ設定 - フィールド文字列</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_FieldString()
        {
        }

        /// <summary>
        /// 文字しきい値
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ジョブ設定 - 文字しきい値</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_CharThreshold()
        {
        }

        /// <summary>
        /// 文字列しきい値
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ジョブ設定 - 文字列しきい値</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_StringThreshold()
        {
        }

        /// <summary>
        /// 基準線エラー
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ジョブ設定 - 基準線エラー</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_BaseLineError()
        {
        }

        /// <summary>
        /// スペースエラー
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ジョブ設定 - スペースエラー</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_SpaceError()
        {
        }

        /// <summary>
        /// 認識モード
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 認識モード</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_OperationMode()
        {
        }

        /// <summary>
        /// 追加フォント
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 追加フォント</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_CustomFontIDString()
        {
        }

        /// <summary>
        /// コンフィージョン閾値
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - コンフィージョン閾値</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_ConfusionThreshold()
        {
        }

        /// <summary>
        /// コンフィージョンチェックサム
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - コンフィージョンチェックサム</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_UseConfusionChecksum()
        {
        }

        /// <summary>
        /// 前処理フィルタ
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 前処理フィルタ</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_Preprocess()
        {
        }

        /// <summary>
        /// 文字幅補正フィルタ
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 文字幅補正フィルタ</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_StrokeFilter()
        {
        }

        /// <summary>
        /// 文字幅補正サイズ 
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 文字幅補正サイズ</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_StrokeFilterSize()
        {
        }

        /// <summary>
        /// 標準文字間隔(文字幅比)
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 標準文字間隔(文字幅比)</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_NominalPitchRatio()
        {
        }

        /// <summary>
        /// 広い文字間隔 
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 広い文字間隔</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_EnableWideRangeCharacter()
        {
        }

        /// <summary>
        /// 読取リトライ 
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 読取リトライ</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_ReadingRetry()
        {
        }

        /// <summary>
        /// チェックサムファースト 
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - チェックサムファースト</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_CheckSumFirst()
        {
        }

        /// <summary>
        /// 記号読取 
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 記号読取</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_SymbolReading()
        {
        }

        /// <summary>
        /// 記号認識しきい値 
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 記号認識しきい値</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_SymbolAccept()
        {
        }

        /// <summary>
        /// 内部フィルタ 
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>パラメータ設定 - 読取設定 - SEMI文字 - 内部フィルタ</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_InternalFilter()
        {
        }

        /// <summary>
        /// SEMI OCR スコア範囲
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>保守設定 - 読取設定 - SEMI OCR スコア範囲</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_ScoreRange()
        {
        }

        /// <summary>
        /// SEMI OCR 記号スコア
        /// <para>
        /// 画面上での項目は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>保守設定 - 読取設定 - SEMI OCR 記号スコア</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_SymbolScore()
        {
        }
    }
}
