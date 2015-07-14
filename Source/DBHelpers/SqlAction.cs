using System.Data.SqlClient;

namespace DBHelpers.MSSQL
{
    /// <summary>
    /// The action that the request should executes. 
    /// An action may return single value, or return a DataTabel, or return the effected row count.
    /// </summary>
    delegate T SqlAction<T>(SqlCommand cmd);
}
