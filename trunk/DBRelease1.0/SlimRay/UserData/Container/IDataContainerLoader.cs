using System;
using System.Data;

namespace SlimRay.UserData.Container
{
    public interface IDataContainerLoader
    {
        int GetInt(IUserData data, Expression expr);
        double GetDouble(IUserData data, Expression expr);
        string GetString(IUserData data, Expression expr);
        bool GetBoolean(IUserData data, Expression expr);
        DateTime GetDateTime(IUserData data, Expression expr);

        DataTable GetDataTable(IUserData data, Expression expression);
        DataRow GetDataRow(IUserData data, Expression expression);

        IDataContainer GetEntity(IUserData data, Expression expression);

        bool Update(IUserData data, FieldValueCollection changedData);
    }
}
