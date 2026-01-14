using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    /// <summary>
    /// GUI設定
    /// </summary>

    public interface ISystemGUISettings : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// ライブラリモード
        /// </summary>
        bool LibraryMode { get; set; }

        /// <summary>
        /// タスクバーへのアイコン表示
        /// </summary>
        bool ShowInTaskbar { get; set; }

        /// <summary>
        /// GUIのロック
        /// </summary>
        bool GUILock { get; set; }

        /// <summary>
        /// 起動ウインドウの最小化
        /// </summary>
        bool WindowMinimized { get; set; }

        /// <summary>
        /// 起動ウインドウ表示タイプ
        /// </summary>
        DisplayModeType DispMode { get; set; }

        /// <summary>
        /// 履歴表示上限行数
        /// </summary>
        int LogDispLines { get; set; }

        /// <summary>
        /// 自動スクリーンショット
        /// </summary>
        bool AutoSaveScreen { get; set; }

        /// <summary>
        /// アプリケーション終了動作。
        /// </summary>
        AppsCloseActionType AppsCloseActionReborn { get; set; }

    }
}
