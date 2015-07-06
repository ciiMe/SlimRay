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

        private string buildCommand(DataRequest request)
        {
            string sql = "";

            switch (request.Action)
            {
                case DataAction.Get:
                    { } break;
                case DataAction.Add:
                    { } break;
                case DataAction.Update:
                    { } break;
                case DataAction.Remove:
                    { } break;
            }

            return sql;
        }

        public DataTable GetTable(DataRequest request)
        {
            DBRequest r = translateRequest(request);
            IExecutor ex = AppGate.Instance.Get(request.Address.DataKey) as IExecutor;

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
