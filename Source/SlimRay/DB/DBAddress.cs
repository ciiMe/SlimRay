using SlimRay.Data;

namespace SlimRay.DB
{
    public struct DBAddress : IDataAddress
    {
        /// <summary>
        /// the key should be unquie flag of this data.
        /// </summary>
        public string DataKey { get; set; }

        /// <summary>
        /// the address should be connection string.
        /// </summary>
        public string Address { get; set; }
    }
}
