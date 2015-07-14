using System.Data;
using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{    
    internal class SqlRequestHandler : ISqlRequestHandler
    {
        public object GetValue(SqlCommand cmd)
        {
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                return reader.Read() ? reader.GetValue(0) : null;
            }
        }

        public DataTable GetTabel(SqlCommand cmd)
        {
            using (SqlDataAdapter adpter = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adpter.Fill(dt);

                return dt;
            }
        }

        public int Execute(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }
    }
}
