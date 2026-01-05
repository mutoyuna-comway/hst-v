using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wia.Abstractions
{
    public interface IImageSaveSettings
    {
        /// <summary>
        /// 全画像保存可否
        /// </summary>
        bool EnableAllSaveImage { get; set; }

        /// <summary>
        /// 全画像保存枚数
        /// </summary>
        /// <remarks>指定範囲[0-65536]</remarks>
        int NumOfAllSaveImage { get; set; }

        /// <summary>
        /// 全画像保存ディレクトリ
        /// </summary>
        String AllImageSaveDir { get; set; }

        /// <summary>
        /// 失敗画像の保存可否
        /// </summary>
        bool EnableFailSaveImage { get; set; }

        /// <summary>
        /// 失敗画像保存数
        /// </summary>
        /// <remarks>指定範囲[0-65536]</remarks>
        int NumOfFailSaveImage { get; set; }

        /// <summary>
        /// 失敗画像保存ディレクトリ
        /// </summary>
        String FailImageSaveDir { get; set; }
    }
}
