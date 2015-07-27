using SlimRay.DB;
using System.Data;
using System.Data.OleDb;

namespace DBHelpers.Access
{
    /// <summary>
    /// An object can handel all sql requests.
    /// </summary>
    internal interface IAccessRequestHandler
    {
        object GetValue(OleDbCommand cmd, string connString);
        DataTable GetTabel(OleDbCommand cmd, string connString);
        DBAccessObjects GetWithTool(OleDbCommand cmd, string connString);

        int Execute(OleDbCommand cmd, string connString);
    }
}
