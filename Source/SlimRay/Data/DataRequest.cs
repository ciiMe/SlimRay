
namespace SlimRay.Data
{
    public struct DataRequest
    {
        public StorageAddress Address { get; set; }

        /// <summary>
        /// only data value canbe accessed.
        /// </summary>
        public DataTarget Target { get { return DataTarget.FieldValue; } }
        public DataAction Action { get; set; }

        public string DataName { get; set; }

        public string[] RequestFields { get; set; }
        public FieldValueCollection[] Parameters { get; set; }
    }

    public enum FieldType
    {
        Int,
        Char,
        Varchar,
        Nvarchar
    }

    public struct FieldValueCollection
    {
        public string FieldName { get; set; }
        public FieldType Type { get; set; }
        public string[] Values { get; set; }
    }
}
