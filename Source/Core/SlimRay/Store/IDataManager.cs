using SlimRay.UserData;
using System;
using System.Data;

namespace SlimRay.Store
{
    public interface IDataManager
    {
        int GetInt(IUserData data, Expression expr);
        double GetDouble(IUserData data, Expression expr);
        string GetString(IUserData data, Expression expr);
        bool GetBoolean(IUserData data, Expression expr);
        DateTime GetDateTime(IUserData data, Expression expr);

        DataTable GetDataTable(IUserData data, Expression expression);
        DataRow GetDataRow(IUserData data, Expression expression);

        IDataEntity GetEntity(IUserData data, Expression expression);

        bool Update(IUserData data, FieldValueCollection changedData);
    }
}
