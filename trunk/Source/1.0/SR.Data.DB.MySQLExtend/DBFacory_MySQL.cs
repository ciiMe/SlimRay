
using System.Data.Common;

using SR.Data.DB;
using SR.Data.DB.DBFacory;
using MySql.Data.MySqlClient;

namespace SR.Data.DB.External.MySQL.MySQL
{
        public class DBFacory_MySQL : ADBFacory
        {
            public DBFacory_MySQL()
            {
                _ConnectionType = ValidDBConnectionType.MySQL;
            }

            public override DbConnection NewDBConnection(IConnectionInfo ci)
            {
                MySqlConnection conn = new MySqlConnection();

                conn.ConnectionString = ci.ConnectionString;

                conn.Open();

                return conn;
            }

            public override DbDataAdapter NewDBDataAdapter()
            {
                return new MySqlDataAdapter();
            }

            public override DbCommand NewDBCommand()
            {
                return new MySqlCommand();
            }

            public override DbParameter NewDBParameter()
            {
                return new MySqlParameter();
            }
        }

}
