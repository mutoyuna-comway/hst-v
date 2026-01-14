using System;
using System.ComponentModel;

namespace Wia.Abstractions
{
    /// <summary>
    /// 通信管理
    /// </summary>
    public interface IWiaCommManager : INotifyPropertyChanged
    {
        // ------------------------------
        //
        // プロパティ
        //
        // ------------------------------
        DelimeterType Delimeter { get; set; }
        ulong SocketPort { get; set; }
    }
}