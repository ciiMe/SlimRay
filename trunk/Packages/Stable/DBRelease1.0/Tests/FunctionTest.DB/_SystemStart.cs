using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SlimRay.DB;
using SlimRay.DB.Factory;
using SlimRay.DB.Helpers.MSSQL;

namespace FunctionTest.DB
{
    [TestClass]
    public class _SystemStart
    {
        public const string MainDBType = "SQL2000";

        private string _connectString;
        public static ExecutorParameters DBAccessParameters;

        [TestMethod]
        public void ReadDBServerType()
        {
            //config of db server type is loaded...
            IExecutorCreator MSSQLCreatorObject = new MSSQLExecutorCreator();
            ExecutorFactory.Instance.Register(MainDBType, MSSQLCreatorObject);
        }

        [TestMethod]
        public void ReadDBServerAccessParameters()
        {
            //db access parameters loaded..
            _connectString = "";

            DBAccessParameters = new ExecutorParameters
            {
                Key = MainDBType,
                HostAddress = _connectString
            };
        }
    }
}
