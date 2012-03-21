using System;

namespace SR.Data.DB.DBFacory
{
    public static class DBFactoryItemMap
    {
        /// <summary>
        /// 根据 ValidDBConnectionType 来创建特定的类的实例
        /// </summary>
        /// <param name="ct">ValidDBConnectionType中的类型</param>
        /// <returns></returns>
        public static IDBFactoryItem NewInstance(IConnectionInfo ci)
        {
            IDBFactoryItem i = null;

            switch (ci.ConnectionType)
            {
                case ValidDBConnectionType.MSSQLServer2000:
                    {
                        i = new Items.MSSQL2000DBFactoryItem();

                        (i.ConnectionInfo as MSSQL2000_ConnectionInfo).HostAddress = (ci as MSSQL2000_ConnectionInfo).HostAddress;
                        (i.ConnectionInfo as MSSQL2000_ConnectionInfo).Port = (ci as MSSQL2000_ConnectionInfo).Port;

                        (i.ConnectionInfo as MSSQL2000_ConnectionInfo).Catalog = (ci as MSSQL2000_ConnectionInfo).Catalog;

                        (i.ConnectionInfo as MSSQL2000_ConnectionInfo).UserName = (ci as MSSQL2000_ConnectionInfo).UserName;
                        (i.ConnectionInfo as MSSQL2000_ConnectionInfo).Password = (ci as MSSQL2000_ConnectionInfo).Password;

                        return i;
                    }

                default:
                    {
                        throw new Exception("No DBFacory item is fit.");
                    }
            }
        }
    }
}
