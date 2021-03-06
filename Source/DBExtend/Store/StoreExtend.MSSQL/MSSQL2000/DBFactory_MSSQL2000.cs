﻿using System;
using System.Data.Common;
using System.Data.SqlClient;

using SlimRay.Data.Store.DB;
using SlimRay.Data.Store.DB.DBFacory;

namespace SlimRay.Data.Store.DB.External.MSSQL.MSSQL2000
{
    public class DBFactory_MSSQL2000 : ADBFacory
    {
        public DBFactory_MSSQL2000()
        {
            _ConnectionType = ValidDBConnectionType.MSSQLServer2000;
        }

        public override DbConnection NewDBConnection(IConnectionInfo ci)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ci.ConnectionString;

            conn.Open();

            return conn;
        }

        public override DbDataAdapter NewDBDataAdapter()
        {
            return new SqlDataAdapter();
        }

        public override DbCommand NewDBCommand()
        {
            return new SqlCommand();
        }

        public override DbParameter NewDBParameter()
        {
            return new SqlParameter();
        }
    }
}
