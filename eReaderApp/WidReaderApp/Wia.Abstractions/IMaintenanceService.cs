using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    public interface IMaintenanceService
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------

        /// <summary>
        /// 自己診断情報のLoadingPanelへの途中表示文字
        /// </summary>
        string SelfDiagnosisProcess { get; set; }

        /// <summary>
        /// PC情報取得の途中データ
        /// </summary>
        string CreatePCInfoProcess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string LogSaveZipDataProcess { get; set; }


        // ------------------------------
        //
        // メソッド
        //
        // ------------------------------

        /// <summary>
        /// PC情報を含んだログデータを作成する
        /// </summary>
        void CreatePCInfo(ICameraInfo camInfo, CancellationToken token);

        /// <summary>
        /// ログサイズの計算
        /// </summary>
        void LogCalculateInitialize();

        /// <summary>
        /// LogのZipデータへの保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="saveDirName"></param>
        /// <returns></returns>
        int LogSaveZipData(CancellationToken token, string saveDirName);

        /// <summary>
        /// 自己診断モードの実施
        /// </summary>
        /// <param name="outputString">出力文字列</param>
        /// <param name="retDic">Dictionary情報</param>
        /// <returns></returns>
        bool RunSelfDiagnosis(CancellationToken token, ref String outputString, Dictionary<string, string> retDic);

        /// <summary>
        /// ログの再計算
        /// </summary>
        /// <param name="isNum"></param>
        /// <param name="fileNum"></param>
        /// <param name="date"></param>
        void LogCalculateAllImage(bool isNum, int fileNum, DateTime date);

        /// <summary>
        /// ログの再計算
        /// </summary>
        /// <param name="isNum"></param>
        /// <param name="fileNum"></param>
        /// <param name="date"></param>
        void LogCalculateFailImage(bool isNum, int fileNum, DateTime date);

        /// <summary>
        /// 合計サイズの計算
        /// </summary>
        /// <returns></returns>
        long LogCalculateSum();

    }
}
