using System;
using System.Data;

namespace SlimRay.Data.Store
{
    public interface IDataManager
    {
        int GetInt(IData data, Expression expr);
        double GetDouble(IData data, Expression expr);
        string GetString(IData data, Expression expr);
        bool GetBoolean(IData data, Expression expr);
        DateTime GetDateTime(IData data, Expression expr);

        DataTable GetDataTable(IData data, Expression expression);
        DataRow GetDataRow(IData data, Expression expression);

        IDataEntity GetEntity(IData data, Expression expression);

        bool Update(IData data, FieldValueCollection changedData);
    }
}
