using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


/// <summary>
/// JobOperationのユニットテストクラス
/// </summary>
namespace FuncUnitTest
{
    /// <summary>
    /// JobOperationのユニットテストクラス  
    /// </summary>
    [TestClass]
    public class JobOperation
    {
        /// <summary>
        /// 新規作成
        /// <para>
        /// 画面上での操作は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ファイル管理 - 新規作成</item>
        /// </list>
        /// <remarks>
        /// ジョブテンプレート指定有無での確認
        /// </remarks>
        /// </summary>
        [TestMethod]
        public void Test_New()
        {
        }

        /// <summary>
        /// 保存
        /// <para>
        /// 画面上での操作は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ファイル管理 - 上書き保存</item>
        /// <item>ファイル管理 - 別名保存</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_Save()
        {
        }

        /// <summary>
        /// 読込み
        /// <para>
        /// 画面上での操作は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>ファイル管理 - 上書き保存</item>
        /// <item>ファイル管理 - 別名保存</item>
        /// </list>
        /// <remarks>
        /// バージョン毎の互換性の確認
        /// </remarks>
        /// </summary>
        [TestMethod]
        public void Test_Load()
        {
        }

        /// <summary>
        /// 起動時読込み
        /// <para>
        /// 画面上での操作は以下の通り
        /// </para>
        /// <list type="bullet">
        /// <item>保守設定 - JOBテンプレート</item>
        /// <item>保守設定 - 起動時読込JOB</item>
        /// </list>
        /// </summary>
        [TestMethod]
        public void Test_Startup()
        {
        }
    }
}
