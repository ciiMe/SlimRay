using SlimRay.DB;
using System.Data;
using System.Data.OleDb;

namespace DBHelpers.Access
{
    internal class AccessRequestHandler : IAccessRequestHandler
    {
        public object GetValue(OleDbCommand cmd, string connString)
        {
            using (OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                return reader.Read() ? reader.GetValue(0) : null;
            }
        }

        public DataTable GetTabel(OleDbCommand cmd, string connString)
        {
            using (OleDbDataAdapter adpter = new OleDbDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adpter.Fill(dt);

                return dt;
            }
        }

        public DBAccessObjects GetWithTool(OleDbCommand cmd, string connString)
        {
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmd.CommandText, connString);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adpter);
            DataSet ds = new DataSet();
            adpter.Fill(ds);

            return new DBAccessObjects
            {
                Adapter = adpter,
                DataSet = ds
            };
        }

        public int Execute(OleDbCommand cmd, string connString)
        {
            return cmd.ExecuteNonQuery();
        }

    }
}
