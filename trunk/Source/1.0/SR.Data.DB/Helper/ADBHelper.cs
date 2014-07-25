/*
 * 数据操作的传递类，通过该类，将IExecutePlan中的操作传递给dbxxx的部件。 
 *
 * 每一个函数使用一套数据库操作部件，函数执行完毕将销毁部件。
 * 这样的工作模式被设计成是线程安全的。以保证每一个函数都线程安全。
 */
using System.Data;
using System.Data.Common;

using System.Collections.Generic;

using SR.Data.DB.DBFacory;

namespace SR.Data.DB.Helper
{
    /// <summary>
    /// 传递一个连接到db的DbCommand供调用者使用
    /// </summary>
    /// <param name="cmd"></param>
    /// <returns></returns>
    public delegate object PreparedCommandUsing(DbCommand cmd);

    /// <summary>
    /// 传递准备好做select动作的DbDataAdapter，供调用者使用
    /// </summary>
    /// <param name="conn"></param>
    /// <param name="adpt"></param>
    /// <returns></returns>
    public delegate object PreparedAdapterUsing(DbConnection conn, DbDataAdapter adpt);

    /// <summary>
    /// 提供基本的处理参数，的方法，
    /// </summary>
    public abstract class ADBHelper : IDBHelper
    {
        protected void _FillSQLTextAndParametersIntoDBCommand(DbCommand cmd, ISQLPlan plan)
        {
            cmd.Parameters.Clear();

            foreach (KeyValuePair<string, object> i in plan.Parameters)
            {
                cmd.Parameters.Add(DBFacoryPool.Instance.NewDBParameter(plan.ConnectionInfo, i.Key, i.Value));
            }

            cmd.CommandText = plan.CommandText;
        }

        protected DbConnection _GetPreparedConn(ISQLPlan plan)
        {
            return DBFacoryPool.Instance.NewDBConnection(plan.ConnectionInfo);
        }

        protected object __CallPreparedCommand(ISQLPlan plan, PreparedCommandUsing cu)
        {
            using (DbConnection conn = _GetPreparedConn(plan))
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    _FillSQLTextAndParametersIntoDBCommand(cmd, plan);

                    return cu(cmd);
                }
            }
        }

        protected object __CallPreparedAdapter_Select(ISQLPlan plan, PreparedAdapterUsing au)
        {
            using (DbConnection conn = _GetPreparedConn(plan))
            {
                using (DbDataAdapter adpt = DBFacoryPool.Instance.NewDBDataAdapter(plan.ConnectionInfo))
                {
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        _FillSQLTextAndParametersIntoDBCommand(cmd, plan);

                        adpt.SelectCommand = cmd;
                        return au(conn, adpt);
                    }
                }
            }
        }

        public abstract object GetResult(ISQLPlan plan);

        public abstract DataRow GetDataRow(ISQLPlan plan);

        public abstract DataTable GetDataTable(ISQLPlan plan);

        public abstract DataSet GetDataSet(ISQLPlan plan);

        public abstract int Execute(ISQLPlan plan);
    }
}
