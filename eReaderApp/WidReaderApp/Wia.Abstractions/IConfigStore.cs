using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ジョブコンフィグのコレクション
    /// </summary>
    public interface IConfigStore : IEnumerable<IJobConfig>
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 親ジョブ
        /// </summary>
        IJob ParentJob { get; }

        /// <summary>
        /// 現在ストアされているコンフィグの数
        /// </summary>
        int Count { get; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        event EventHandler CollectionChanging;
        event EventHandler CollectionChanged;

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// コンフィグ番号からジョブコンフィグを取得する
        /// </summary>
        /// <param name="configId">コンフィグ番号</param>
        /// <returns>ジョブコンフィグ</returns>
        /// <remarks>コンフィグが作成されていなければ、新規に作成し追加する</remarks>
        IJobConfig GetOrDefault(int configId);

    }
}
