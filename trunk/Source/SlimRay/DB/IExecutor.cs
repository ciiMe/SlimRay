using SlimRay.App;
using System.Data;

namespace SlimRay.DB
{
    public interface IExecutor : IAPP
    {
        object GetResult(DBRequest request);
        DataTable GetDataTable(DBRequest request);
        int Execute(DBRequest request);
    }
}
