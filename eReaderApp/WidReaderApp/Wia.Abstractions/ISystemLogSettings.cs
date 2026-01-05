using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    public interface ISystemLogSettings
    {
        /// <summary>
        /// コマンドログ出力可否
        /// </summary>
        bool CommandLogOutput { get; set; }

        /// <summary>
        /// ログ出力
        /// </summary>
        ILumpLogOutput LogOutput { get; set; }

        /// <summary>
        /// ログ出力
        /// </summary>
        int LogUpdateCount { get; set; }

        /// <summary>
        /// 画像保存設定
        /// </summary>
        IImageSaveSettings ImgSaveSetting { get; set; }

        /// <summary>
        /// カメラ処理の詳細ログを出力するかどうか
        /// </summary>
        bool AppCameraLogEnabled { get; set; }

        /// <summary>
        /// 起動時シーケンスの詳細ログを出力するかどうか
        /// </summary>
        bool AppStartupLogEnabled { get; set; }

        /// <summary>
        /// 異常時の情報出力の動作モード<br>
        /// - Disabled(0)    :無効, 
        /// - AutoCleanup(1) :有効、ファイル自動削除
        /// - KeepFiles(2)   :有効、ファイル保持
        /// </summary>
        ParamsBackupModeConstants ParamsBackupMode { get; set; }

        /// <summary>
        /// 読取り時のパラメータ文字列のログ出力モード<br>
        /// - Disabled(0)   : 無効
        /// - OnFailOnly(1) : 読取失敗時のみ出力する
        /// - Always(2)     : 読取時毎回出力する
        /// </summary>
        ReadParamLogConstants ReadParamLog { get; set; }

        /// <summary>
        /// チューニング承認画像保存枚数
        /// </summary>
        int TuneAcceptImageSaveNum { get; set; }

        /// <summary>
        /// チューニング詳細結果の出力をするかどうか true:有効
        /// </summary>
        bool TuneDetailLogOutput { get; set; }

        /// <summary>
        /// チューニング詳細結果のログ出力内容をソート出力をするかどうか true:有効
        /// </summary>
        bool TuneDetailLogSortEnabled { get; set; }

        /// <summary>
        /// チューニング詳細結果の最大保存件数
        /// </summary>
        int TuneDetailLogMaxNum { get; set; }
    }
}
