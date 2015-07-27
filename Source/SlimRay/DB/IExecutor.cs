using SlimRay.App;
using System.Data;
using System.Data.Common;

namespace SlimRay.DB
{
    public interface IExecutor : IAPP
    {
        object GetResult(DBRequest request);
        DataTable GetDataTable(DBRequest request);
        DBAccessObjects GetWithTool(DBRequest request);

        int Execute(DBRequest request);
    }

    public struct DBAccessObjects
    {
        public DataAdapter Adapter { get; set; }
        public DataSet DataSet { get; set; }
    }
}
