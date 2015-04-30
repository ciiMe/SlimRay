using SlimRay.UserData;
using System;

namespace SlimRay.Store.PlainText.XML
{
    class XMLDataManager : IDataManager
    {
        public int GetInt(IUserData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(IUserData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public string GetString(IUserData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(IUserData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(IUserData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetDataTable(IUserData data, Expression expression)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataRow GetDataRow(IUserData data, Expression expression)
        {
            throw new NotImplementedException();
        }

        public IDataEntity GetEntity(IUserData data, Expression expression)
        {
            throw new NotImplementedException();
        }

        public bool Update(IUserData data, FieldValueCollection changedData)
        {
            throw new NotImplementedException();
        }
    }
}
