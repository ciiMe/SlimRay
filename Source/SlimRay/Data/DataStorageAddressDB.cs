
namespace SlimRay.Data
{
    public interface IDataStorageAddressDB : IDataStorageAddress
    {
        /// <summary>
        /// the data table where data saved.
        /// </summary>
        string TableName { get; set; }
    }

    public class DataStorageAddressDB : IDataStorageAddressDB
    {
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public string AppKey
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public string Address
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
