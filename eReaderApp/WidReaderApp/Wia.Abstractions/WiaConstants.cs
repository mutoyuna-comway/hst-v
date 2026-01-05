using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    public static class WiaConstants
    {
        public const string AppVersion = "1.0.0.5";
        public const string ParamsBackupFolderName = "ParamsBackup";
        public const string CamErrorImageFolderName = "CamErrorImage";
    }

    //
    // 以下、WiaSharedCompに配置されたEnumsと互換のある値を持つ列挙子
    // 将来的に、ここにenum定義はまとめる
    //
    //

    // TODO: 列挙子の表示名を指定する属性を作成する


    /// <summary>
    /// 取得画像の種類
    /// </summary>
    [DataContract]
    public enum AcquiredType
    {
        Unspecified = 0, /// <summary>未指定</summary>
        Acquire = 1,     /// <summary>画像取得</summary>
        Live = 2,        /// <summary>ライブ</summary>
        Tune = 4,        /// <summary>チューン</summary>
        ReadAll = 8,     /// <summary>読取毎回</summary>
        ReadResult = 16, /// <summary>読取結果</summary>
    };

    /// <summary>
    /// 取込手法
    /// </summary>
    [DataContract]
    public enum AcquireMethod
    {
        Normal = 0,       /// <summary>通常取込</summary>
        AdvancedAuto = 1, /// <summary>AdvancedAuto</summary>
        MasterSlave = 2,  /// <summary>MasterSlave</summary>
        HDR = 3           /// <summary>HDR</summary>
    };

    /// <summary>
    /// アプリケーション終了動作
    /// </summary>
    [DataContract]
    public enum AppsCloseActionType
    {
        ConfirmClosing = 0,   /// <summary>終了確認をした後にアプリケーションを閉じる</summary>
        MoveToSystemTray = 1, /// <summary>アプリケーションは閉じないで、システムトレイへの移動する</summary>
        NoConfirm = 2,        /// <summary>終了確認なしでアプリケーションを閉じる</summary>
    };

    /// <summary>
    /// アプリケーションのタイプ
    /// </summary>
    public enum ApplicationType
    {
        /// <summary>
        /// e-Reader8000アプリケーション
        /// </summary>
        Er8000 = 0,
        /// <summary>
        /// e-ReaderPro Focusアプリケーション
        /// </summary>
        ProFocus = 1,
    };

    /// <summary>
    /// バーコード処理認識モード
    /// </summary>
    [DataContract]
    public enum BarcodeOperationMode
    {
        Fast = 0,    /// <summary>高速</summary>
        Normal = 1,  /// <summary>通常</summary>
        Enhanced = 2,/// <summary>Enhanced</summary>
    };

    /// <summary>
    /// 文字制限
    /// </summary>
    [DataContract]
    public enum CharacterLimitationType
    {
        None = 0,    /// <summary>なし</summary>
        ASCII = 1,   /// <summary>ASCII文字</summary>
        SEMIOCR = 2, /// <summary>SEMIOCR文字</summary>
    };

    /// <summary>
    /// チェックサムファーストの設定
    /// </summary>
    [DataContract]
    public enum ChecksumFirstType
    {
        None = 0,    /// <summary>実行しない</summary>
        OneChar = 1, /// <summary>1文字許容</summary>
        AddCS = 2,   /// <summary>CheckSum文字許容</summary>
        TwoChar = 2, /// <summary>2文字許容</summary>
    };

    /// <summary>
    /// チェックサムのタイプ
    /// </summary>
    [DataContract]
    public enum ChecksumType
    {
        /// <summary>
        /// なし
        /// </summary>
        None = 0,
        /// <summary>
        /// SEMIチェックサム
        /// </summary>
        Semi = 1,
        /// <summary>
        /// BC412チェックサム
        /// </summary>
        BC412 = 2,
        /// <summary>
        /// IBMチェックサム
        /// </summary>
        IBM = 3,
    };

    /// <summary>
    /// 通信設定
    /// </summary>
    [DataContract]
    public enum CommunicatorType
    {
        Socket = 0, /// <summary>ソケット通信</summary>
        Serial = 1  /// <summary>シリアル通信</summary>
    };

    /// <summary>
    /// デリミタ設定
    /// </summary>
    [DataContract]
    public enum DelimeterType
    {
        CRLF = 0, 
        CR = 1  　
    };

    /// <summary>
    /// 起動時のディスプレイタイプ
    /// </summary>
    [DataContract]
    public enum DisplayModeType
    {
        Normal = 0,      ///< 通常</summary>
        Monitor = 1,     ///< モニタモード</summary>
        MonitorHalf = 2, ///< モニタモード1/2</summary>
    };

    /// <summary>
    /// DMのグリッド数
    /// </summary>
    [DataContract]
    public enum DMGridSize
    {
        DMS10x10 = 1, 
        DMS12x12 = 2, 
        DMS14x14 = 3, 
        DMS16x16 = 4, 
        DMS18x18 = 5, 
        DMS20x20 = 6, 
        DMS22x22 = 7, 
        DMS24x24 = 8, 
        DMS26x26 = 9, 

        DMS8x18 = 101,
        DMS8x32 = 102,
        DMS12x26 = 103, 
        DMS12x36 = 104, 
        DMS16x36 = 105, 
        DMS16x48 = 105, 
    };

    /// <summary>
    /// フィルタ適用順序
    /// </summary>
    [DataContract]
    public enum FilterOrder
    {
        First = 1,  /// <summary>First</summary>
        Second = 2, /// <summary>Second</summary>
        Third = 3   /// <summary>Third</summary>
    };

    /// <summary>
    /// 前処理タイプ
    /// </summary>
    public enum PreprocessType
    { 
        None = 0,
        Gaussian = 1
    };

    /// <summary>
    /// フィルタの種類
    /// </summary>
    [DataContract]
    public enum FilterType
    {
        None = 0,     ///< なし</summary>
        Erode = 1,    ///< 縮小</summary>
        Dilate = 2,   ///< 拡張</summary>
        Open = 3,     ///< Open</summary>
        Close = 4,    ///< Close</summary>
        Gauss = 5,    ///< ガウス</summary>
        Median = 6,   ///< メディアン</summary>
        TopHat = 7,   ///< TopHat</summary>
        BlackHat = 8, ///< BlackHat</summary>
        Gradient = 9, ///< Gradient  </summary>
        LevelRevise = 10, ///< LevelRevise</summary>
        NoiseCut1 = 21,   ///< NoiseCut1</summary>
        NoiseCut2 = 22,   ///< NoiseCut2</summary>
        NoiseCut5 = 23,   ///< NoiseCut5</summary>
        NoiseCut10 = 24,  ///< NoiseCut10</summary>
        External = 30,    ///< 外部</summary>
        Thickening = 101, ///< 太線化</summary>
        Thinning = 102,   ///< 細線化</summary>
    }

    /// <summary>
    ///　画像拡大率
    /// </summary>
    [DataContract]
    public enum ImageExpandRate
    {
        Rate1X = 1,///< 1倍</summary>
        Rate2X = 2,///< 2倍</summary>
        Rate3X = 3 ///< 3倍</summary>
    };

    /// <summary>
    /// 画像反転
    /// </summary>
    [DataContract]
    public enum ImageOrient
    {
        /// <summary>
        /// 通常
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 水平反転
        /// </summary>
        HorizontalFlip = 1,
        /// <summary>
        /// 垂直反転
        /// </summary>
        VerticalFlip = 2,
        /// <summary>
        /// 180度回転
        /// </summary>
        Rotate180 = 3,
    }

    /// <summary>
    /// 画像拡大サイズモード
    /// </summary>
    [DataContract]
    public enum ImageSizeMode
    {
        Zoom = 0,   ///< ズーム</summary>
        Expand = 1, ///< 拡張</summary>
    };

    /// <summary>
    /// フィルタの種類
    /// </summary>
    [DataContract]
    public enum InternalFilterType
    {
        None = 0, ///< なし</summary>
        HorizontalRemoveFilter = 1, ///< 水平成分減衰フィルタ</summary>
    }

    /// <summary>
    /// マーク色
    /// </summary>
    [DataContract]
    public enum MarkColor
    {
        /// <summary>
        /// 黒色
        /// </summary>
        Black = 0,
        /// <summary>
        /// 白色
        /// </summary>
        White = 1,
        /// <summary>
        /// 自動選択
        /// </summary>
        Auto = 2,
    };

    /// <summary>
    /// 読取マーク種類
    /// </summary>
    [DataContract]
    public enum MarkType
    {
        T7 = 0,     ///< T7 : 値0</summary>
        BC412 = 1,  ///< BC412 : 値1</summary>
        IBM412 = 2, ///< IBM412 : 値2</summary>
        OCR = 4,    ///< OCR : 値4</summary>
        DataMatrix = 8, ///< DataMatrix : 値8</summary>
        QR = 10,        ///< QRCode : 値10</summary>
    };

    /// <summary>
    /// コンフィグ最大数タイプ
    /// </summary>
    [DataContract]
    public enum MaxNumConfigType
    {
        Num16 = 0, ///< 16個 : 値0</summary>
        Num50 = 1, ///< 50個 : 値1</summary>
    };

    /// <summary>
    /// OCRGridJudgeMode
    /// </summary>
    [DataContract]
    public enum OCRGridJudgeMode
    {
        Auto = 0,       ///< 通常(通常利用, OperationModeに従う)</summary>
        Foreground = 1, ///< 前景のみ(WaferProcessと同様)</summary>
        Background = 2, ///< 背景のみ(対象モードなし)</summary>
        Both = 3,       ///< 両方(Postprocessと同様)</summary>
        None = 4,       ///< 設定しない</summary>
    };

    /// <summary>
    /// OCRの認識モード
    /// </summary>
    [DataContract]
    public enum OCROperationMode
    {
        Normal = 0,        ///< 通常(通常利用, 後工程向け)</summary>
        Enhanced = 1,      ///< Enhanced</summary>
        NormalLimited = 2, ///< NormalLimited(小さい文字向け)</summary>
        Generic = 10,      ///< Generic(誤読防止機能:グリッド判定を実行しない)</summary>
        WaferProcess = 11, ///< WaferProcess(前工程向け)</summary>
    };

    /// <summary>
    /// 異常時の情報出力の動作モードの定数
    /// </summary>
    public enum ParamsBackupModeConstants
    {
        /// <summary>
        /// 異常時の情報出力機能を無効にする。
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// バックアップしたファイルを自動で削除する。
        /// </summary>
        AutoCleanup = 1,

        /// <summary>
        /// バックアップしたファイルを削除せず保持する。
        /// </summary>
        KeepFiles = 2
    }

    /// <summary>
    /// QRのグリッド数
    /// </summary>
    [DataContract]
    public enum QRGridSize
    {
        QRS21x21 = 1, 
        QRS25x25 = 2, 
        QRS29x29 = 3, 
        QRS33x33 = 4, 
        QRS37x37 = 5, 

        QRS41x41 = 6, 
        QRS45x45 = 7, 
        QRS49x49 = 8, 
        QRS53x53 = 9, 
        QRS57x57 = 10, 
    }

    [DataContract]
    public enum ReadMethod
    {
        LastBest = 0, ///< 直前のスコアで良いもの順</summary>
        InOrder = 1,  ///< 先頭から順番で読み取れたら終了</summary>
        All = 2,      ///< 全て読取りスコアの高いもの</summary>
    };

    /// <summary>
    /// 読取り時のパラメータ文字列のログ出力モードの定数
    /// </summary>
    public enum ReadParamLogConstants
    {
        /// <summary>
        /// 出力しない。
        /// </summary>
        Disabled = 0,

        /// <summary>
        /// 失敗した時のみ出力する。
        /// </summary>
        OnFailOnly = 1,

        /// <summary>
        /// 常に出力する。
        /// </summary>
        Always = 2
    }

    /// <summary>
    /// OCR読取りリトライモード
    /// </summary>
    [DataContract]
    [Flags]
    public enum ReadRetryMode
    {
        None = 0,             ///< なし</summary>
        Preprocess = 1,       ///< Gaussフィルタ</summary>
        HorizontalRemove = 2, ///< 水平成分減衰フィルタ</summary>
    };

    /// <summary>
    /// 反射色
    /// </summary>
    [DataContract]
    public enum ReflectedColor
    {
        Black = 0, ///< 黒色</summary>
        White = 1, ///< 白色</summary>
        Any = 2,   ///< 自動選択</summary>
    };

    /// <summary>
    /// 領域モード
    /// </summary>
    [DataContract]
    public enum RegionMode
    {
        Normal = 0,
        Arc = 1
    }

    /// <summary>
    /// 認識リトライの方法
    /// </summary>
    [DataContract]
    public enum RetryType
    {
        None = 0,    ///< 実行しない</summary>
        Simple = 1,  ///< 通常実行</summary>
    };

    /// <summary>
    /// 返答ステータス
    /// </summary>
    [DataContract]
    public enum ReturnStatus
    {

        NotExecuted = 0,     ///< 実行せず</summary>
        Success = 1,         ///< 成功</summary>
        Fail = -1,           ///< 失敗</summary>
        AllocatedMemoryError = -2,   ///< メモリ確保エラー</summary>
        NotInitialized = -3,         ///< 未初期化</summary>
    };

    /// <summary>
    /// 非英数字の得点方法
    /// </summary>
    [DataContract]
    public enum ScoreAs100
    {
        Normal = 0,     ///< 標準</summary>
        Include100 = 1, ///< 100 点を付けて得点に含む</summary>
        Exclude100 = 2, ///< 100 点を付けて得点に含まない</summary>
    };

    /// <summary>
    /// スコアモード
    /// </summary>
    [DataContract]
    public enum ScoreMode
    {
        Normal = 0,      ///< すべての文字の平均値で出力</summary>
        MinScore = 1,    ///< すべての文字の最小値で出力</summary>
        MaxMinScore = 2, ///< すべての文字の最大値と最小値の中央を出力</summary>
    };

    /// <summary>
    /// スコア範囲
    /// </summary>
    [DataContract]
    public enum ScoreRange
    {
        /// <summary>
        /// 0から400の範囲。InSight17**互換モード。
        /// </summary>
        Range400 = 0,

        /// <summary>
        /// 0から1000の範囲。
        /// </summary>
        Range1000 = 1, ///< 1000(0~1000）
    };

    /// <summary>
    /// シリアル通信のボーレート
    /// </summary>
    [DataContract]
    public enum SerialBaudrate
    {
        Rate1200 = 1200,  
        Rate2400 = 2400,  
        Rate4800 = 4800,  
        Rate9600 = 9600,  
        Rate14400 = 14400,  
        Rate19200 = 19200,  
        Rate38400 = 38400,  
        Rate57600 = 57600,  
        Rate115200 = 115200,
    };

    /// <summary>
    /// シリアル通信のデータビット
    /// </summary>
    [DataContract]
    public enum SerialDataBits
    {
        Bit5 = 5,
        Bit6 = 6,
        Bit7 = 7,
        Bit8 = 8 
    };

    /// <summary>
    /// シリアル通信のハンドシェイク
    /// </summary>
    [DataContract]
    public enum SerialHandShake
    {
        None = 0,           
        XOnXOff = 1,        
        Req2Send = 2,       
        Req2SendXOnOff = 3  
    };

    /// <summary>
    /// シリアル通信のパリティ
    /// </summary>
    [DataContract]
    public enum SerialParity
    {
        None = 0,   
        Odd = 1,    
        Even = 2,   
        Mark = 3,   
        Space = 4,  
    };

    /// <summary>
    /// シリアル通信のポート
    /// </summary>
    [DataContract]
    public enum SerialPort
    {
        None = 0, 
        Port1 = 1,
        Port2 = 2,
        Port3 = 3,
        Port4 = 4,
        Port5 = 5,
        Port6 = 6,
        Port7 = 7,
        Port8 = 8,
    };

    /// <summary>
    /// シリアル通信ののストップビット
    /// </summary>
    /// <remarks>V440までとはEnumの設定値が異なる</remarks>
    [DataContract]
    public enum SerialStopBits
    {
        None = 0,
        One = 1, 
        Two = 2, 
        OnePointFive = 3, 
    };

    /// <summary>
    /// T7認識モード
    /// </summary>
    [DataContract]
    public enum T7OperationMode
    {
        /// <summary>
        /// 標準
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 拡張
        /// </summary>
        Enhanced = 1,
    };

    /// <summary>
    /// ログレベル   TODO: 削除予定
    /// </summary>   
    [DataContract]
    public enum TraceLogLevel
    {
        INFO = 2, ///< INFO
        WARN = 3, ///< WARN
    };

    /// <summary>
    /// チューニング状態
    /// </summary>
    public enum TuneState
    {
        Waiting,   // 実行待ち
        Running,   // 実行中
        Completed, // 完了承認待ち
        Error      // エラー
    }

    /// <summary>
    /// チューンモード
    /// </summary>
    [DataContract]
    public enum TuneSelectMode
    {
        AverageBest = 0, ///< AverageBest
        MinimumBest = 1, ///< MinimumBest
    };

    /// <summary>
    /// チューンモード
    /// </summary>
    [DataContract]
    public enum TuneScanningMode
    {
        Normal = 0, ///< 通常モード(簡易モード)
        Detail = 1, ///< 詳細モード
    };
}