using SlimRay.UserData;

namespace SlimRay.Store
{
    public class SimpleStore : IStore
    {
        private static IStore _instance;
        public static IStore Instance
        {
            get
            {
                return _instance == null ? _instance = new SimpleStore() : _instance;
            }
        }

        public void SetStorageType(StorageType stype)
        {
            throw new System.NotImplementedException();
        }

        public void AssignStorageType(IUserData data, StorageAddress address)
        {
            throw new System.NotImplementedException();
        }

        public void InsertNewRecord(IDataEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataEntity LoadRecord(string dataName, string key)
        {
            throw new System.NotImplementedException();
        }

        public IDataEntity LoadRecord(Expression expression)
        {
            throw new System.NotImplementedException();
        }
    }
}
