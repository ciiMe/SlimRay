
namespace SlimRay.UserData.DBAdapter
{
    public class SystemDataInitializer
    {
        public void LoadSystemDataTable()
        {
            SystemTables.UserData = new TableUserData
            {
                TableName = "sys_UserData",

                IDFieldName = "ID",
                NameFieldName = "Name",
                DescriptionFieldName = "Description"
            };

            SystemTables.UserDataFields = new TableUserDataFields
            {
                TableName = "sys_UserDataFields",

                IDFieldName = "ID",
                DataIDFieldName = "UserDataID",

                NameFieldName = "Name",
                DescriptionFieldName = "Description",
                TypeFieldName = "DataType"
            };

            SystemTables.UserDataLink = new TableUserDataLink
            {
                TableName = "sys_UserDataLinks",

                DataIDFieldName = "DataID",
                FieldIDFieldName = "FieldID",

                LinkedDataIDFieldName = "LinkedDataID",
                LinkedFieldIDFieldName = "LinkedFieldID",

                RelationFieldName = "LinkedFieldRelation"
            };

            SystemTables.UserDataStorage = new TableUserDataStorage
            {
                TableName = "sys_UserDataStorage",

                UserDataNameFieldName = "UserDataName",
                AddressKeyFieldName = "AddressType",
                AddressFieldName = "Address"
            };
        }
    }
}
