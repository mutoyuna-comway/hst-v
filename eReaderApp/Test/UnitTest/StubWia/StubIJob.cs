using System;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
    public class StubIJob : IJob
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        public event EventHandler<IReadCompletedEventArgs> ConfigReadResultAvailable;
        public IJobConfig GetConfig(int index) { return null; }
        public IJobConfig[] GetSortedEnableConfigArray() {  return null; }
        public bool CheckFontIdValidity() { return true; }
        public bool CopyConfig(int srcConfID, int dstConfID) { return true; }
        public int RunRead(IImageSource imgSrc, ScoreAs100 scoreAs100) {  return 1; }
        public int GetLastBestConfigId() { return 1; }
        public IReadResult GetReadBestResult(int configID) { return null; }
        public bool CheckValidConfigID(int configID) { return true; }
        public bool CheckExistenceConfig(int targetConfig) { return true; }
        public int GetConfigMaxNum() { return 0; }
        public int RunReadRetry(IImageSource imgSrc, ScoreAs100 scoreAs100, int configID,
            int lightRange, int lightStep, int sizeRange, int sizeStep,
            int internalFilter, int timeOut, int overwrite, out IReadResult result)
        { result = null; return 1; }

    }
}
