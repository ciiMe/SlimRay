using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlimRay.App;
using SlimRay.DB;

namespace SlimRay.Test.DB
{
    [TestClass]
    public class SQLRequest
    {
        [TestInitialize]
        public void init()
        {
            AppConstant.InitApps();
        }

        private DBRequest buildDBRequest()
        {
            DBAddress address = AppConstant.GetDefaultDBAddress();

            return new DBRequest(address)
            {
                Timeout = 20
            };
        }

        private IExecutor getExector()
        {
            return AppGate.Instance.Get(AppConstant.MainDBType) as IExecutor;
        }

        [TestMethod]
        public void GetAsDataTable()
        {
            DBRequest r = buildDBRequest();
            r.Command = "select * from book ";

            IExecutor executor = getExector();

            DataTable dt = executor.GetDataTable(r);

            Assert.AreNotEqual(dt.Rows.Count, 0);
        }

        [TestMethod]
        public void GetAsValue()
        {
            DBRequest r = buildDBRequest();
            r.Command = "select cod_code from book where book_id = '1000000004'";

            IExecutor executor = getExector();

            string name = executor.GetResult(r).ToString();

            Assert.IsNotNull(name);
            Assert.AreNotEqual(name.Length, 0);
        }

        [TestMethod]
        public void ExecuteSQLCommand()
        {
            DBRequest r = buildDBRequest();
            r.Command = "update book set cod_code = '经济' where book_id = '1000000004'";

            IExecutor executor = getExector();

            int effectedCount = executor.Execute(r);

            Assert.AreNotEqual(effectedCount, 0);
        }
    }
}
