using System.Data;

namespace SlimRay.DB
{
    public interface IExecutor
    {
        object GetResult(Request plan);
        DataTable GetDataTable(Request plan);
        int Execute(Request plan);
    }
}
