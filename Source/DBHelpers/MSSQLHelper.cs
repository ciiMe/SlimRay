using SlimRay.App;
using SlimRay.DB;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{
    public class MSSQLHelper : BaseApp, IExecutor
    {
        public MSSQLHelper()
        {
            _name = "MSSQL";
            _description = "DB helper in MSSQL server.";
            _key = "SlimRay.DB.Helpers.MSSQLHelper";
            _version = "0.1";
        }

        public object GetResult(DBRequest request)
        {
            SqlConnection conn = new SqlConnection(request.ExecutorParameter.Address);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                //todo:log this error.
                return null;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = request.Timeout;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                return reader.GetString(0);
            }
            catch (Exception ex)
            {
                //todo:log this error.
                return null;
            }
        }

        public DataTable GetDataTable(DBRequest request)
        {
            SqlDataAdapter adpter = new SqlDataAdapter(request.Command, request.ExecutorParameter.Address);
            adpter.SelectCommand.CommandTimeout = request.Timeout;

            DataTable table = new DataTable();

            try
            {
                adpter.Fill(table);
            }
            catch (Exception ex)
            {
                //todo:log this error.
                return null;
            }

            return table;
        }

        public int Execute(DBRequest request)
        {
            SqlConnection conn = new SqlConnection(request.ExecutorParameter.Address);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                //todo:log this error.
                return -1;
            }

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandTimeout = request.Timeout;

            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //todo:log this error.
                return -1;
            }
        }
    }
}
