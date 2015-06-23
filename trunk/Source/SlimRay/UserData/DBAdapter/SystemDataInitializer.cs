using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.UserData.DBAdapter
{
    public class SystemDataInitializer
    {
        public void LoadSystemDataTable()
        {
            SystemTables.UserDataStorage = new TableUserDataStorage 
            {
                TableName = "sys_UserDataStorage",

                UserDataNameFieldName ="UserDataName",
                AddressKeyFieldName ="AddressType",
                AddressFieldName = "Address"
            };
        }
    }
}
