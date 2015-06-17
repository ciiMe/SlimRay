
namespace SlimRay.UserData.Adapter
{
    /// <summary>
    /// this table stores all userdata.
    /// </summary>
    public struct TableUserData
    {
        public string TableName { get; set; }

        public string IDFieldName { get; set; }
        public string NameFieldName { get; set; }
        public string DescriptionFieldName { get; set; }
    }

    /// <summary>
    /// this table stores the fields of a userdata.
    /// </summary>
    public struct TableUserDataFIelds
    {
        public string TableName { get; set; }

        public string DataIDFieldName { get; set; }

        public string IDFieldName { get; set; }
        public string NameFieldName { get; set; }
        public string DescriptionFieldName { get; set; }
        public string TypeFieldName { get; set; }
    }

    /// <summary>
    /// this table stores the linked fields of a userdata.
    /// </summary>
    public struct TableUserDataLink
    {
        public string TableName { get; set; }

        public string DataIDFieldName { get; set; }
        public string FieldIDFieldName { get; set; }
        public string RelationFieldName { get; set; }
        public string LinkedDataIDFieldName { get; set; }
        public string LinkedFieldIDFieldName { get; set; }
    }

    /// <summary>
    /// userdata's storage address is saved in this table.
    /// </summary>
    public struct TableUserDataStorage
    {
        public string TableName { get; set; }

        public string UserDataIDFieldName { get; set; }
        public string AddressKeyFieldName { get; set; }
        public string AddressFieldName { get; set; }
    }
}
