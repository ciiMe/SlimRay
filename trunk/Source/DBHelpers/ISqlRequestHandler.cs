using System.Data;
using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{
    /// <summary>
    /// An object can handel all sql requests.
    /// </summary>
    internal interface ISqlRequestHandler
    {
        object GetValue(SqlCommand cmd);
        DataTable GetTabel(SqlCommand cmd);
        int Execute(SqlCommand cmd);
    }
}
