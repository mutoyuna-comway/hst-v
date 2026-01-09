using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wia.Abstractions;

namespace TestWiaSystem
{
    [TestClass]
    public abstract class AbstractTestWiaSystem
    {
        public abstract IWiaSystem WiaSystem { get; set; }

        [TestMethod]
        public void 基本テストパターン1()
        {
            //Assert.AreEqual("XXXXX/YYYYY" ,WiaSystem.GetJobFolder());
        }
    }
}
