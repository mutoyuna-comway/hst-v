using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wia.Abstractions;

namespace TestWiaSystem
{
    public static class TestUtils
    {
        public static async void DelaySample(int timeMs)
        {
            await Task.Delay(timeMs);
        }

        // 200x200の黒塗りBMPファイルを作成する
        public static void CreateBlackBmp(string filePath)
        {
            int width = 200;
            int height = 200;
            int fileSize = 54 + (width * height * 3); // ヘッダー54バイト + 画素データ

            byte[] bmpBytes = new byte[fileSize];

            // --- BMPヘッダー (14 bytes) ---
            bmpBytes[0] = (byte)'B'; bmpBytes[1] = (byte)'M'; // シグネチャ
            BitConverter.GetBytes(fileSize).CopyTo(bmpBytes, 2); // ファイルサイズ
            bmpBytes[10] = 54; // オフセット（ヘッダー終了位置）

            // --- DIBヘッダー (BITMAPINFOHEADER: 40 bytes) ---
            BitConverter.GetBytes(40).CopyTo(bmpBytes, 14);     // ヘッダーサイズ
            BitConverter.GetBytes(width).CopyTo(bmpBytes, 18);  // 幅
            BitConverter.GetBytes(height).CopyTo(bmpBytes, 22); // 高さ
            bmpBytes[26] = 1;                                   // プレーン数
            bmpBytes[28] = 24;                                  // 1ピクセルあたりのビット数 (24bit = RGB)

            // 画素データ部分は初期値が0なので、何もしなくても「真っ黒」になります。
            // ※200pxは4バイト境界に並ぶため、パディング処理も不要でシンプルです。

            File.WriteAllBytes(filePath, bmpBytes);
        }
    }
}