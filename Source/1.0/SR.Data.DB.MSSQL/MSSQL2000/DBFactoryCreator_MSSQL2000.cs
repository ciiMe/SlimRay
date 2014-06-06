using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data.DB;
using SR.Data.DB.DBFacory;

namespace SR.Data.DB.External.MSSQL.MSSQL2000
{
    public class DBFactoryCreator_MSSQL2000 : ADBFactoryCreator
    {
        public DBFactoryCreator_MSSQL2000(bool isRegToSystem = true):base(isRegToSystem)
        {
            _ConnectionType = ValidDBConnectionType.MSSQLServer2000;
        }

        public override IDBFactory CreateNewFactory()
        {
             return new MSSQL2000.DBFactory_MSSQL2000();
        }
    }
}
