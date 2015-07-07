using System.Data;
using SlimRay.App;
using SlimRay.DB;

namespace SlimRay.Data.TabelData
{
    public class MSSQLAccessApp : IDataAccessApp
    {
        private DBRequest translateRequest(DataRequest request)
        {
            return new DBRequest(request.Address)
            {
                Command = buildCommand(request)
            };
        }

        private IExecutor getInstalledExecutor(DataRequest request)
        {
            IExecutor ex = AppGate.Instance.Get(request.Address.DataKey) as IExecutor;

            if (ex != null)
            {
                return ex;
            }

            throw new NoAppRegisterExceptioin(getNoExecutorErrMessage(request));
        }

        private string getNoExecutorErrMessage(DataRequest request)
        {
            return string.Format("App:{0} is not installed.", request.Address.DataKey);
        }

        private string buildCommand(DataRequest request)
        {
            string sql = "";

            switch (request.Target)
            {
                case DataTarget.Data:
                    {
                        return buildDataActionSQL(request);
                    } break;
                case DataTarget.Field:
                    {
                        return buildFieldActionSQL(request);
                    } break;
                case DataTarget.FieldValue:
                    {
                        return buildValueActionSQL(request);
                    } break;
            }

            return sql;
        }

        private string buildDataActionSQL(DataRequest request)
        {
            throw new System.NotImplementedException();
        }

        private string buildFieldActionSQL(DataRequest request)
        {
            throw new System.NotImplementedException();
        }

        private string buildValueActionSQL(DataRequest request)
        {
            switch (request.Action)
            {
                case DataAction.Get:
                    { } break;
                case DataAction.Add:
                    { } break;
                case DataAction.Remove:
                    { } break;
                case DataAction.Update:
                    { } break;
            }

            return "";
        }

        public DataTable GetTable(DataRequest request)
        {
            DBRequest r = translateRequest(request);
            IExecutor ex = getInstalledExecutor(request);

            return ex.GetDataTable(r);
        }

        public string GetValue(DataRequest request)
        {
            DBRequest r = translateRequest(request);
            IExecutor ex = AppGate.Instance.Get(request.Address.DataKey) as IExecutor;

            return ex.GetResult(r).ToString();
        }

        public bool Execute(DataRequest request)
        {
            DBRequest r = translateRequest(request);
            IExecutor ex = AppGate.Instance.Get(request.Address.DataKey) as IExecutor;

            return ex.Execute(r) > 0;
        }
    }
}
