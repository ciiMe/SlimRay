using System;

namespace SlimRay.UserData.DBAdapter
{
    public class UserDataHelper : IUserDataHelper
    {
        public IUserData[] GetData()
        {
            throw new NotImplementedException();
        }

        public IUserData GetData(string dataName)
        {
            throw new NotImplementedException();
        }

        public IUserData[] GetLinkedData(string dataName)
        {
            throw new NotImplementedException();
        }

        public bool AddData(string name, string description)
        {
            throw new NotImplementedException();
        }

        public bool UpdateData(string dataName, IUserData data)
        {
            throw new NotImplementedException();
        }

        public bool RemoveData(string name)
        {
            throw new NotImplementedException();
        }

        public IUserField[] GetFields(string dataName)
        {
            throw new NotImplementedException();
        }

        public IUserField GetField(string dataName, string fieldName)
        {
            throw new NotImplementedException();
        }

        public bool AddField(string dataName, IUserField fieldData)
        {
            throw new NotImplementedException();
        }

        public bool RemoveField(string dataName, string fieldName)
        {
            throw new NotImplementedException();
        }

        public bool UpdateField(string dataName, string fieldName, IUserField fieldData)
        {
            throw new NotImplementedException();
        }
    }
}
