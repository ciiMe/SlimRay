using System.Data;
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
            throw new System.NotImplementedException();
        }

        public string GetValue(DataRequest request)
        {
            throw new System.NotImplementedException();
        }

        public bool Execute(DataRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
