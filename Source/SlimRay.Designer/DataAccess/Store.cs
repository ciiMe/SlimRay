using System;
using System.Collections.Generic;

using SlimRay.UserData;

namespace SlimRay.Designer.DataAccess
{
    public class Store : IStore
    {
        private List<IData> _systemData;

        public Store()
        {
            initSystemData();
        }

        private void initSystemData()
        {
            Demo.SystemDataFiller sdf = new Demo.SystemDataFiller();
            _systemData = sdf.getAllSystemData();
        }

        public IData[] Load()
        {
            return _systemData.ToArray();
        }

        public IData load(int id)
        {
            throw new NotImplementedException();
        }

        public IData load(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(IData data)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IData data)
        {
            throw new NotImplementedException();
        }
    }
}
