using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.UserData;

namespace SlimRay.Designer.DataAccess
{
    public class Store : IStore
    {
        private List<IData> _systemData;

        public Store()
        {
            _systemData = new List<IData>();

            initSystemData();
        }

        private void initSystemData()
        {
            IData data;

            data = new UserData.Data("SystemData") { };
        }

        public UserData.IData[] Load()
        {
            throw new NotImplementedException();
        }

        public UserData.IData load(int id)
        {
            throw new NotImplementedException();
        }

        public UserData.IData load(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserData.IData data)
        {
            throw new NotImplementedException();
        }

        public bool Remove(UserData.IData data)
        {
            throw new NotImplementedException();
        }
    }
}
