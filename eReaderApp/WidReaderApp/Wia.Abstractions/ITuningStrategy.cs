using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// チューニング手法・方針
    /// </summary>
    public interface ITuningStrategy : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------
        
        /// <summary>
        /// マルチ照明チューンを強制する
        /// </summary>
        bool IsMultiLightTuneForced { get; set; }

        /// <summary>
        /// 進捗率
        /// </summary>
        double Progress { get; }

        /// <summary>
        /// 最新のチューニング結果
        /// </summary>
        ITuneResult LatestTuningResult { get; }

        /// <summary>
        /// チューン記録文字列
        /// </summary>
        string TuneHistory { get; }

        /// <summary>
        /// 実行条件を保存するフォルダ名
        /// </summary>
        string ArchiveFolderName { get; set; }

        /// <summary>
        /// 保存した実行条件ファイルを実行後に削除するかどうか
        /// </summary>
        bool IsArchiveAutoCleanup { get; set; }

        /// <summary>
        /// スコア計算方法のモード
        /// </summary>
        ScoreMode ScoreType { get; set; }

        /// <summary>
        /// 非英数字の得点方法
        /// </summary>
        ScoreAs100 WaferScoreAs100 { get; set; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        /// <summary>
        /// チューニングフェーズ開始を通知するイベント
        /// </summary>
        event EventHandler TuningPhaseStarted;

        /// <summary>
        /// チューニングフェーズ完了を通知するイベント
        /// </summary>
        event EventHandler TuningPhaseCompleted;

        /// <summary>
        /// ID読取り処理開始を通知するイベント
        /// </summary>
        event EventHandler<IReadOperationStartedEventArgs> ReadOperationStarted;

        /// <summary>
        /// ID読取り処理完了を通知するイベント
        /// </summary>
        event EventHandler<IReadOperationCompletedEventArgs> ReadOperationCompleted;

        /// <summary>
        /// チューニング結果が更新されたことを通知するイベント
        /// </summary>
        event EventHandler TuningResultUpdated;

        /// <summary>
        /// ベストの結果が更新されたことを通知するイベント
        /// </summary>
        event EventHandler BestTuningResultUpdated;

        /// <summary>
        /// 画像取込み開始を通知するイベント
        /// </summary>
        event EventHandler<IAcquireImageStartedEventArgs> AcquireImageStarted;

        /// <summary>
        /// 画像取込み完了を通知するイベント
        /// </summary>
        event EventHandler<IAcquireImageCompletedEventArgs> AcquireImageCompleted;

        /// <summary>
        /// ログメッセージが利用可能になったことを通知するイベント
        /// </summary>
        event EventHandler<ILogMessageEventArgs> LogMessageAvailable;


        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// シーケンスの実行
        /// </summary>
        /// <param name="conf">ジョブコンフィグ</param>
        /// <param name="token">中断トークン</param>
        /// <returns>チューン成功可否</returns>
        bool RunSequence(IJobConfig conf, CancellationToken token);

        /// <summary>
        /// 画像ソースの設定
        /// </summary>
        /// <param name="imageSource">画像ソース</param>
        void SetImageSource( IImageSource imageSource );
    }

    /// <summary>
    /// ID読取り開始を通知するイベント引数
    /// </summary>

    public interface IReadOperationStartedEventArgs
    {
        /// <summary>
        /// 実行レコード番号
        /// </summary>
        int RecordNumber { get; }

        /// <summary>
        /// 読取り設定
        /// </summary>
        IJobReadSettings ReadSettings { get; }

        /// <summary>
        /// 処理画像
        /// </summary>
        IImage ProcessImage { get; }
    }

    /// <summary>
    /// ID読取り終了を通知するイベント引数
    /// </summary>

    public interface IReadOperationCompletedEventArgs : IReadOperationStartedEventArgs
    {
        /// <summary>
        /// 読取り結果
        /// </summary>
        IReadResult ReadResult { get; }
    }


    /// <summary>
    /// 画像取込み開始を通知するイベント引数
    /// </summary>
    public interface IAcquireImageStartedEventArgs
    {
        /// <summary>
        /// 実行レコード番号
        /// </summary>
        int RecordNumber { get; }

        /// <summary>
        /// 画像取込設定
        /// </summary>
        IJobAcqSettings AcqSettings { get; }
    }

    /// <summary>
    /// 画像取込み完了を通知するイベント引数
    /// </summary>
    public interface IAcquireImageCompletedEventArgs : IAcquireImageStartedEventArgs
    {
        /// <summary>
        /// 画像取込み結果
        /// </summary>
        IAcquireResult AcqResult { get; }
    }


    /// <summary>
    /// ログメッセージが利用可能になったことを通知するイベント引数
    /// </summary>
    public interface ILogMessageEventArgs
    {
        /// <summary>
        /// 実行レコード番号
        /// </summary>
        int RecordNumber { get; }

        /// <summary>
        /// メッセージ
        /// </summary>
        string Message { get; }

        /// <summary>
        /// サブメッセージ
        /// </summary>
        string MessageSub { get; }
    }
}
