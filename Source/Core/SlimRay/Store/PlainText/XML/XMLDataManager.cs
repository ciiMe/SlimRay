using SlimRay.UserData;
using System;

namespace SlimRay.Store.PlainText.XML
{
    class XMLDataManager : IDataManager
    {
        public int GetInt(IData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(IData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public string GetString(IData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolean(IData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(IData data, Expression expr)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable GetDataTable(IData data, Expression expression)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataRow GetDataRow(IData data, Expression expression)
        {
            throw new NotImplementedException();
        }

        public IDataEntity GetEntity(IData data, Expression expression)
        {
            throw new NotImplementedException();
        }

        public bool Update(IData data, FieldValueCollection changedData)
        {
            throw new NotImplementedException();
        }
    }
}
