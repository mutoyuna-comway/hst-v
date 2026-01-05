using System;

namespace Wia.Abstractions
{
    public interface IWiaCommManager
    {
        DelimeterType Delimeter { get; set; }
        ulong SocketPort { get; set; }
    }
}