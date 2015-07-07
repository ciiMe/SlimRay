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

            string err = string.Format("App:{0} is not installed.", request.Address.DataKey);
            throw new NoAppRegisterExceptioin(err);
        }

        private void throwNoAppException(DataRequest request)
        {
        }

        private string buildCommand(DataRequest request)
        {
            string sql = "";

            switch (request.Target)
            {
                case DataTarget.Data:
                    {
                    
                    } break;
                case DataTarget.Field:
                    {
                    
                    } break;
                case DataTarget.FieldValue:
                    {
                    
                    } break;
            }

            return sql;
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
