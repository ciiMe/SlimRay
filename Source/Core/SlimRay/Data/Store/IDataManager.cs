using System;
using System.Data;

namespace SlimRay.Data.Store
{
    public interface IDataManager
    {
        int GetInt(ISimpleData data, Expression expr);
        double GetDouble(ISimpleData data, Expression expr);

        string GetString(ISimpleData data, Expression expr);

        bool GetBoolean(ISimpleData data, Expression expr);

        DateTime GetDateTime(ISimpleData data, Expression expr);

        DataTable GetDataTable(ISimpleData data, Expression expression);
        DataRow GetDataRow(ISimpleData data, Expression expression);

        IDataEntity GetEntity(ISimpleData data, Expression expression);

        bool Update(ISimpleData data, FieldValueCollection changedData);
    }
}
