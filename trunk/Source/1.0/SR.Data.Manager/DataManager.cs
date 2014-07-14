using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SR.Data.DB;

namespace SR.Data.Manager
{
    public class DataManager : IDataManager
    {
        public DataTable GetDataTable(IData data, IExpression expression)
        {
            ISQLPlan plan = ExecutePlanBuilder.BuildSQLPlan(data, expression);

            DB.Helper.DBHelper helper = new DB.Helper.DBHelper();

            return helper.GetDataTable(plan);
        }

        public DataRow GetDataRow(IData data, IExpression expression)
        {
            ISQLPlan plan = ExecutePlanBuilder.BuildSQLPlan(data, expression);

            DB.Helper.DBHelper helper = new DB.Helper.DBHelper();

            return helper.GetDataRow(plan);
        }

        public IDataEntity GetEntity(IData data, IExpression expression)
        {
            ISQLPlan plan = ExecutePlanBuilder.BuildSQLPlan(data, expression);

            DB.Helper.DBHelper helper = new DB.Helper.DBHelper();

            DataTable dt = helper.GetDataTable(plan);

            IDataEntity en = new Entity.DataEntity(dt);

            return en;
        }
    }
}
