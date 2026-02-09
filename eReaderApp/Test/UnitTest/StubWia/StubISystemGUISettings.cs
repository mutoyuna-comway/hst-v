using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Wia.Abstractions;

namespace StubWia
{

    public class StubISystemGUISettings : ISystemGUISettings
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public StubISystemGUISettings() { }
        //public bool LibraryMode { get; set; }
        private bool _libraryMode;
        public bool LibraryMode
        {
            get => _libraryMode;
            set
            {
                _libraryMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LibraryMode)));
            }
        }
        //public bool ShowInTaskbar { get; set; }
        private bool _showInTaskbar;
        public bool ShowInTaskbar
        {
            get => _showInTaskbar;
            set
            {
                _showInTaskbar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShowInTaskbar)));
            }
        }
        //public bool GUILock { get; set; }
        private bool _gUILock;
        public bool GUILock
        {
            get => _gUILock;
            set
            {
                _gUILock = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GUILock)));
            }
        }
        //public bool WindowMinimized { get; set; }
        private bool _windowMinimized;
        public bool WindowMinimized
        {
            get => _windowMinimized;
            set
            {
                _windowMinimized = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WindowMinimized)));
            }
        }
        //public DisplayModeType DispMode { get; set; }
        private DisplayModeType _dispMode;
        public DisplayModeType DispMode
        {
            get => _dispMode;
            set
            {
                _dispMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DispMode)));
            }
        }
        //public int LogDispLines { get; set; }
        private int _logDispLines;
        public int LogDispLines
        {
            get => _logDispLines;
            set
            {
                _logDispLines = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LogDispLines)));
            }
        }
        //public bool AutoSaveScreen { get; set; }
        private bool _autoSaveScreen;
        public bool AutoSaveScreen
        {
            get => _autoSaveScreen;
            set
            {
                _autoSaveScreen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AutoSaveScreen)));
            }
        }
        //public AppsCloseActionType AppsCloseActionReborn { get; set; }
        private AppsCloseActionType _appsCloseActionReborn;
        public AppsCloseActionType AppsCloseActionReborn
        {
            get => _appsCloseActionReborn;
            set
            {
                _appsCloseActionReborn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AppsCloseActionReborn)));
            }
        }
    }
}
