using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wia.Abstractions;

namespace TestWiaSystem
{

    [TestClass]
    public class TestStubWiaSystem : AbstractTestWiaSystem
    {
        public override IWiaSystem WiaSystem { get; set; }// = "StubWiaSystem"

        [TestMethod]
        public void 追加テストパターン1()
        {
            //Assert.AreEqual("XXXXX/YYYYY" ,WiaSystem.GetJobFolder());
        }


    }
}
