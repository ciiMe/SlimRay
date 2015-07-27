using SlimRay.App;
using SlimRay.DB;
using SlimRay.Log;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{
    public class MSSQLHelper : BaseApp, IExecutor
    {
        public const string APPKEY = "SlimRay.DB.Helpers.MSSQLHelper";
        public const string DefaultConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";

        private ISqlRequestHandler _handler;

        public MSSQLHelper()
        {
            _name = "MSSQL";
            _description = "DB helper in MSSQL server.";
            _key = APPKEY;
            _version = "0.1";

            _handler = new SqlRequestHandler();
        }

        private void translateRequestToSqlCommand(DBRequest request, ref SqlCommand cmd)
        {
            cmd.CommandText = request.Command;

            foreach (var p in request.Parameters)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }

            cmd.CommandTimeout = request.Timeout;
        }

        private T executeRequest<T>(DBRequest request, SqlAction<T> action)
        {
            using (SqlConnection conn = new SqlConnection(request.ExecutorParameter.Address))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    LogWritter.Instance.Error(ex.Message);
                    LogWritter.Instance.Error(ex.StackTrace);
                    return default(T);
                }

                SqlCommand cmd = conn.CreateCommand();
                translateRequestToSqlCommand(request, ref cmd);

                try
                {
                    return action(cmd, request.ExecutorParameter.Address);
                }
                catch (Exception ex)
                {
                    LogWritter.Instance.Error(ex.Message);
                    LogWritter.Instance.Error(ex.StackTrace);
                    return default(T);
                }
            }
        }

        public object GetResult(DBRequest request)
        {
            return executeRequest<object>(request, _handler.GetValue);
        }

        public DataTable GetDataTable(DBRequest request)
        {
            return executeRequest<DataTable>(request, _handler.GetTabel);
        }

        public int Execute(DBRequest request)
        {
            return executeRequest<int>(request, _handler.Execute);
        }

        public DBAccessObjects GetWithTool(DBRequest request)
        {
            return executeRequest<DBAccessObjects>(request, _handler.GetWithTool);
        }
    }
}
