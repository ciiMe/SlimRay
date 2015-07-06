
namespace SlimRay.Data
{
    public struct DataRequest
    {
        public StorageAddress Address { get; set; }

        public DataAction Action { get; set; }
        public DataTarget Target { get; set; }

        public string DataName { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// id of data which will be updated.
        /// </summary>
        public int DataId { get; set; }
    }
}
