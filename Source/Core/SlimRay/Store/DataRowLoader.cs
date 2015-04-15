using System;
using System.Data;
using SlimRay.UserData;

namespace SlimRay.Store
{
    public class DataRowLoader : IDataLoader
    {
        public DataRowLoader(IData data, DataRow row)
        {

        }

        public IDataEntity GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
