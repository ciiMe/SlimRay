using SlimRay.Data;

namespace SlimRay.UserData.DBAdapter
{
    //todo: who initialize it?
    public class DataTableNameEntity
    {
        public string TableName { get; set; }
    }

    /// <summary>
    /// system datatable list data will be keeped here after loading from config file.
    /// </summary>
    public static class SystemTables
    {
        public static TableUserDataStorage UserDataStorage { get; set; }

        public static TableUserData UserData { get; set; }
        public static TableUserDataFields UserDataFields { get; set; }
        public static TableUserDataLink UserDataLink { get; set; }

        /// <summary>
        /// get the table name where the data saved.
        /// </summary>
        public static DataTableNameEntity GetMappedTable(string dataName)
        {
            //todo: need to complete it.
            return new DataTableNameEntity();
        }
    }

    /// <summary>
    /// userdata's storage address is saved in this table.
    /// </summary>
    public class TableUserDataStorage : DataTableNameEntity
    {
        public string UserDataNameFieldName { get; set; }
        public string AddressKeyFieldName { get; set; }
        public string AddressFieldName { get; set; }
    }

    /// <summary>
    /// this table stores all userdata.
    /// </summary>
    public class TableUserData : DataTableNameEntity
    {
        public string IDFieldName { get; set; }
        public string NameFieldName { get; set; }
        public string DescriptionFieldName { get; set; }
    }

    /// <summary>
    /// this table stores the fields of a userdata.
    /// </summary>
    public class TableUserDataFields : DataTableNameEntity
    {
        public string DataIDFieldName { get; set; }

        public string IDFieldName { get; set; }
        public string NameFieldName { get; set; }
        public string DescriptionFieldName { get; set; }
        public string TypeFieldName { get; set; }
    }

    /// <summary>
    /// this table stores the linked fields of a userdata.
    /// </summary>
    public class TableUserDataLink : DataTableNameEntity
    {
        public string DataIDFieldName { get; set; }
        public string FieldIDFieldName { get; set; }
        public string RelationFieldName { get; set; }
        public string LinkedDataIDFieldName { get; set; }
        public string LinkedFieldIDFieldName { get; set; }
    }
}
