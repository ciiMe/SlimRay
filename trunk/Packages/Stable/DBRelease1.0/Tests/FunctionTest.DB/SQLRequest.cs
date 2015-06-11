using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.DB;

namespace FunctionTest.DB
{
    [TestClass]
    public class SQLRequest
    {
        private void startSystem()
        {
            _SystemStart s = new _SystemStart();
            s.ReadDBServerType();
            s.ReadDBServerAccessParameters();
        }

        [TestMethod]
        public void plainSQLRequest()
        {
            //should be loaded while system starting.
            startSystem();

            Request p = new Request(_SystemStart.DBAccessParameters);

            p.Command = "select * from xxx where id = {id}";
            p.AddParameter("id", 1);
            p.Timeout = 20;
        }
    }
}
