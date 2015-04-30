using System;
using System.Collections.Generic;

using SlimRay.UserData;

namespace SlimRay.Designer.DataAccess
{
    public class Store : IStore
    {
        private static Store _instance = new Store();

        private List<IUserData> _systemData;

        public static Store Instance
        {
            get { return _instance; }
        }

        public Store()
        {
            initSystemData();
        }

        private void initSystemData()
        {
            Demo.SystemDataFiller sdf = new Demo.SystemDataFiller();
            _systemData = sdf.getAllSystemData();
        }

        public IUserData[] Load()
        {
            return _systemData.ToArray();
        }

        public IUserData Load(int id)
        {
            foreach (var data in _systemData)
            {
                if (data.ID == id)
                {
                    return data;
                }
            }

            return null;

        }

        public IUserData Load(string name)
        {
            name = name.ToLower().Trim();

            foreach (var data in _systemData)
            {
                if (data.Name.ToLower() == name)
                {
                    return data;
                }
            }

            return null;
        }

        public bool Update(IUserData data)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IUserData data)
        {
            throw new NotImplementedException();
        }
    }
}
