using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.DB;
using SlimRay.DB.Factory;

namespace FunctionTest.DB
{
    [TestClass]
    public class Executor
    {
        private void startSystem()
        {
            _SystemStart s = new _SystemStart();
            s.ReadDBServerType();
            s.ReadDBServerAccessParameters();
        }

        [TestMethod]
        public void TestMethod1()
        {
            startSystem();

            IExecutor exector = ExecutorFactory.Instance.New(_SystemStart.MainDBType);
            Request p = new Request(_SystemStart.DBAccessParameters);

            string result = exector.GetResult(p) as string;
        }
    }
}
