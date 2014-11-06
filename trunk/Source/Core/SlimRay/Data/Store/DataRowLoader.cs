using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace SlimRay.Data.Store
{
    public class DataRowLoader : IDataLoader
    {
        public DataRowLoader(ISimpleData data, DataRow row)
        {

        }

        public IDataEntity GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}
