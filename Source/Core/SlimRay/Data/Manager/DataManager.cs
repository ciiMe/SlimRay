using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SlimRay.Data.DB;
using SlimRay.Data.Manager.Mapping;
using SlimRay.Data.Manager.Operators;

namespace SlimRay.Data.Manager
{
    public class DataManager : IDataManager
    {
        public DataManager()
        {
            ExecutePlanBuildServer.Register(new SQLPlanBuilder());
            OperatorServer.Register(new ParserMSSQL());
        }

        public DataTable GetDataTable(IData data, Expression expression)
        {
            IExecutePlan plan = ExecutePlanBuildServer.ActiveService.Build(data, expression);

            DB.Helper.DBHelper helper = new DB.Helper.DBHelper();

            return helper.GetDataTable((ISQLPlan)plan);
        }

        public DataRow GetDataRow(IData data, Expression expression)
        {
            IExecutePlan plan = ExecutePlanBuildServer.ActiveService.Build(data, expression);

            DB.Helper.DBHelper helper = new DB.Helper.DBHelper();

            return helper.GetDataRow((ISQLPlan)plan);
        }

        public IDataEntity GetEntity(IData data, Expression expression)
        {
            IExecutePlan plan = ExecutePlanBuildServer.ActiveService.Build(data, expression);

            DB.Helper.DBHelper helper = new DB.Helper.DBHelper();

            DataTable dt = helper.GetDataTable((ISQLPlan)plan);

            return dt.Rows.Count == 0 ? new Entity.DataEntity(null) : new Entity.DataEntity(dt.Rows[0]);
        }

        public bool Update(IDataEntity data)
        {
            return true;
        }
    }
}
