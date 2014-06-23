using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data.Entity;

namespace SR.Data
{
    public class DataProvider
    {
        private static DataProvider _instance;
        private Entity.DataTypes _dataTypeEntities;

        public static DataProvider Instance
        {
            get
            {
                return _instance == null ? _instance = new DataProvider() : _instance;
            }
        }

        public DataTypes DataTypeEntities
        {
            get { return _dataTypeEntities; }
        }

        private Dictionary<int, IDataType> _allDataTypes = new Dictionary<int, IDataType>();

        public DataProvider()
        {
            _dataTypeEntities = new DataTypes();
        }

        public bool Register(IDataType datatype)
        {
            if (_allDataTypes.ContainsKey(datatype.Key))
            {
                return false;
            }

            _allDataTypes.Add(datatype.Key, datatype);

            return true;
        }

        public void Unregister(IDataType datatype)
        {
            if (!_allDataTypes.ContainsKey(datatype.Key))
            {
                return;
            }

            _allDataTypes.Remove(datatype.Key);
        }

        public void Unregister(int level)
        {
            if (_allDataTypes.Values.Count == 0)
            {
                return;
            }

            lock (_allDataTypes)
            {
                IDataType[] all = new IDataType[_allDataTypes.Values.Count];
                _allDataTypes.Values.CopyTo(all, 0);

                foreach (IDataType dt in all)
                {
                    if (dt.Level != level)
                    {
                        continue;
                    }

                    _allDataTypes.Remove(dt.Key);
                }
            }
        }

        public IDataType[] GetAll()
        {
            IDataType[] re = new IDataType[_allDataTypes.Values.Count];
            _allDataTypes.Values.CopyTo(re, 0);

            return re;
        }

        internal IDataType GetDataType(int key)
        {
            return _allDataTypes.ContainsKey(key) ? _allDataTypes[key] : null;
        }
    }

    internal class SystemDataProvideHelper
    {
        internal void SystemDataTypesRegister()
        {
            DataProvider.Instance.Register(new SRInt());
            DataProvider.Instance.Register(new SRString());
        }

        internal void SystemDataTypesUnregister()
        {
            DataProvider.Instance.Unregister(Constants.DataTypes.DATA_TYPE_LEVEL_SYSTEM);
        }
    }
}
