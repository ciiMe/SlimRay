using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.DB.DBFacory.MSSQL2000
{
    public class DBFactoryCreator_MSSQL2000 : ADBFactoryCreator
    {
        public DBFactoryCreator_MSSQL2000()
        {
            _ConnectionType = ValidDBConnectionType.MSSQLServer2000;
        }

        public override IDBFactory CreateNewFactory()
        {
             return new MSSQL2000.DBFactory_MSSQL2000();
        }
    }
}
