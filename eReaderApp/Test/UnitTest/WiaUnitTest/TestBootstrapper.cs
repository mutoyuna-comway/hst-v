using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWiaSystem;

[TestClass]
public class TestBootstrapper
{
    [AssemblyInitialize]
    public static void AssemblyInit(TestContext context)
    {
        // 全テストの開始前に一度だけ実行され、InstanceManagerにContextを渡す
        // これにより getMode() 内での null チェックを通過できるようになる
        InstanceManager.TestContext = context;
    }
}