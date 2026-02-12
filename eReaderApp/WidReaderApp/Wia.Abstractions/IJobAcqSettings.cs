using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    /// <summary>
    /// ジョブコンフィグの画像取込み設定
    /// </summary>
    public interface IJobAcqSettings : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 画像反転モード
        /// </summary>
        ImageOrient AcqOrient { get; set; }

        /// <summary>
        /// 検査領域
        /// </summary>
        IRegion WOI { get; set; }

        /// <summary>
        /// カメラ取込みゲイン
        /// </summary>
        int Gain { get; set; }

        /// <summary>
        /// カメラ取込み露光時間
        /// </summary>
        int Exposure { get; set; }
        
        /// <summary>
        /// 画像回転角度
        /// </summary>
        double Rotate { get; set; }


        /// <summary>
        /// 画像拡大サイズモード設定
        /// </summary>
        ImageSizeMode SizeMode { get; set; }

        /// <summary>
        /// 画像拡大拡大率
        /// </summary>
        ImageExpandRate ExpandRate { get; set; }

        /// <summary>
        /// 画像前処理フィルタ種類
        /// </summary>
        FilterType AcqFilterType { get; set; }

        /// <summary>
        /// 画像前処理フィルタカーネルサイズ
        /// </summary>
        int AcqFilterSize { get; set; }

        /// <summary>
        /// フィルター極性　(利用目的が不明、現状は未使用と思われる。)
        /// </summary>
        MarkColor AcqFilterColor { get; set; }

        /// <summary>
        /// 反復数
        /// </summary>
        int AcqFilterIteration { get; set; }

        /// <summary>
        /// 画像取込みモード
        /// </summary>
        AcquireMethod AcqMode { get; set; }

        /// <summary>
        /// 現在選択されている照明構成
        /// </summary>
        ILightConfig SelectedLightConfig { get; }

        /// <summary>
        /// 現在選択されている照明構成番号
        /// </summary>
        int SelectedLightConfigIndex { get; set; }

        // ------------------------------
        //
        // イベント
        //
        // ------------------------------

        /// <summary>
        /// 選択されている照明コンフィグの照明強度が変更されたことを通知するイベント
        /// </summary>
        event EventHandler SelectedLightPowerChaneged;

        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// クローン作成
        /// </summary>
        /// <returns></returns>
        IJobAcqSettings Clone();

        /// <summary>
        /// 照明コンフィグの取得
        /// </summary>
        /// <param name="index">照明コンフィグ番号</param>
        /// <returns>照明コンフィグ</returns>
        ILightConfig GetLightConfig(int index);

        /// <summary>
        /// 照明コンフィグの設定
        /// </summary>
        /// <param name="index">照明コンフィグ番号</param>
        /// <param name="lightConfig">照明コンフィグ</param>
        void SetLightConfig(int index, ILightConfig lightConfig);

        /// <summary>
        /// 選択されている照明コンフィグの照明強度を設定する
        /// </summary>
        /// <param name="power"></param>
        void SetSelectedLightPower(int power);

        /// <summary>
        /// 中身のメンバーの内容をコピーする
        /// </summary>
        /// <param name="src"></param>
        void CopyFrom(IJobAcqSettings src);

        /// <summary>
        /// 特殊モードの照明コンフィグの取得
        /// </summary>
        /// <param name="acqMode">特殊モード</param>
        /// <returns>照明コンフィグ</returns>
        ILightConfig GetSpecialLightConfig(AcquireMethod acqMode);

        /// <summary>
        /// 特殊モードの照明コンフィグの設定
        /// </summary>
        /// <param name="acqMode">特殊モード</param>
        void SetSpecialLightConfig(AcquireMethod acqMode, ILightConfig lightConfig);

        /// <summary>
        /// 取込み条件の設定
        /// </summary>
        /// <param name="cond">取込み条件</param>
        void SetAcquireCondition(IAcquireCondition cond);

    }
}
