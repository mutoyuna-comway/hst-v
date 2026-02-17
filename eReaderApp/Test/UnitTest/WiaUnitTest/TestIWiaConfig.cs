
﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubWia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using Wia.Abstractions;

/// <summary>
/// ユニットテストクラス
/// </summary>
namespace TestWiaSystem
{

    /// <summary>
    /// StatsResultのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIStatsResult : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIStatsResultData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ConfigName", "", true };
                yield return new object[] { "RunNu", 10, true };
                yield return new object[] { "PassNum", 10, true };
                yield return new object[] { "FailNum", 10, true };
                yield return new object[] { "AvgScore", 10.0, true };
                yield return new object[] { "AvgScoreString", "", true };
            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIStatsResultData))]
        public void IStatsResultPropertyTest(string name, object value, bool isPrivate)
        {
            IStatsResult iStatsResult = StatsResult;
            this.PropertyTest(iStatsResult, name, value, isPrivate);
        }
    }

    /// <summary>
    /// CameraInfoのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestICameraInfo : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestICameraInfoData
        {
            get
            {
                var expected = PhysicalAddress.Parse("00-11-22-33-44-55");
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "CameraFound", true, true };
                yield return new object[] { "CameraIsConnected", true, true };
                yield return new object[] { "ModelName", "", true };
                yield return new object[] { "FirmwareVersion", "", true };
                yield return new object[] { "MacAddress", expected, true }; 
                yield return new object[] { "MacAddressString", "", true };
                yield return new object[] { "SerialNumber", "", true };
                yield return new object[] { "PacketSize", 10UL, true };
                yield return new object[] { "ConnectedIPAddress", new System.Net.IPAddress(0), true };
                yield return new object[] { "SubnetMask", new System.Net.IPAddress(0), true };
            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestICameraInfoData))]
        public void ICameraInfoPropertyTest(string name, object value, bool isPrivate)
        {
            ICameraInfo iCameraInfo = WiaSystem.Device.CameraInfo;
            this.PropertyTest(iCameraInfo, name, value, isPrivate);
        }
    }
    /// <summary>
    /// CameraInfoFactoryのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestICameraInfoFactory : AbstractTest
    {

    }
    /// <summary>
    /// Imageのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIImage : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIImageData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Image", IntPtr.Zero, true };
            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIImageData))]
        public void IImagePropertyTest(string name, object value, bool isPrivate)
        {
            IImage iImage = ReadCompletedEventArgs.AcqResult.ProcessImage;
            this.PropertyTest(iImage, name, value, isPrivate);
        }
    }
    
    /// <summary>
    /// WaitResponseのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIWaitResponse : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIWaitResponseData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ResponseCommand", "", false };
                yield return new object[] { "ResponseTime", 10UL, false };
            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIWaitResponseData))]
        public void IWaitResponsePropertyTest(string name, object value, bool isPrivate)
        {
            IWaitResponse iWaitResponse = WaitResponse;
            this.PropertyTest(iWaitResponse, name, value, isPrivate);
        }
    }
    /// <summary>
    /// FilterConfigのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIFilterConfig : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIFilterConfigData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "Filter", FilterType.BlackHat, false };
            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIFilterConfigData))]
        public void IFilterConfigPropertyTest(string name, object value, bool isPrivate)
        {
            IFilterConfig iFilterConfig = FilterConfig;
            this.PropertyTest(iFilterConfig, name, value, isPrivate);
        }
    }

    /// <summary>
    /// CharacterSizeのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestICharacterSize : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestICharacterSizeData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ULX", 10.0, false };
                yield return new object[] { "ULY", 10.0, false };
                yield return new object[] { "Wide", 10.0, false };
                yield return new object[] { "High", 10.0, false };
                yield return new object[] { "Theta", 10.0, false };
            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestICharacterSizeData))]
        public void ICharacterSizePropertyTest(string name, object value, bool isPrivate)
        {
            ICharacterSize iCharacterSize = WiaSystem.Job.SelectedConfig.ReadSettings.CharSize;
            this.PropertyTest(iCharacterSize, name, value, isPrivate);
        }
    }
    /// <summary>
    /// Regionのユニットテストクラス
    /// </summary>
    [TestClass]
    public class TestIRegion : AbstractTest
    {
        // テストデータを生成するプロパティ
        public static IEnumerable<object[]> TestIRegionData
        {
            get
            {
                /* プロパティ名, テスト用の設定値, プライベートプロパティか否か */
                yield return new object[] { "ROIMode", RegionMode.Normal, false };
                yield return new object[] { "UlX", 10.0, false };
                yield return new object[] { "UlY", 10.0, false };
                yield return new object[] { "Wide", 10.0, false };
                yield return new object[] { "High", 10.0, false };
                yield return new object[] { "Theta", 10.0, false };
                yield return new object[] { "Phi", 10.0, false };
                yield return new object[] { "MarginX", 10.0, false };
                yield return new object[] { "MarginY", 10.0, false };
            }
        }
        /// <summary>
        /// プロパティのテスト
        /// </summary>
        [TestMethod]
        [DynamicData(nameof(TestIRegionData))]
        public void IRegionPropertyTest(string name, object value, bool isPrivate)
        {
            IRegion iRegion = WiaSystem.Job.SelectedConfig.AcquireSettings.WOI;
            this.PropertyTest(iRegion, name, value, isPrivate);
        }
    }

}