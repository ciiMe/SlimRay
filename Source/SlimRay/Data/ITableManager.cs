using System.Data;

namespace SlimRay.Data
{
    public interface ITableManager
    {
        void Add(string tableName);
        void Remove(string tableName);

        void AddColumn(string columnName);
        void RemoveColumn(string columnName);

        DataTable LoadData(string tableName);
        string LoadFieldData(string tableName, string fieldName);
        bool UpdateFieldData(string tableName, int id, string fieldName, string value);
    }
}
