using SlimRay.App;
using SlimRay.DB;
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
        private IDBCommandTranslator _translator;

        public MSSQLHelper()
        {
            _name = "MSSQL";
            _description = "DB helper in MSSQL server.";
            _key = APPKEY;
            _version = "0.1";

            _handler = new SqlRequestHandler();
            _translator = new SqlCommandTranslator();
        }

        private void translateRequestToSqlCommand(DBRequest request, ref SqlCommand cmd)
        {
            cmd.CommandText = _translator.ToDBCommand(request);

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
                    //todo:log this error.
                    return default(T);
                }

                SqlCommand cmd = conn.CreateCommand();
                translateRequestToSqlCommand(request, ref cmd);

                try
                {
                    return action(cmd);
                }
                catch (Exception ex)
                {
                    //todo:log this error.
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
    }
}
