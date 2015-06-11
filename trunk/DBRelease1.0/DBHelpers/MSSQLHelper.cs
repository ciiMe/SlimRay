using SlimRay.DB;
using System.Data;
using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{
    public class MSSQLHelper : IExecutor
    {
        private const string _name = "MSSQL";
        private const string _description = "DB helper in MSSQL server.";
        private const string _key = "SlimRay.DB.Helpers.MSSQLHelper";

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetKey()
        {
            return _key;
        }

        public object GetResult(DBRequest request)
        {
            SqlConnection conn = new SqlConnection(request.ExecutorParameter.HostAddress);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = request.Timeout;

            SqlDataReader reader = cmd.ExecuteReader();

            return reader.GetString(0);
        }

        public DataTable GetDataTable(DBRequest request)
        {
            SqlDataAdapter adpter = new SqlDataAdapter(request.Command, request.ExecutorParameter.HostAddress);
            adpter.SelectCommand.CommandTimeout = request.Timeout;

            DataTable table = new DataTable();

            adpter.Fill(table);

            return table;
        }

        public int Execute(DBRequest request)
        {
            SqlConnection conn = new SqlConnection(request.ExecutorParameter.HostAddress);
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = request.Timeout;

            return cmd.ExecuteNonQuery();
        }

        public void Execute(string parameter)
        {

        }
    }
}
