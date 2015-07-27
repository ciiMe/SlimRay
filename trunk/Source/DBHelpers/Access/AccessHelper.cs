using SlimRay.App;
using SlimRay.DB;
using SlimRay.Log;
using System;
using System.Data;
using System.Data.OleDb;

namespace DBHelpers.Access
{
    public class AccessHelper : BaseApp, IExecutor
    {
        public const string APPKEY = "SlimRay.DB.Helpers.AccessHelper";
        public const string DefaultConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0 ;Data Source=F:\\web\\notesbook\\class\\leavenotes.mdb";

        private IAccessRequestHandler _handler;

        public AccessHelper()
        {
            _name = "MSSQL";
            _description = "DB helper in MSSQL server.";
            _key = APPKEY;
            _version = "0.1";

            _handler = new AccessRequestHandler();
        }

        private void translateRequestToSqlCommand(DBRequest request, ref OleDbCommand cmd)
        {
            cmd.CommandText = request.Command;

            foreach (var p in request.Parameters)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value);
            }

            cmd.CommandTimeout = request.Timeout;
        }

        private T executeRequest<T>(DBRequest request, AccessAction<T> action)
        {
            using (OleDbConnection conn = new OleDbConnection(request.ExecutorParameter.Address))
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

                OleDbCommand cmd = conn.CreateCommand();
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
