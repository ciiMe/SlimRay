using System.Data.OleDb;

namespace DBHelpers.Access
{
    /// <summary>
    /// The action that the request should executes. 
    /// An action may return single value, or return a DataTabel, or return the effected row count.
    /// </summary>
    delegate T AccessAction<T>(OleDbCommand cmd, string connString);
}
