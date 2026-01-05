using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    public interface ISystemSettings
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// システムパスワード
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// システムフォルダーのフルパス
        /// </summary>
       string SystemRootFolderName { get; set; }

        /// <summary>
        /// システムルート
        /// </summary>
        string SystemRoot { get; set; }

        /// <summary>
        /// システムフォルダ
        /// </summary>
        string SystemFolder { get; set; }

        /// <summary>
        /// デバイスフォルダ
        /// </summary>
        string DeviceFolder { get; set; }

        /// <summary>
        /// デバイスID
        /// </summary>
        int DeviceID { get; set; }

        /// <summary>
        /// プロセッサの設定
        /// </summary>
        IProcessorSettings ProcSetting { get; set; }

        /// <summary>
        /// 外部照明の利用可否
        /// </summary>
        bool UseExternalLight { get; set; }

        /// <summary>
        /// 利用言語
        /// </summary>
        string UseLanguage { get; set; }

        /// <summary>
        /// 外部照明の利用可否
        /// </summary>
        bool ExpandConfig { get; set; }

        /// <summary>
        /// ジョブのテンプレート
        /// </summary>
        string JobTemplate { get; set; }

        /// <summary>
        /// 起動ジョブファイル
        /// </summary>
        string StartupJob { get; set; }

        /// <summary>
        /// アプリケーションの動作仕様
        /// </summary>
        ApplicationType AppOperationalSpec { get; set; }

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// システムフォルダの取得
        /// </summary>
        /// <returns>ディレクトリ</returns>
        string GetSystemFolder();

        /// <summary>
        /// デバイスフォルダ取得
        /// </summary>
        /// <returns>ディレクトリ</returns>
        string GetDeviceFolder();

        /// <summary>
        /// Appフォルダの取得
        /// </summary>
        /// <returns>ディレクトリ</returns>
        string GetAppFolder();

        /// <summary>
        /// Jobフォルダの取得
        /// </summary>
        /// <returns>ディレクトリ</returns>
        string GetJobFolder();

        /// <summary>
        /// AllImageフォルダの取得
        /// </summary>
        /// <returns>ディレクトリ</returns>
        string GetDefaultAllImageFolder();

        /// <summary>
        /// FailImageフォルダの取得
        /// </summary>
        /// <returns>ディレクトリ</returns>
        string GetDefaultFailImageFolder();

        /// <summary>
        /// Logフォルダの取得
        /// </summary>
        /// <returns>ディレクトリ</returns>
        string GetLogFolder();

        /// <summary>
        /// システムルートフォルダ名の設定を禁止する。
        /// </summary>
        void ProhibitSettingSystemRootFolder();

    }
}
