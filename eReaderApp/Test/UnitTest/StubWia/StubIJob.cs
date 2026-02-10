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
        
        private IJobConfig _selectedConfig;
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
        private IConfigStore _configs;
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
        MaxNumConfigType MaxNumConfig
        {
            get => _MaxNumConfig;
            set
            {
                this._MaxNumConfig = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxNumConfig)));
            }
        }

        private IWiaSystem _systemService = null;
        public IWiaSystem SystemService
        {
            get { return this._systemService; }
            private set
            {
                this._systemService = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SystemService)));
            }
        }

        MaxNumConfigType IJob.MaxNumConfig { get => MaxNumConfig; set => MaxNumConfig = value; }

        
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

        public IJobConfig GetConfig(int index) { return null; }
        public IJobConfig[] GetSortedEnableConfigArray() {  return null; }
        public bool CheckFontIdValidity() { return true; }
        public bool CopyConfig(int srcConfID, int dstConfID) { return true; }
        public int RunRead() {  return 1; }
        /// <summary>
        /// チューン結果のリセット
        /// </summary>
        public void ClearTuneResult() {}
        public int GetLastBestConfigId() { return 1; }
        public IReadResult GetReadBestResult(int configID) { return null; }
        public bool CheckValidConfigID(int configID) { return true; }
        public bool CheckExistenceConfig(int targetConfig) { return true; }
        public int GetConfigMaxNum() { return 0; }
        public int RunReadRetry(int configID, int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, out IReadResult result)
        { result = null; return 1; }

    }
}
