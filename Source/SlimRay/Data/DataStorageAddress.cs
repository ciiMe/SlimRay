
namespace SlimRay.Data
{
    public interface IDataStorageAddress
    {
        /// <summary>
        /// the key of app that can read/write this data.
        /// </summary>
        string AppKey { get; set; }

        /// <summary>
        /// the address where data saved.
        /// </summary>
        string Address { get; set; }
    }

    public class DataStorageAddress : IDataStorageAddress
    {
        private string _appKey;
        private string _address;

        public string AppKey
        {
            get { return _appKey; }
            set { _appKey = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
