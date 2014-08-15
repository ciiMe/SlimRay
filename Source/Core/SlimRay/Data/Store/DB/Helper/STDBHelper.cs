using System;
using System.Data;
using System.Data.Common;

namespace SlimRay.Data.DB.Helper
{
    public abstract class STDBHelper : ADBHelper
    {
        private object __GetResultCMDUsing(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        private object __ExecuteCMDUsing(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        private object __GetDataTableAU(DbConnection conn, DbDataAdapter adpt)
        {
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            return dt;
        }

        private object __GetDataSetAU(DbConnection conn, DbDataAdapter adpt)
        {
            DataSet ds = new DataSet();

            adpt.Fill(ds);

            return ds;
        }

        public override object GetResult(ISQLPlan plan)
        {
            return __CallPreparedCommand(plan, __GetResultCMDUsing);
        }

        public override int Execute(ISQLPlan plan)
        {
            return Convert.ToInt32(__CallPreparedCommand(plan, __ExecuteCMDUsing));
        }

        public override DataRow GetDataRow(ISQLPlan plan)
        {
            DataRow dr;

            DataTable dt = __CallPreparedAdapter_Select(plan, __GetDataTableAU) as DataTable;

            if (dt.Rows.Count == 0)
            {
                dr = (DataRow)null;
            }
            else
            {
                dr = dt.Rows[0];
            }

            dt.Dispose();

            return dr;
        }

        public override DataTable GetDataTable(ISQLPlan plan)
        {
            return __CallPreparedAdapter_Select(plan, __GetDataTableAU) as DataTable;
        }

        public override DataSet GetDataSet(ISQLPlan plan)
        {
            return __CallPreparedAdapter_Select(plan, __GetDataSetAU) as DataSet;
        }
    }
}
