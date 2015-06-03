using System.Data;
using System.Data.SqlClient;

namespace SlimRay.DB.Helpers
{
    public class MSSQLHelper : IExecutor
    {
        public object GetResult(Request request)
        {
            SqlConnection conn = new SqlConnection(request.ExecutorParameter.HostAddress);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = request.Timeout;

            SqlDataReader reader = cmd.ExecuteReader();

            return reader.GetString(0);
        }

        public DataTable GetDataTable(Request request)
        {
            SqlDataAdapter adpter = new SqlDataAdapter(request.Command, request.ExecutorParameter.HostAddress);
            adpter.SelectCommand.CommandTimeout = request.Timeout;

            DataTable table = new DataTable();

            adpter.Fill(table);

            return table;
        }

        public int Execute(Request request)
        {
            SqlConnection conn = new SqlConnection(request.ExecutorParameter.HostAddress);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = request.Timeout;

            return cmd.ExecuteNonQuery();
        }
    }
}
