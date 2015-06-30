
namespace SlimRay.Data
{
    public struct UpdateRequest
    {
        UpdateAction Action { get; set; }
        UpdateTarget Target { get; set; }

        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string DataValue { get; set; }

        //todo:how to locate this data?
        public string Expression { get; set; }
    }
}
