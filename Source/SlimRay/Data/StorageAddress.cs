
namespace SlimRay.Data
{
    public struct StorageAddress : IDataAddress
    {
        private string _dataKey;
        private string _address;

        /* 
         * the key of data, the DataAccessApp will take this key to say they can handel this kind of data.
         */
        public string DataKey
        {
            get { return _dataKey; }
            set { _dataKey = value; }
        }

        /*
         * the address where the command execute at.
         * this is a virtual address, it can be any type of address such as
         * db server
         * ip address
         * file name
         * etc...
         */
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}


