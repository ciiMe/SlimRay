
namespace SlimRay.Data
{
    public struct UpdateRequest
    {
        public UpdateAction Action { get; set; }
        public UpdateTarget Target { get; set; }

        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string DataValue { get; set; }

        /// <summary>
        /// id of data which will be updated.
        /// </summary>
        public int Id { get; set; }
    }
}
