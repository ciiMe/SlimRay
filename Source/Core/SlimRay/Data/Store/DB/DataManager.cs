using System;
using System.Data;

using SlimRay.Data.Store.Operators;
using SlimRay.Data.Store.DB.Mapping;

namespace SlimRay.Data.Store.DB
{
    public class DBDataManager : IDataManager
    {
        public DBDataManager()
        {
            ExecutePlanBuildServer.Register(new SQLPlanBuilder());
            OperatorServer.Register(new ParserMSSQL());
        }

        public int GetInt(ISimpleData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(ISimpleData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public string GetString(ISimpleData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(ISimpleData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(ISimpleData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable(ISimpleData data, Expression expression)
        {
            IExecutePlan plan = ExecutePlanBuildServer.ActiveService.Build(data, expression);

            Helper.DBHelper helper = new Helper.DBHelper();

            return helper.GetDataTable((ISQLPlan)plan);
        }

        public DataRow GetDataRow(ISimpleData data, Expression expression)
        {
            IExecutePlan plan = ExecutePlanBuildServer.ActiveService.Build(data, expression);

            Helper.DBHelper helper = new Helper.DBHelper();

            return helper.GetDataRow((ISQLPlan)plan);
        }

        public IDataEntity GetEntity(ISimpleData data, Expression expression)
        {
            IExecutePlan plan = ExecutePlanBuildServer.ActiveService.Build(data, expression);

            Helper.DBHelper helper = new Helper.DBHelper();

            DataTable dt = helper.GetDataTable((ISQLPlan)plan);

            return dt.Rows.Count == 0 ? new DataEntity(null) : new DataEntity(dt.Rows[0]);
        }

        public bool Update(ISimpleData data, FieldValueCollection changedData)
        {
            throw new NotImplementedException();
        }
    }
}
