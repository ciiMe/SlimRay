
using SR.Data.DB;
using SR.Data.DB.DBFacory;

namespace SR.Data.DB.External.MySQL.MySQL
{
    public class DBFactoryCreator_MySQL : ADBFactoryCreator
    {
        public DBFactoryCreator_MySQL()
        {
            _ConnectionType = ValidDBConnectionType.MySQL;
        }

        public override IDBFactory CreateNewFactory()
        {
            return new DBFacory_MySQL();
        }
    }
}
