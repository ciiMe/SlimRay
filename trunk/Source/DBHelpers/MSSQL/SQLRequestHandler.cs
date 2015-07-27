using SlimRay.DB;
using System.Data;
using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{
    internal class SqlRequestHandler : ISqlRequestHandler
    {
        public object GetValue(SqlCommand cmd, string connString)
        {
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                return reader.Read() ? reader.GetValue(0) : null;
            }
        }

        public DataTable GetTabel(SqlCommand cmd, string connString)
        {
            using (SqlDataAdapter adpter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adpter.Fill(dt);

                return dt;
            }
        }

        public DBAccessObjects GetWithTool(SqlCommand cmd, string connString)
        {
            SqlDataAdapter adpter = new SqlDataAdapter(cmd.CommandText, connString);
            SqlCommandBuilder builder = new SqlCommandBuilder(adpter);
            DataSet ds = new DataSet();
            adpter.Fill(ds);

            return new DBAccessObjects
            {
                Adapter = adpter,
                DataSet = ds
            };
        }

        public int Execute(SqlCommand cmd, string connString)
        {
            return cmd.ExecuteNonQuery();
        }

    }
}
