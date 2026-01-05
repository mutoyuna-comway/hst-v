using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    public interface ISystemReadSettings
    {
        /// <summary>
        /// チェックサム文字列省略
        /// </summary>
        bool ChecksumOmmission { get; set; }

        /// <summary>
        /// スコア設定
        /// </summary>
        ScoreRange ScoreSetting { get; set; }

        /// <summary>
        /// 固定文字加点
        /// </summary>
        ScoreAs100 WaferScoreAs100 { get; set; }

        /// <summary>
        /// 読取文字出力
        /// </summary>
        bool DisableOutputResultString { get; set; }

        /// <summary>
        /// 読取OK/NG出力
        /// </summary>
        bool DisableOutputResultOKNG { get; set; }

        /// <summary>
        /// 読取スコア出力
        /// </summary>
        bool DisableOutputResultScore { get; set; }

        /// <summary>
        /// チェックサムファースト結果のスコア表示
        /// </summary>
        bool DisplayChecksumFirstAsAstah { get; set; }

        /// <summary>
        /// チューニング完了を待つタイムアウト時間　ミリ秒単位
        /// </summary>
        int TuneCompleteTimeout { get; set; }

        /// <summary>
        /// チューニング処理を継続するのに必要となる継続コマンド実行間隔　ミリ秒単位
        /// この時間内に継続コマンドを受信できないとチューニングは終了となる。
        /// </summary>
        int TuneContinueInterval { get; set; }
    }
}
