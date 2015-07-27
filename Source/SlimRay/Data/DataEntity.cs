
namespace SlimRay.Data
{
    public struct DataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DataEntityField[] Fields { get; set; }

        public StorageAddress Address { get; set; }
    }
}
