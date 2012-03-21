using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace SR.Data.DB.DBFacory.Items
{
    public class MSSQL2000DBFactoryItem : ADBFacoryItem
    {
        public MSSQL2000DBFactoryItem()
        {
            _ConnectionInfo = new MSSQL2000_ConnectionInfo();
        }

        public override DbConnection NewDBConnection(IConnectionInfo ci)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ci.ConnectionString;

            conn.Open();

            return conn;
        }

        public override DbDataAdapter NewDBDataAdapter(IConnectionInfo ci)
        {
            return new SqlDataAdapter();
        }

        public override DbCommand NewDBCommand(IConnectionInfo ci)
        {
            return new SqlCommand();
        }

        public override DbParameter NewDBParameter(IConnectionInfo ci)
        {
            return new SqlParameter();
        }
    }
}
