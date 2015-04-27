using System;
using System.Collections.Generic;

using SlimRay.UserData;

namespace SlimRay.Designer.DataAccess
{
    public class Store : IStore
    {
        private static Store _instance = new Store();

        private List<IData> _systemData;

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

        public IData[] Load()
        {
            return _systemData.ToArray();
        }

        public IData Load(int id)
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

        public IData Load(string name)
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
