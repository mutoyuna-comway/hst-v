using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
    public class StubIJob : IJob
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<IReadCompletedEventArgs> ConfigReadResultAvailable;
        public event EventHandler<IReadCompletedEventArgs> ConfigReadCompleted;

        public StubIJob() {

        }

        
        //public ReadMethod ReadType { get; set; }
        private ReadMethod _readType;
        public ReadMethod ReadType
        {
            get => _readType;
            set
            {
                _readType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReadType)));
            }
        }
        //ScoreMode ScoreType { get; set; }
        private ScoreMode _scoreType;
        public ScoreMode ScoreType
        {
            get => _scoreType;
            set
            {
                _scoreType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScoreType)));
            }
        }
        
        private IJobConfig _selectedConfig = new StubIJobConfig();
        public IJobConfig SelectedConfig {
            get { return this._selectedConfig; }
            private set
            {
                this._selectedConfig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedConfig)));
            }
        }
        //public int SelectedConfigIndex { get; set; }
        private int _selectedConfigIndex;
        public int SelectedConfigIndex
        {
            get => _selectedConfigIndex;
            set
            {
                _selectedConfigIndex = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedConfigIndex)));
            }
        }
        private IConfigStore _configs = new StubIConfigStore();
        public IConfigStore Configs {
            get { return this._configs; }
            private set
            {
                this._configs = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Configs)));
            }
        }

        /// <summary>
        /// コンフィグ最大数構成タイプ
        /// </summary>
        private MaxNumConfigType _MaxNumConfig;
        public MaxNumConfigType MaxNumConfig
        {
            get => _MaxNumConfig;
            set
            {
                this._MaxNumConfig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxNumConfig)));
            }
        }
        // コンストラクタを介さずにStubインスタンスを生成
        // コンストラクタ内の複雑なロジックや依存関係をスキップし、
        // テスト専用の純粋なオブジェクトを取得するためにGetUninitializedObjectを使用している。
        private IWiaSystem _systemService = (IWiaSystem)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(StubIWiaSystem));
        public IWiaSystem SystemService
        {
            get { return this._systemService; }
            private set
            {
                this._systemService = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SystemService)));
            }
        }

        /// <summary>
        /// 選択されているジョブコンフィグが変更されることを通知するイベント
        /// </summary>
        public event EventHandler SelectedConfigChanging
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// 選択されているジョブコンフィグが変更されたことを通知するイベント
        /// </summary>
        public event EventHandler SelectedConfigChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public IJobConfig GetConfig(int index) {
            if (index < 0 || index >= GetConfigMaxNum())
            {
                throw new ArgumentOutOfRangeException(nameof(index), "configID does not exist");
            }
            return new StubIJobConfig();

        }
        public IJobConfig[] GetSortedEnableConfigArray() { return new IJobConfig[0]; }
        public bool CheckFontIdValidity() { return false; }
        public bool CopyConfig(int srcConfID, int dstConfID) {
            int maxNum = GetConfigMaxNum();
            if (srcConfID < 0 || srcConfID >= maxNum)
            {
                throw new ArgumentOutOfRangeException(nameof(srcConfID), "Source configID does not exist");
            }
            if (dstConfID < 0 || dstConfID >= maxNum)
            {
                throw new ArgumentOutOfRangeException(nameof(dstConfID), "destination configID does not exist");
            }
            return true;
        }
        public int RunRead() {
            if (_readFailedNum == 3)
            {
                return -1;
            }
            var args = new StubIReadCompletedEventArgs();
            // 登録されているリスナーに読取り結果の更新と完了を通知
            ConfigReadResultAvailable?.Invoke(this, args);
            ConfigReadCompleted?.Invoke(this, args);
            _readFailedNum++;
            return 1;
        }

        public int _readSuccessNum = 0; //とりあえずの保持方法
        public int _readFailedNum = 0;
        /// <summary>
        /// チューン結果のリセット
        /// </summary>
        public void ClearTuneResult() {
            if (this.SelectedConfig != null)
            {
                this.SelectedConfig.ClearTuneResult();
            }
        }
        public int GetLastBestConfigId() { 
            if(this._readSuccessNum == 0 && this._readFailedNum == 0)
            {
                return 0; 
            }

            return 1;
        }
        public IReadResult GetReadBestResult(int configID) {
            if (configID < 0 || configID >= this.GetConfigMaxNum())
            {
                throw new ArgumentOutOfRangeException();
            }
            return new StubIReadResult();
        }
        public bool CheckValidConfigID(int configID) {
            if (configID < 0 || configID >= this.GetConfigMaxNum())
            {
                throw new ArgumentOutOfRangeException();
            }
            return true;
        }
        public bool CheckExistenceConfig(int targetConfig) {
            if (targetConfig < 0 || targetConfig >= this.GetConfigMaxNum())
            {
                throw new ArgumentOutOfRangeException();
            }
            return true; 
        }
        public int GetConfigMaxNum() { return WiaConstants.ConfigMaxNum; }
        public int RunReadRetry(int configID, int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, out IReadResult result)
        {
            
            if (configID < 0 || configID >= this.GetConfigMaxNum())
            {
                throw new ArgumentOutOfRangeException();
            }
            result = null;
            return 0; 
        }

    }
}
