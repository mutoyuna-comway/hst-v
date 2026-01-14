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
    /// ログ出力設定クラス
    /// </summary>
    public interface ILumpLogOutput : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 全画像
        /// </summary>
        ILumpLogElement AllImage { get; set; }

        /// <summary>
        /// 失敗画像
        /// </summary>
        ILumpLogElement FailImage { get; set; }

        /// <summary>
        /// ログ出力：Job情報の保存
        /// </summary>
        ILumpLogElement JobData { get; set; }

        /// <summary>
        /// ログ出力：設定情報の保存
        /// </summary>
        ILumpLogElement LogData { get; set; }

        /// <summary>
        /// ログ出力：Conf情報の保存
        /// </summary>
        ILumpLogElement ConfData { get; set; }

        /// <summary>
        /// ログ出力：PC情報の保存
        /// </summary>
        ILumpLogElement PCInfo { get; set; }

        /// <summary>
        /// ログ出力：自己診断情報の保存
        /// </summary>
        ILumpLogElement SelfDiagnosisInfo { get; set; }

        /// <summary>
        /// 出力ログの1つ当たりのファイルサイズ
        /// </summary>
        /// <remarks>単位はMB</remarks>
        int SizeOfDevidedLog { get; set; }
    }


    public interface ILumpLogElement : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 保存可否
        /// </summary>
        bool IsSave { get; set; }

        /// <summary>
        /// 日時指定
        /// </summary>
        bool IsFromDate { get; set; }

        /// <summary>
        /// 開始日時
        /// </summary>
        DateTime FromDate { get; set; }

        /// <summary>
        /// 数量指定
        /// </summary>
        bool IsFileNum { get; set; }

        /// <summary>
        /// 保存ファイル数
        /// </summary>
        int SaveFileNum { get; set; }

        /// <summary>
        /// ファイル数
        /// </summary>
        long FileNum { get; set; }

        /// <summary>
        /// ファイルサイズ
        /// </summary>
        long FileSize { get; set; }

        /// <summary>
        /// FileList
        /// </summary>
        List<String> FileList { get; set; }
    }
}
