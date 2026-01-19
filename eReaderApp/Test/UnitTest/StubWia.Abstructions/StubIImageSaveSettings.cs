using System;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia.Abstructions
{
 
    public class StubIImageSaveSettings : IImageSaveSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public StubIImageSaveSettings() { }       
        //public bool EnableAllSaveImage { get; set; }
        private bool _enableAllSaveImage;
        public bool EnableAllSaveImage
        {
            get => _enableAllSaveImage;
            set
            {
                _enableAllSaveImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnableAllSaveImage)));
            }
        }
        //public int NumOfAllSaveImage { get; set; }
        private int _numOfAllSaveImage;
        public int NumOfAllSaveImage
        {
            get => _numOfAllSaveImage;
            set
            {
                _numOfAllSaveImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumOfAllSaveImage)));
            }
        }

        //public String AllImageSaveDir { get; set; }
        private String _allImageSaveDir;
        public String AllImageSaveDir
        {
            get => _allImageSaveDir;
            set
            {
                _allImageSaveDir = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AllImageSaveDir)));
            }
        }
        //public bool EnableFailSaveImage { get; set; }
        private bool _enableFailSaveImage;
        public bool EnableFailSaveImage
        {
            get => _enableFailSaveImage;
            set
            {
                _enableFailSaveImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EnableFailSaveImage)));
            }
        }
        //public int NumOfFailSaveImage { get; set; }
        private int _numOfFailSaveImage;
        public int NumOfFailSaveImage
        {
            get => _numOfFailSaveImage;
            set
            {
                _numOfFailSaveImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumOfFailSaveImage)));
            }
        }
        //public String FailImageSaveDir { get; set; }
        private String _failImageSaveDir;
        public String FailImageSaveDir
        {
            get => _failImageSaveDir;
            set
            {
                _failImageSaveDir = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FailImageSaveDir)));
            }
        }
    }
}
