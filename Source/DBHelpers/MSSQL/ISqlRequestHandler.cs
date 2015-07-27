using SlimRay.DB;
using System.Data;
using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{
    /// <summary>
    /// An object can handel all sql requests.
    /// </summary>
    internal interface ISqlRequestHandler
    {
        object GetValue(SqlCommand cmd, string connString);
        DataTable GetTabel(SqlCommand cmd, string connString);
        DBAccessObjects GetWithTool(SqlCommand cmd, string connString);

        int Execute(SqlCommand cmd, string connString);
    }
}
