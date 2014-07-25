using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Data;

using SR.Data.DB;
using SR.Data.DB.DBFacory;
using SR.Data.DB.Helper;

using SR.Data.DB.External.MSSQL.MSSQL2000;

namespace utExMSSQL
{
    [TestClass]
    public class utMSSQL
    {
        [TestMethod]
        public void tMSSQL2000()
        {
            new DBFactoryCreator_MSSQL2000();

            MSSQL2000_ConnectionInfo ci = new MSSQL2000_ConnectionInfo
            {
                HostAddress = "211.211.211.7",
                Catalog = "master",
                UserName = "sa",
                Password = "123"
            };

            DBFacoryPool.Instance.AddConnectionInfo(ci);

            //conn in plan
            SQLTextPlan plan = new SQLTextPlan();
            plan.ConnectionInfo = ci;
            plan.CommandText="select * from Budget_RQ..s_Power ";

            DBHelper helper = new DBHelper();

            DataTable dt = helper.GetDataTable(plan);
        }
    }
}
