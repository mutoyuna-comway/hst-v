using Microsoft.Testing.Platform.OutputDevice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Wia.Abstractions;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestWiaSystem
{
    [TestClass]
    public class TestIWiaSystem : AbstractTest
    {
        /// <summary>
        /// 全プロパティの定義チェック用データ
        /// </summary>
        /// <remarks>
        /// DynamicData属性を使用して、一括でプロパティのGetter/Setterやイベント発火をテストするためのテストケース一覧です。
        /// [プロパティ名, テスト用にセットする値, private setかどうか(true=private/false=public)] の形式で定義します。
        /// </remarks>
        public static IEnumerable<object[]> TestIWiaSystemData
        {
            get
            {
                IWiaSystem iWiaSystem = WiaService;

                // インターフェイス上 {get;} のものは isPrivate=true として扱います
                // インターフェイス上 {get; set;} のものは isPrivate=false として扱います

                // オブジェクト系プロパティのテストケース
                // 初期値のシャローコピーを渡すことで、参照が変わった（セットされた）ことを検知できるようにしています。
                yield return new object[] { nameof(IWiaSystem.Job), ShallowCopy(iWiaSystem.Job), true };
                yield return new object[] { nameof(IWiaSystem.LatestAcquireResult), ShallowCopy(iWiaSystem.LatestAcquireResult), true };
                yield return new object[] { nameof(IWiaSystem.LatestAcquiredImage), ShallowCopy(iWiaSystem.LatestAcquiredImage), true };


                // 値・文字列系プロパティのテストケース
                yield return new object[] { nameof(IWiaSystem.IsOnline), true, true };
                yield return new object[] { nameof(IWiaSystem.IsScreenLocked), true, false };
                yield return new object[] { nameof(IWiaSystem.IsAcquireDisabled), true, false };
                yield return new object[] { nameof(IWiaSystem.ActiveJobName), "test", true };
                yield return new object[] { nameof(IWiaSystem.ActiveJobLoadTime), default(DateTime), true };
                yield return new object[] { nameof(IWiaSystem.IsLiveViewActive), true, true };
                yield return new object[] { nameof(IWiaSystem.IsTuning), true, true };
                yield return new object[] { nameof(IWiaSystem.TuneCurrentState), TuneState.Waiting, true };
                yield return new object[] { nameof(IWiaSystem.TuneCurrentSeqNumber), 0, true };
                yield return new object[] { nameof(IWiaSystem.TuneCurrentConfigNumber), 0, true };
            }
        }

        /// <summary>
        /// プロパティのテスト
        /// </summary>
        /// <remarks>
        /// TestIWiaSystemDataで定義されたすべてのプロパティに対して、値のセット、取得、及び
        /// PropertyChangedイベントが正しく発火するかをAbstractTestの共通メソッドを利用して網羅的に検証します。
        /// </remarks>
        /// <param name="name">テスト対象のプロパティ名</param>
        /// <param name="value">プロパティにセットするテスト値</param>
        /// <param name="isPrivate">private set（リフレクション経由でのセットが必要か）かどうかのフラグ</param>
        [TestMethod]
        [DynamicData(nameof(TestIWiaSystemData))]
        public void IWiaSystemPropertyTest(string name, object value, bool isPrivate)
        {
            // プロパティの取得確認（AbstractTestの実装利用を想定）
            IWiaSystem iWiaSystem = WiaService;
            this.PropertyTest(iWiaSystem, name, value, isPrivate);
        }

        /// <summary>
        /// ReadOnlyのプロパティのテスト 値が変更されることのないプロパティのテスト
        /// </summary>
        /// <remarks>
        /// インターフェース上で { get; } のみ定義されており、実行中にインスタンスが不変（初期化時にのみ生成される）
        /// であるべきプロパティが、正しく初期化されてnullでないことを確認します。
        /// </remarks>
        [TestMethod]
        public void IWiaSystemReadOnlyPropertyTest()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 各種設定やサービスインスタンスが正しく生成されているか（nullでないか）を検証
            Assert.IsNotNull(iWiaSystem.AcquisitionSettings, nameof(IWiaSystem.AcquisitionSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.SystemSettings, nameof(IWiaSystem.SystemSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.GUISettings, nameof(IWiaSystem.GUISettings) + " is null");
            Assert.IsNotNull(iWiaSystem.CommunicationSettings, nameof(IWiaSystem.CommunicationSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.ReadSettings, nameof(IWiaSystem.ReadSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.LogSettings, nameof(IWiaSystem.LogSettings) + " is null");
            Assert.IsNotNull(iWiaSystem.Device, nameof(IWiaSystem.Device) + " is null");
            Assert.IsNotNull(iWiaSystem.ImageSource, nameof(IWiaSystem.ImageSource) + " is null");
            Assert.IsNotNull(iWiaSystem.MaintenanceServices, nameof(IWiaSystem.MaintenanceServices) + " is null");
            Assert.IsNotNull(iWiaSystem.IdReadingService, nameof(IWiaSystem.IdReadingService) + " is null");
            Assert.IsNotNull(iWiaSystem.TuningService, nameof(IWiaSystem.TuningService) + " is null");

            // 値型のReadOnlyプロパティの検証
            // バージョン情報が期待値（実行環境のパラメータ）と一致しているか
            Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem)+ "." + nameof(IWiaSystem.AppVersion)), iWiaSystem.AppVersion);
            // 起動時刻が現在時刻よりも前（過去）に設定されているかを確認
            Assert.IsLessThanOrEqualTo(DateTime.Now, iWiaSystem.BootTime, "boot time is not before current time");
        }

        // =========================================================
        // 各メソッドのテスト (1関数につき1テストメソッド)
        // =========================================================

        /// <summary>
        /// ApplicationExitのテスト
        /// </summary>
        /// <remarks>
        /// 指定時間経過後にアプリケーション終了要求イベントが発火する、非同期的な振る舞いを検証します。
        /// </remarks>
        [TestMethod]
        public async Task TestApplicationExit()
        {
            IWiaSystem iWiaSystem = WiaService;
            // 【準備】イベント発火検知用のフラグ
            bool eventFired = false;

            // イベント購読：発火したらフラグをtrueにする
            EventHandler handler = (s, e) => { eventFired = true; };
            
            try
            {

                iWiaSystem.CloseApplicationRequested += handler;
                // 【実行】1000ms（1秒）後に終了するように要求
                iWiaSystem.ApplicationExit(1000);

                // 500ms待機してチェック
                await TestUtils.Delaymsec(500);
                Assert.IsFalse(eventFired, "CloseApplicationRequested event is fired before 1000ms");

                // さらに1000ms待機（合計1500ms）してチェック
                await TestUtils.Delaymsec(1000);
                Assert.IsTrue(eventFired, "CloseApplicationRequested event is not fired after 1000ms");
            }
            finally
            {
                iWiaSystem.CloseApplicationRequested -= handler; // 購読解除
            }
        }

        /// <summary>
        /// GetJobFolderのテスト
        /// </summary>
        [TestMethod]
        public void TestGetJobFolder()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【実行】対象メソッドの呼び出し
            string folder = iWiaSystem.GetJobFolder();

            // 【検証】空文字やnullが返ってこないこと
            Assert.IsFalse(string.IsNullOrEmpty(folder), "GetJobFolder is fail: returned null or empty");
            // 【検証】実行環境（runsettingsなど）の期待値と一致すること
            Assert.AreEqual(ParameterManager.getJobFolder(), folder, "GetJobFolder path is incorrect");
        }

        /// <summary>
        /// GetDeviceFolderのテスト
        /// </summary>
        [TestMethod]
        public void TestGetDeviceFolder()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【実行】対象メソッドの呼び出し
            string folder = iWiaSystem.GetDeviceFolder();

            // 【検証】空文字やnullが返ってこないこと
            Assert.IsFalse(string.IsNullOrEmpty(folder), "GetDeviceFolder is fail: returned null or empty");
            // 【検証】実行環境の期待値と一致すること
            Assert.AreEqual(ParameterManager.getDeviceFolder(), folder, "GetJobFolder path is incorrect");
        }

        /// <summary>
        /// WriteCommandLogExceptionのテスト
        /// </summary>
        /// <remarks>
        /// ログファイルが実際にディスクに書き出されることと、不正な引数を与えた際の例外スローを検証します。
        /// テストで作成されたログファイルは、他のテスト環境を汚さないように最後にクリーンアップします。
        /// </remarks>
        [TestMethod]
        public void TestWriteCommandLogException()
        {
            IWiaSystem iWiaSystem = WiaService;
            DateTime now = DateTime.Now;

            // 出力されるはずのファイル名をシミュレート（IWiaSystemの実装に合わせたファイル名）
            string format = "yyyy.MM.dd_hh.mm.ss";
            string dateString = "Seq_" + now.ToString(format) + ".000.log";
            string format2 = "yyyyMMdd_hh";
            string dateString2 = "AssertionLog_" + now.ToString(format2) + ".log";

            try
            {
                // 【実行：正常系】例外オブジェクトとメッセージを渡してログ出力を実行
                iWiaSystem.WriteCommandLogException(new Exception("Test Exception"), "Test Message");

                // 【検証：正常系】期待されるファイルパスにログファイルが実際に作成されたかを確認
                Assert.IsTrue(File.Exists(ParameterManager.getDeviceFolder() + "/log/" + dateString));
                Assert.IsTrue(File.Exists(ParameterManager.getDeviceFolder() + "/log/" + dateString2));
            }
            catch (Exception ex)
            {
                // 例外出力処理が発生していないかの確認
                Assert.Fail($"WriteCommandLogException is fail: {ex.Message}");
            }
            finally
            {
                // 【後始末】テスト中に作成された不要なログファイルを削除。基準時刻(now)以降に作られたものを対象とする。
                CleanupFromBaseTime(now, ParameterManager.getDeviceFolder() + "/Log");
            }

            // 【検証：異常系】引数の例外オブジェクトがnull、かつメッセージが空文字の場合はArgumentExceptionが発生すること
            ExceptionTest<ArgumentException>(() => iWiaSystem.WriteCommandLogException(null, ""));
        }

        /// <summary>
        /// SetScreenVisibilityのテスト
        /// </summary>
        /// <remarks>
        /// 画面表示変更メソッドを呼んだ際に、正しい引数を持ったイベントが発火するかを検証します。
        /// </remarks>
        [TestMethod]
        public void TestSetScreenVisibility()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】イベント発火確認用フラグ
            bool eventFired = false;

            // イベントを購読し、発火した際に引数(e)の中身がメソッドの入力値と一致するかアサートする
            EventHandler<IScreenVisibilityChangeEventArgs> handler = (s, e) => {
                eventFired = true;
                Assert.IsTrue(e.IsVisible, $"{nameof(e.IsVisible)} is incorrect in event args");
                Assert.AreEqual(50, e.LocationX, $"{nameof(e.LocationX)} is incorrect in event args");
                Assert.AreEqual(100, e.LocationY, $"{nameof(e.LocationY)} is incorrect in event args");
            };
            try
            {
                iWiaSystem.ScreenVisibilityChangeRequested += handler;

                // 【実行】表示をONにし、座標(50, 100)を指定
                iWiaSystem.SetScreenVisibility(true, 50, 100);

                // 【検証】イベントが確実に1回以上発火したか
                Assert.IsTrue(eventFired, "ScreenVisibilityChangeRequested event is not fired");
            }
            finally {
                iWiaSystem.ScreenVisibilityChangeRequested -= handler;
            }
            
        }

        /// <summary>
        /// CreateNewJobのテスト
        /// </summary>
        /// <remarks>
        /// 新規ジョブ作成時に、変更前・変更後のイベントが正しい順序で発火し、
        /// プロパティ（ジョブ名やロード時刻）が適切に初期化されるかを検証します。
        /// jobがnullの時も同様の結果になることを確認
        /// </remarks>
        [TestMethod]
        // [DataRow(true)] TODO Nullパターンはいったん行わない
        [DataRow(false)]
        public void TestCreateNewJob(Boolean isJobNull)
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】状態確認用の初期値とフラグを変数に保持
            DateTime time = DateTime.Now;
            bool propertyEventFired = false;
            bool eventFired1 = false;
            bool eventFired2 = false;
            string beforeJobName = iWiaSystem.ActiveJobName;
            IJob beforeJob = iWiaSystem.Job;

            // ジョブ変更「中」のイベントハンドラ：この時点ではまだプロパティは更新されていないはず
            EventHandler JobChangingHandler = (s, e) => {
                eventFired1 = true;
                Assert.AreEqual(beforeJobName, iWiaSystem.ActiveJobName, $"{nameof(IWiaSystem.ActiveJobName)} is changed in Chengging event");
                Assert.AreEqual(beforeJob, iWiaSystem.Job, $"{nameof(IWiaSystem.Job)} is changed in Chengging event");
            };

            // ジョブ変更「完了」のイベントハンドラ：この時点ではプロパティが新しいものに更新されているはず
            EventHandler JobChangedHandler = (s, e) => {
                eventFired2 = true;
                Assert.AreNotEqual(beforeJobName, iWiaSystem.ActiveJobName, $"{nameof(IWiaSystem.ActiveJobName)} is changed in Chengging event");
                Assert.AreNotEqual(beforeJob, iWiaSystem.Job, $"{nameof(IWiaSystem.Job)} is changed in Chengging event");
            };

            
            PropertyChangedEventHandler handler = getPropertyChangeHandler(nameof(iWiaSystem.ActiveJobName), () => { propertyEventFired = true; });

            try
            {
                iWiaSystem.JobChanging += JobChangingHandler;
                iWiaSystem.JobChanged += JobChangedHandler;
                iWiaSystem.PropertyChanged += handler;
                // 【実行と検証】メソッドがtrue(成功)を返すか
                Assert.IsTrue(iWiaSystem.CreateNewJob(), "CreateNewJob is fail");

                // 【検証】ジョブロード時間がテスト開始時の時刻よりも後（更新された）であること
                Assert.IsGreaterThanOrEqualTo(time, iWiaSystem.ActiveJobLoadTime, $"{nameof(IWiaSystem.ActiveJobLoadTime)} is not updated");

                // 【検証】アクティブなジョブ名が、環境依存の新規ジョブ名（例: 無題.job）になっていること
                Assert.AreEqual(ParameterManager.getParam<string>(nameof(IWiaSystem) + ".Untitled"), iWiaSystem.ActiveJobName, $"{nameof(IWiaSystem.ActiveJobName)} is not updated to NewJob");

                // 【検証】事前/事後イベントが両方とも発火したか
                Assert.IsTrue(eventFired1, "JobChanging event is not fired");
                Assert.IsTrue(eventFired2, "JobChanged event is not fired");
                Assert.IsTrue(propertyEventFired, "propertyEventFired is not fired");

            }
            finally {
                // 【後始末】ハンドラの解除（他のテストへの影響を防ぐため）
                iWiaSystem.JobChanging -= JobChangingHandler;
                iWiaSystem.JobChanged -= JobChangedHandler;
                iWiaSystem.PropertyChanged -= handler;
            }
            

            
            
        }

        /// <summary>
        /// LoadJobFileのテスト
        /// </summary>
        /// <remarks>
        /// 既存のジョブファイルを読み込んだ際の振る舞いを検証します。
        /// テスト用にダミーのファイルを作成して読み込ませ、イベントと状態更新を確認します。
        /// </remarks>
        [TestMethod]
        public void TestLoadJobFile()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】テスト用の一時ファイルパスを生成
            DateTime time = DateTime.Now;
            bool eventFired1 = false;
            bool eventFired2 = false;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".job";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            // 実ファイルが存在しないとLoadが失敗するため、事前にSaveを呼んで空のダミーファイルを作る
            iWiaSystem.SaveJobFile(testPath);

            // ロードによって状態が「変わった」ことを検証するため、一旦新規作成状態にしておく
            iWiaSystem.CreateNewJob();
            string beforeJobName = iWiaSystem.ActiveJobName;
            IJob beforeJob = iWiaSystem.Job;

            EventHandler JobChangingHandler = (s, e) => {
                eventFired1 = true; //ジョブ変更中イベント
                Assert.AreEqual(beforeJobName, iWiaSystem.ActiveJobName, $"{nameof(IWiaSystem.ActiveJobName)} is changed in Chengging event");
                Assert.AreEqual(beforeJob, iWiaSystem.Job, $"{nameof(IWiaSystem.Job)} is changed in Chengging event");
            };
            EventHandler JobChangedHandler = (s, e) => {
                eventFired2 = true; //ジョブ変更完了イベント
                Assert.AreNotEqual(beforeJobName, iWiaSystem.ActiveJobName, $"{nameof(IWiaSystem.ActiveJobName)} is changed in Chengging event");
                Assert.AreNotEqual(beforeJob, iWiaSystem.Job, $"{nameof(IWiaSystem.Job)} is changed in Chengging event");
            };

            try
            {
                iWiaSystem.JobChanging += JobChangingHandler;
                iWiaSystem.JobChanged += JobChangedHandler;

                // 【実行：正常系】ダミーファイルを読み込む
                Assert.IsTrue(iWiaSystem.LoadJobFile(testPath), "LoadJobFile is fail");

                // 【検証】ロード時間が更新されているか
                Assert.IsGreaterThanOrEqualTo(time, iWiaSystem.ActiveJobLoadTime, $"{nameof(IWiaSystem.ActiveJobLoadTime)} is not updated");

                // 【検証】ActiveJobNameには、ディレクトリパスが取り除かれた「ファイル名のみ」がセットされる仕様かを確認
                Assert.AreEqual(System.IO.Path.GetFileName(testPath), iWiaSystem.ActiveJobName, $"{nameof(IWiaSystem.ActiveJobName)} is not updated correctly");

                // 【検証】イベントが発火したか
                Assert.IsTrue(eventFired1, "JobChanging event is not fired");
                Assert.IsTrue(eventFired2, "JobChanged event is not fired");
            }
            finally
            {
                // 【後始末】ダミーファイルを削除し、イベント購読を解除
                System.IO.File.Delete(testPath);
                iWiaSystem.JobChanging -= JobChangingHandler;
                iWiaSystem.JobChanged -= JobChangedHandler;
            }

            // 【検証：異常系】空文字や存在しないファイルパスを渡した場合はfalseが返るか
            Assert.IsFalse(iWiaSystem.LoadJobFile(""), "LoadJobFile is not fail");
            Assert.IsFalse(iWiaSystem.LoadJobFile(testPath + "fail"), "LoadJobFile unknown path is not failed");
        }


        

        /// <summary>
        /// SaveJobFileのテスト
        /// </summary>
        /// <remarks>
        /// 新規の名前を指定してジョブを保存する際の振る舞いと、状態変更の通知（PropertyChanged）を検証します。
        /// </remarks>
        [TestMethod]
        public void TestSaveJobFile()
        {
            IWiaSystem iWiaSystem = WiaService;
            DateTime time = DateTime.Now;

            // 【準備】保存先の一時ファイルパスを生成
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".job";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            bool isEventRaised = false;

            // プロパティ変更イベントで ActiveJobName が更新されたことを検知するハンドラ
            
            PropertyChangedEventHandler handler = getPropertyChangeHandler(nameof(IWiaSystem.ActiveJobName), () => { isEventRaised = true; });

            try
            {
                iWiaSystem.PropertyChanged += handler;

                // 【実行：正常系】指定パスへの保存
                Assert.IsTrue(iWiaSystem.SaveJobFile(testPath), "SaveJobFile is fail");

                // 【検証】アクティブなジョブ名が、保存したファイル名（パス無し）に更新されているか
                Assert.IsTrue(System.IO.File.Exists(testPath), "SaveJobFile is not exists");

                // 【検証】アクティブなジョブ名が、保存したファイル名（パス無し）に更新されているか
                Assert.AreEqual(System.IO.Path.GetFileName(testPath), iWiaSystem.ActiveJobName, "ActiveJobName is not updated correctly");

                // 【検証】保存日時（ロード日時扱い）が更新されているか
                Assert.IsGreaterThanOrEqualTo(time, iWiaSystem.ActiveJobLoadTime, $"{nameof(IWiaSystem.ActiveJobLoadTime)} is not updated");

                // 【検証】プロパティ変更通知イベントが正しく発火したか
                Assert.IsTrue(isEventRaised, "ActiveJobLoadTime property event not fired");
            }
            finally
            {
                // 【後始末】イベント購読解除と一時ファイルの削除
                iWiaSystem.PropertyChanged -= handler;
                System.IO.File.Delete(testPath);
            }

            // 【検証：異常系】パスが空文字、または存在しない無効なディレクトリを指定した場合は失敗(false)するか
            Assert.IsFalse(iWiaSystem.SaveJobFile(""), "LoadJobFile is not fail");
            Assert.IsFalse(iWiaSystem.SaveJobFile(@"C:\存在しないフォルダ/test.job"), "LoadJobFile is not fail unknown folder");
        }

        /// <summary>
        /// SaveJobOverwriteのテスト
        /// </summary>
        /// <remarks>
        /// 上書き保存機能の検証です。
        /// 無題のジョブでは失敗し、名前付きの既存ジョブでは成功することを確かめます。
        /// </remarks>
        [TestMethod]
        public void TestSaveJobOverwrite()
        {
            IWiaSystem iWiaSystem = WiaService;
            bool isEventRaised = false;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".job";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(IWiaSystem.ActiveJobName))
                {
                    isEventRaised = true;
                }
            }

            try
            {
                // 【準備】上書き保存が可能なように、ダミーのファイル名で一度名前を付けて保存しておく
                iWiaSystem.SaveJobFile(testPath);
                iWiaSystem.PropertyChanged += Handler;

                // 【実行：正常系】上書き保存
                Assert.IsTrue(iWiaSystem.SaveJobOverwrite(), "SaveJobOverwrite is fail");

                // 【検証】上書き保存であっても、保存をトリガーとして画面表示等の更新用にプロパティ変更通知が飛ぶか
                Assert.IsTrue(isEventRaised, "PropertyChanged event for ActiveJobName is not fired");
            }
            finally
            {
                // 【後始末】
                iWiaSystem.PropertyChanged -= Handler;
                System.IO.File.Delete(testPath);
            }

            // 【検証：異常系】ファイル名が定まっていない新規作成直後（無題のジョブ）の上書き保存は失敗(false)するか
            iWiaSystem.CreateNewJob(); // アクティブジョブ名を「無題.job」にする
            Assert.IsFalse(iWiaSystem.SaveJobOverwrite(), "SaveJobOverwrite is not fail");
        }

        /// <summary>
        /// LoadBitmapFileのテスト
        /// </summary>
        /// <remarks>
        /// 画像ファイル読み込み機能の検証です。
        /// 実際にBMPファイルを作成して読み込ませ、画像取り込みが無効化(IsAcquireDisabled)されるか確認します。
        /// </remarks>
        [TestMethod]
        public void TestLoadBitmapFile()
        {
            IWiaSystem iWiaSystem = WiaService;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + dateString;

            // 【準備】イベント発火確認用フラグ
            bool acquireAvailableFired = false;
            EventHandler handler = (s, e) => acquireAvailableFired = true;

            try
            {
                iWiaSystem.IsAcquireDisabled = false;//初期化しておく
                // テスト用の黒塗りBMP画像を生成してディスクに保存
                TestUtils.CreateBlackBmp(testPath);

                iWiaSystem.AcquireImageAvailable += handler;

                // 【実行：正常系】BMPの読み込み
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");

                // 【検証】ファイル読み込みモードに移行したため、カメラからの画像取込は無効(true)になるはず
                Assert.IsTrue(iWiaSystem.IsAcquireDisabled, $"{nameof(IWiaSystem.IsAcquireDisabled)} is not true after loading bitmap");

                // 【検証】画像が利用可能になったことを通知するイベントが発火したか
                Assert.IsTrue(acquireAvailableFired, "AcquireImageAvailable event is not fired");
            }
            finally
            {
                // 【後始末】
                System.IO.File.Delete(testPath);
                iWiaSystem.AcquireImageAvailable -= handler;
                iWiaSystem.IsAcquireDisabled = false;
            }

            // 【検証：異常系】無効なパスや存在しないファイルの場合は失敗するか
            Assert.IsFalse(iWiaSystem.LoadBitmapFile(""), "LoadBitmapFile is not fail"); 
            Assert.IsFalse(iWiaSystem.LoadBitmapFile(@"C:\存在しないフォルダ/test.job"), "LoadBitmapFile is not fail unknown folder");
        }

        /// <summary>
        /// GoOnlineのテスト
        /// </summary>
        /// <remarks>
        /// オンラインモードへの切り替えと、そのプロパティ変更通知を検証します。
        /// </remarks>
        [TestMethod]
        public void TestGoOnline()
        {
            IWiaSystem iWiaSystem = WiaService;
            bool isEventRaised = false;
            PropertyChangedEventHandler handler = getPropertyChangeHandler(nameof(IWiaSystem.IsOnline), () => { isEventRaised = true; });

            if (iWiaSystem.IsOnline) {
                iWiaSystem.GoOffline(); //オンラインの時はオフラインにしておく
            }
                
            try
            {
                // 【準備】イベントを購読
                iWiaSystem.PropertyChanged += handler;

                // 【実行】オンラインに移行
                iWiaSystem.GoOnline();
            }
            finally
            {
                // 【後始末】イベント購読解除
                iWiaSystem.PropertyChanged -= handler;
            }

            // 【検証】イベントの発火と、プロパティがtrueになったかを確認
            Assert.IsTrue(isEventRaised, "isEventRaised is false");
            Assert.IsTrue(iWiaSystem.IsOnline, "GoOnline is fail: IsOnline is false");
        }

        /// <summary>
        /// GoOfflineのテスト
        /// </summary>
        /// <remarks>
        /// オフラインモードへの切り替えと、そのプロパティ変更通知を検証します。
        /// </remarks>
        [TestMethod]
        public void TestGoOffline()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】テストの前提として、確実にオンライン状態から始める
            
            if (!iWiaSystem.IsOnline)
            {
                iWiaSystem.GoOnline(); //オフラインの時はオンラインにしておく
            }
            Assert.IsTrue(iWiaSystem.IsOnline, "GoOnline is fail: IsOnline is false");

            bool isEventRaised = false;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(IWiaSystem.IsOnline))
                {
                    isEventRaised = true;
                }
            }

            try
            {
                iWiaSystem.PropertyChanged += Handler;

                // 【実行】オフラインに移行
                iWiaSystem.GoOffline();
            }
            finally
            {
                // 【後始末】
                iWiaSystem.PropertyChanged -= Handler;
            }

            // 【検証】イベント発火と、プロパティがfalseになったかを確認
            Assert.IsTrue(isEventRaised, "isEventRaised is false");
            Assert.IsFalse(iWiaSystem.IsOnline, "GoOffline is fail: IsOnline is true");
        }

        /// <summary>
        /// GetStatsResultsCountのテスト
        /// </summary>
        [TestMethod]
        public void TestGetStatsResultsCount()
        {
            IWiaSystem iWiaSystem = WiaService;

            iWiaSystem.AllStatsClear();//とりあえず一度クリア
            iWiaSystem.Job.RunRead();
            // 【実行】統計情報の総数を取得
            int count = iWiaSystem.GetStatsResultsCount();

            // 【検証】0以上の数値が返ってくること（マイナスなど異常な値でないこと）
            Assert.IsGreaterThanOrEqualTo(0, count, "GetStatsResultsCount is fail: count is incorrect");
        }

        /// <summary>
        /// GetStatsResultsPassNumのテスト
        /// </summary>
        /// <remarks>
        /// コンフィグ番号を指定した読取成功数の取得を検証します。
        /// 境界値（無効なコンフィグID）に対する例外処理も確認します。
        /// </remarks>
        [TestMethod]
        public void TestGetStatsResultsPassNum()
        {
            IWiaSystem iWiaSystem = WiaService;

            iWiaSystem.AllStatsClear();//とりあえず一度クリア
            // 【準備】読取り処理(RunRead)を実行するためにダミー画像を読み込ませる
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            try
            {
                TestUtils.CreateBlackBmp(testPath);
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");

                // 正常系テストのため、一度読取り処理を実行させて内部の統計情報カウンタを動かす
                iWiaSystem.Job.RunRead();

                int validId = 1; // 正常なコンフィグID

                // 【検証：正常系】0以上の数値が返ってくること
                Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetStatsResultsPassNum(validId), "GetStatsResultsPassNum is fail for valid ID");
            }
            finally
            {
                // 【後始末】
                System.IO.File.Delete(testPath);
            }

            // 【検証：異常系】最大数を超えるコンフィグID、またはマイナスのIDを指定した際に ArgumentOutOfRangeException が発生するか
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsPassNum(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsPassNum(-1));
        }

        /// <summary>
        /// GetStatsResultsFailNumのテスト
        /// </summary>
        /// <remarks>
        /// コンフィグ番号を指定した読取失敗数の取得と、読取操作による値の変動を検証します。
        /// </remarks>
        [TestMethod]
        public void TestGetStatsResultsFailNum()
        {
            IWiaSystem iWiaSystem = WiaService;
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            int validId = 1;

            iWiaSystem.AllStatsClear();//とりあえず一度クリア
            // 【準備】読取実行「前」の失敗数を取得しておく
            int before = iWiaSystem.GetStatsResultsFailNum(validId);

            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            try
            {
                // ダミー画像をセット
                TestUtils.CreateBlackBmp(testPath);
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");

                // 【実行】読取り処理を実行（黒画像のため読取失敗としてカウントされることを期待）
                iWiaSystem.Job.RunRead();

                // 【検証：正常系】読取り実行前よりも失敗数が増加している（beforeより大きい）こと
                Assert.IsGreaterThan(before, iWiaSystem.GetStatsResultsFailNum(validId), "GetStatsResultsFailNum is fail for valid ID");
            }
            finally
            {
                System.IO.File.Delete(testPath);
            }

            // 【検証：異常系】範囲外のID指定時の例外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsFailNum(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsFailNum(-1));
        }

        /// <summary>
        /// GetStatsResultsAvgScoreのテスト
        /// </summary>
        /// <remarks>
        /// コンフィグ番号を指定した平均スコアの取得を検証します。
        /// </remarks>
        [TestMethod]
        public void TestGetStatsResultsAvgScore()
        {
            IWiaSystem iWiaSystem = WiaService;

            iWiaSystem.AllStatsClear();//とりあえず一度クリア
            // 【準備】ダミー画像をセットし読取りを実行
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            try
            {
                TestUtils.CreateBlackBmp(testPath);
                Assert.IsTrue(iWiaSystem.LoadBitmapFile(testPath), "LoadBitmapFile is fail");

                iWiaSystem.Job.RunRead(); // 統計情報を更新させる

                int validId = 1;

                // 【検証：正常系】平均スコアが0.0以上であること
                Assert.IsGreaterThanOrEqualTo(0.0, iWiaSystem.GetStatsResultsAvgScore(validId), "GetStatsResultsAvgScore is fail for valid ID");
            }
            finally
            {
                System.IO.File.Delete(testPath);
            }

            // 【検証：異常系】範囲外のID指定時の例外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsAvgScore(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetStatsResultsAvgScore(-1));
        }

        /// <summary>
        /// GetConfigNumPassedのテスト
        /// </summary>
        /// <remarks>
        /// ジョブ名とコンフィグ番号の両方を指定して成功数を取得するメソッドの検証です。
        /// outパラメータへの結果の格納と、ジョブ名指定なし（空文字）の動作を含みます。
        /// </remarks>
        [TestMethod]
        public void TestGetConfigNumPassed()
        {
            IWiaSystem iWiaSystem = WiaService;
            string jobName = "Test.wia";

            // 【実行・検証：正常系】特定のジョブ名を指定した場合
            Assert.IsTrue(iWiaSystem.GetConfigNumPassed(1, jobName, out int num), "GetConfigNumPassed is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num, "GetConfigNumPassed returned incorrect out parameter");

            // 【実行・検証：正常系】ジョブ名を空文字にして全体（全てのジョブ）を対象にした場合
            Assert.IsTrue(iWiaSystem.GetConfigNumPassed(1, "", out int num2), "GetConfigNumPassed is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num2, "all GetConfigNumPassed returned incorrect out parameter");

            // 【検証：異常系】範囲外のID指定時の例外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumPassed(invalidId, jobName, out _));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumPassed(-1, jobName, out _));
        }

        /// <summary>
        /// GetConfigNumFailedのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfigNumFailed()
        {
            IWiaSystem iWiaSystem = WiaService;
            string jobName = "Test.wia";

            // 【実行・検証：正常系】特定のジョブ名を指定した場合
            Assert.IsTrue(iWiaSystem.GetConfigNumFailed(1, jobName, out int num), "GetConfigNumFailed is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num, "GetConfigNumFailed returned incorrect out parameter");

            // 【実行・検証：正常系】ジョブ名を空文字にして全体を対象にした場合
            Assert.IsTrue(iWiaSystem.GetConfigNumFailed(1, "", out int num2), "GetConfigNumFailed is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num2, "all GetConfigNumFailed returned incorrect out parameter");

            // 【検証：異常系】範囲外のID指定時の例外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumFailed(invalidId, jobName, out _));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigNumFailed(-1, jobName, out _));
        }

        /// <summary>
        /// GetConfigAvgScoreのテスト
        /// </summary>
        [TestMethod]
        public void TestGetConfigAvgScore()
        {
            IWiaSystem iWiaSystem = WiaService;
            string jobName = "Test.wia";

            // 【実行・検証：正常系】特定のジョブ名を指定した場合
            Assert.IsTrue(iWiaSystem.GetConfigAvgScore(1, jobName, out int score), "GetConfigAvgScore is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, score, "GetConfigAvgScore returned incorrect out parameter");

            // 【実行・検証：正常系】ジョブ名を空文字にして全体を対象にした場合
            Assert.IsTrue(iWiaSystem.GetConfigAvgScore(1, "", out int num2), "GetConfigAvgScore is fail for valid ID");
            Assert.IsGreaterThanOrEqualTo(0, num2, "all GetConfigAvgScore returned incorrect out parameter");

            // 【検証：異常系】範囲外のID指定時の例外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigAvgScore(invalidId, jobName, out _));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetConfigAvgScore(-1, jobName, out _));
        }

        /// <summary>
        /// FindJobFilePathのテスト
        /// </summary>
        /// <remarks>
        /// ※現状はTBD（To Be Defined）となっており、テスト未実装のためIgnoreとしています。
        /// 将来的には、ジョブ名からフルパスが正しく逆引きできるかを確認します。
        /// </remarks>
        [TestMethod]
        [Ignore]
        public void TestFindJobFilePath()
        {
            // TODO TEST＿TBD
        }

        /// <summary>
        /// GetAllNumPassedのテスト
        /// </summary>
        [TestMethod]
        public void TestGetAllNumPassed()
        {
            IWiaSystem iWiaSystem = WiaService;

            iWiaSystem.Job.RunRead(); //とりあえず統計情報を更新させる
            // 【実行・検証：正常系】
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllNumPassed(1), "GetAllNumPassed is fail for valid ID");

            // 【検証：異常系】コンフィグID範囲外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumPassed(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumPassed(-1));
        }

        /// <summary>
        /// GetAllNumFailedのテスト
        /// </summary>
        [TestMethod]
        public void TestGetAllNumFailed()
        {
            IWiaSystem iWiaSystem = WiaService;

            iWiaSystem.Job.RunRead(); //とりあえず統計情報を更新させる
            // 【実行・検証：正常系】
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllNumFailed(1), "GetAllNumFailed is fail for valid ID");

            // 【検証：異常系】コンフィグID範囲外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumFailed(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllNumFailed(-1));
        }

        /// <summary>
        /// GetAllAverageScoreのテスト
        /// </summary>
        [TestMethod]
        public void TestGetAllAverageScore()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【実行・検証：正常系】
            Assert.IsGreaterThanOrEqualTo(0, iWiaSystem.GetAllAverageScore(1), "GetAllAverageScore is fail for valid ID");

            // 【検証：異常系】コンフィグID範囲外チェック
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllAverageScore(invalidId));
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.GetAllAverageScore(-1));
        }

        /// <summary>
        /// AllStatsClearのテスト
        /// </summary>
        /// <remarks>
        /// 統計情報クリアメソッドを呼び出し、内部で例外がクラッシュしないかを検証します。
        /// （スタブでは空実装ですが、呼び出しインターフェースの疎通確認を兼ねています）
        /// </remarks>
        [TestMethod]
        public void TestAllStatsClear()
        {
            IWiaSystem iWiaSystem = WiaService;

            try
            {
                // 【実行】
                iWiaSystem.AllStatsClear();
            }
            catch (Exception ex)
            {
                // 【検証】例外がスローされないこと
                Assert.Fail($"AllStatsClear is fail: {ex.Message}");
            }
        }

        /// <summary>
        /// CreateRecogCondのテスト
        /// </summary>
        [TestMethod]
        public void TestCreateRecogCond()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【実行】認識条件オブジェクトの生成
            var cond = iWiaSystem.CreateRecogCond();

            // 【検証】生成されたオブジェクトがnullでないこと
            Assert.IsNotNull(cond, "CreateRecogCond is fail: returned null");
        }

        /// <summary>
        /// GetCamInfoのテスト
        /// </summary>
        [TestMethod]
        public void TestGetCamInfo()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【実行】カメラ情報の取得
            var info = iWiaSystem.GetCamInfo();

            // 【検証】取得された情報がnullでないこと
            Assert.IsNotNull(info, "GetCamInfo is fail: returned null");
        }

        /// <summary>
        /// StartLiveViewのテスト
        /// </summary>
        /// <remarks>
        /// ライブビュー（カメラの連続画像取得）開始時の状態遷移と、関連するイベントの発火を検証します。
        /// 既に開始済みの状態でもう一度開始した際のエラーハンドリング（ImageAcquisitionFailed）も確認します。
        /// </remarks>
        [TestMethod]
        public async Task TestStartLiveView()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】イベント検知フラグ
            bool startedFired = false;
            bool acquireAvailableFired = false;
            bool acquisitionFailed = false;

            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            // カメラ取込をシミュレートするため、ダミー画像をロードしておく
            TestUtils.CreateBlackBmp(testPath);
            iWiaSystem.LoadBitmapFile(testPath);

            // イベント購読
            EventHandler LiveViewStartedHandler = (s, e) => startedFired = true;
            EventHandler AcquireImageAvailableHandler = (s, e) => acquireAvailableFired = true;
            EventHandler ImageAcquisitionFailedHandler = (s, e) => acquisitionFailed = true;
            try
            {
                iWiaSystem.StopLiveView();
                iWiaSystem.LiveViewStarted += LiveViewStartedHandler;
                iWiaSystem.AcquireImageAvailable += AcquireImageAvailableHandler;
                iWiaSystem.ImageAcquisitionFailed += ImageAcquisitionFailedHandler;

                // 【実行：正常系】ライブビュー開始
                iWiaSystem.StartLiveView();

                // 【検証】プロパティがライブ中(true)になっていること
                Assert.IsTrue(iWiaSystem.IsLiveViewActive, "StartLiveView is fail: IsLiveViewActive is not true");

                // 【検証】開始イベントと、取込完了イベント（1回目の画像取得）が発火したこと
                Assert.IsTrue(startedFired, "LiveViewStarted event is not fired");
                Assert.IsTrue(acquireAvailableFired, "AcquireImageAvailable event is not fired at start");

                // 【検証】正常開始なので、失敗イベントは発火していないはず
                Assert.IsFalse(acquisitionFailed, "ImageAcquisitionFailed event is fired after successed");
                // 【実行・検証：異常系】既にスタートしている状態で再度スタートを呼ぶ
                // スタブ実装によれば、IsLiveViewActiveがtrueの場合、エラーイベント(ImageAcquisitionFailed)が発火するはず
                iWiaSystem.StartLiveView();
                Assert.IsTrue(acquisitionFailed, "ImageAcquisitionFailed event is NOT fired when already started"); // ※テストコードロジックの意図に合わせてAssert.IsTrueに修正しています

            }
            finally
            {
                // 【後始末】
                iWiaSystem.LiveViewStarted -= LiveViewStartedHandler;
                iWiaSystem.AcquireImageAvailable -= AcquireImageAvailableHandler;
                iWiaSystem.ImageAcquisitionFailed -= ImageAcquisitionFailedHandler;
                System.IO.File.Delete(testPath);
            }

            
            // テスト終了のためライブビューを停止し、非同期処理の完了を少し待つ
            iWiaSystem.StopLiveView();
            await TestUtils.Delaymsec(500);
        }

        /// <summary>
        /// StopLiveViewのテスト
        /// </summary>
        /// <remarks>
        /// 稼働中のライブビューを停止した際に、状態が更新され、停止イベントが発火することを検証します。
        /// </remarks>
        [TestMethod]
        public void TestStopLiveView()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】イベント検知フラグ
            bool stoppedFired = false;

            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            EventHandler LiveViewStoppedHandler = (s, e) => stoppedFired = true;
            try
            {
                iWiaSystem.StopLiveView(); 
                // 確実にライブビューを開始させるための準備
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);

                iWiaSystem.StartLiveView(); // まず開始する

                iWiaSystem.LiveViewStopped += LiveViewStoppedHandler;

                // 【実行】ライブビュー停止
                iWiaSystem.StopLiveView();

                // 【検証】プロパティがオフ(false)になっていること
                Assert.IsFalse(iWiaSystem.IsLiveViewActive, "StopLiveView is fail: IsLiveViewActive is not false");
                // 【検証】停止イベントが発火したこと
                Assert.IsTrue(stoppedFired, "LiveViewStopped event is not fired");
            }
            finally
            {
                // 【後始末】
                iWiaSystem.LiveViewStopped -= LiveViewStoppedHandler;
                System.IO.File.Delete(testPath);
            }
        }

        /// <summary>
        /// AcquireImageのテスト
        /// </summary>
        /// <remarks>
        /// 単発の画像取り込みを実行し、最新の取り込み結果プロパティが更新されることと、
        /// 成功/失敗イベントの適切な発火を検証します。
        /// </remarks>
        [TestMethod]
        public void TestAcquireImage()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】イベント検知フラグと画像ファイルのセットアップ
            bool eventFired = false;
            bool eventfailed = false;

            EventHandler AcquireImageAvailableHandler = (s, e) => eventFired = true;
            EventHandler ImageAcquisitionFailedHandler = (s, e) => eventfailed = true;

            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            try
            {
                iWiaSystem.AcquireImageAvailable += AcquireImageAvailableHandler;
                iWiaSystem.ImageAcquisitionFailed += ImageAcquisitionFailedHandler;

                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath); // 疑似的にカメラからの取込データをセット

                // 【実行：正常系】コンフィグID(1)を指定して取込実行
                Assert.IsTrue(iWiaSystem.AcquireImage(1), "AcquireImage is fail");

                // 【検証】最新の取得結果や画像オブジェクトがnullでないこと（更新されていること）
                Assert.IsNotNull(iWiaSystem.LatestAcquireResult, $"{nameof(IWiaSystem.LatestAcquireResult)} is null after acquire");
                Assert.IsNotNull(iWiaSystem.LatestAcquiredImage, $"{nameof(IWiaSystem.LatestAcquiredImage)} is null after acquire");

                // 【検証】成功イベントが発火し、失敗イベントは発火していないこと
                Assert.IsTrue(eventFired, "AcquireImageAvailable event is not fired");
                Assert.IsFalse(eventfailed, "ImageAcquisitionFailed event is fired after success");
            }
            finally
            {
                // 【後始末】
                iWiaSystem.AcquireImageAvailable -= AcquireImageAvailableHandler;
                iWiaSystem.ImageAcquisitionFailed -= ImageAcquisitionFailedHandler;
                System.IO.File.Delete(testPath);
            }

            // 【検証：異常系】範囲外のコンフィグIDを指定した場合に ArgumentOutOfRangeException が発生するか
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.AcquireImage(invalidId));
        }

        /// <summary>
        /// TuneStartのテスト
        /// </summary>
        /// <remarks>
        /// 認識設定の自動調整（チューニング）を開始した際の状態遷移を検証します。
        /// ステータスがRunningになり、対象コンフィグ番号や実行連番が正しく更新されるかを確認します。
        /// </remarks>
        [TestMethod]
        public void TestTuneStart()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】テスト前の連番と対象IDを保持
            int configId = 10;
            int initialSeq = iWiaSystem.TuneCurrentSeqNumber;

            bool eventIsTuning = false;
            bool eventTuneCurrentSeqNumber = false;
            bool eventTuneCurrentConfigNumber = false;
            bool eventTuneCurrentState = false;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(IWiaSystem.IsTuning))
                {
                    eventIsTuning = true;
                } else if (e.PropertyName == nameof(IWiaSystem.TuneCurrentSeqNumber))
                {
                    eventTuneCurrentSeqNumber = true;
                }else if (e.PropertyName == nameof(IWiaSystem.TuneCurrentConfigNumber))
                {
                    eventTuneCurrentConfigNumber = true;
                }
                else if (e.PropertyName == nameof(IWiaSystem.TuneCurrentState))
                {
                    eventTuneCurrentState = true;
                }
            }


            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;

            try
            {
                // チューニングには画像が必要なためセットアップ
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);

                iWiaSystem.PropertyChanged += Handler;

                // 【実行：正常系】マルチ照明チューニング無効(false)で開始
                int tuneId = iWiaSystem.TuneStart(configId, false);

                // 【検証】有効なチューニングID（0以上）が返ってくるか
                Assert.IsGreaterThanOrEqualTo(0, tuneId, "TuneStart is fail: returned id is incorrect");

                // 【検証】チューニング中フラグがONになっているか
                Assert.IsTrue(iWiaSystem.IsTuning, "TuneStart is fail: IsTuning is not true");

                // 【検証】現在の状態が Running(実行中) であるか
                Assert.AreEqual(TuneState.Running, iWiaSystem.TuneCurrentState, $"{nameof(IWiaSystem.TuneCurrentState)} is not Running");

                // 【検証】ターゲットのコンフィグ番号が意図通りにセットされているか
                Assert.AreEqual(configId, iWiaSystem.TuneCurrentConfigNumber, $"{nameof(IWiaSystem.TuneCurrentConfigNumber)} is not updated");

                // 【検証】実行連番が1つインクリメントされているか
                Assert.AreEqual(initialSeq + 1, iWiaSystem.TuneCurrentSeqNumber, $"{nameof(IWiaSystem.TuneCurrentSeqNumber)} did not increment");

                // 【検証】プロパティイベントの実行確認
                Assert.IsTrue(eventIsTuning, "eventIsTuning is not fiered");
                Assert.IsTrue(eventTuneCurrentSeqNumber, "eventTuneCurrentSeqNumber is not fiered");
                Assert.IsTrue(eventTuneCurrentConfigNumber, "eventTuneCurrentConfigNumber is not fiered");
                Assert.IsTrue(eventTuneCurrentState, "eventTuneCurrentState is not fiered");
            }
            finally
            {
                // 【後始末】
                iWiaSystem.PropertyChanged -= Handler;
                System.IO.File.Delete(testPath);
            }

            // 【検証：異常系】範囲外のコンフィグID指定で例外が発生するか
            int invalidId = iWiaSystem.Job.GetConfigMaxNum() + 1;
            ExceptionTest<ArgumentOutOfRangeException>(() => iWiaSystem.TuneStart(invalidId, false));
        }

        /// <summary>
        /// TuneAbortのテスト
        /// </summary>
        /// <remarks>
        /// 実行中のチューニングをキャンセル（中断）した際に、フラグが落ち、ステータスがCompletedに遷移することを検証します。
        /// </remarks>
        [TestMethod]
        public void TestTuneAbort()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】画像のロード
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            bool eventIsTuning = false;
            bool eventTuneCurrentState = false;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(IWiaSystem.IsTuning))
                {
                    eventIsTuning = true;
                }
                else if (e.PropertyName == nameof(IWiaSystem.TuneCurrentState))
                {
                    eventTuneCurrentState = true;
                }
            }
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);
                // チューニングを意図的に開始させておく
                iWiaSystem.TuneStart(10, false);

                // 【実行】チューニング中断
                iWiaSystem.PropertyChanged += Handler;
                iWiaSystem.TuneAbort();

                // 【検証】チューニング中フラグがOFF(false)になったか
                Assert.IsFalse(iWiaSystem.IsTuning, "TuneAbort is fail: IsTuning is not false");

                // 【検証】中断されたため、ステータスがCompletedに遷移しているか
                Assert.AreEqual(TuneState.Completed, iWiaSystem.TuneCurrentState, $"{nameof(IWiaSystem.TuneCurrentState)} is not Completed");

                // 【検証】プロパティイベントの実行確認
                Assert.IsTrue(eventIsTuning, "eventIsTuning is not fiered");
                Assert.IsTrue(eventTuneCurrentState, "eventTuneCurrentState is not fiered");
            }
            finally
            {
                // 【後始末】
                iWiaSystem.PropertyChanged -= Handler;
                System.IO.File.Delete(testPath);
            }

            
        }

        /// <summary>
        /// TuneResultJudgeのテスト
        /// </summary>
        /// <remarks>
        /// チューニング結果の判定（適用可否の判断）処理を呼んだ際の状態遷移を検証します。
        /// 判定後は待機状態(Waiting)に戻ることを確認します。
        /// </remarks>
        [TestMethod]
        public void TestTuneResultJudge()
        {
            IWiaSystem iWiaSystem = WiaService;

            // 【準備】画像セットアップとチューニング開始
            DateTime time = DateTime.Now;
            string format = "yyyyMMddhhmmss";
            string dateString = time.ToString(format) + ".bmp";
            string testPath = System.IO.Path.GetTempPath() + "/" + dateString;
            bool eventIsTuning = false;
            bool eventTuneCurrentState = false;
            void Handler(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(IWiaSystem.IsTuning))
                {
                    eventIsTuning = true;
                }
                else if (e.PropertyName == nameof(IWiaSystem.TuneCurrentState))
                {
                    eventTuneCurrentState = true;
                }
            }
            try
            {
                TestUtils.CreateBlackBmp(testPath);
                iWiaSystem.LoadBitmapFile(testPath);
                iWiaSystem.TuneStart(10, false); // 事前にチューニングを開始

                // 【実行・検証】判定処理が正常終了(true)するか
                iWiaSystem.PropertyChanged += Handler;
                Assert.IsTrue(iWiaSystem.TuneResultJudge(), "TuneResultJudge is fail");

                // 【検証】判定が終了したので、チューニング中フラグがOFF(false)になるか
                Assert.IsFalse(iWiaSystem.IsTuning, $"{nameof(IWiaSystem.IsTuning)} is not false after judge");

                // 【検証】次のチューニング指示を待つ Waiting 状態に戻っているか
                Assert.AreEqual(TuneState.Waiting, iWiaSystem.TuneCurrentState, $"{nameof(IWiaSystem.TuneCurrentState)} is not Waiting");

                // 【検証】プロパティイベントの実行確認
                Assert.IsTrue(eventIsTuning, "eventIsTuning is not fiered");
                Assert.IsTrue(eventTuneCurrentState, "eventTuneCurrentState is not fiered");
            }
            finally
            {
                // 【後始末】
                iWiaSystem.PropertyChanged -= Handler;
                System.IO.File.Delete(testPath);
            }

        }
    }
}