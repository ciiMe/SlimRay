using System.Data;

namespace SlimRay.Data
{
    public class TableManager : ITableManager
    {
        public void Add(string tableName)
        {

        }

        public void Remove(string tableName)
        {

        }

        public void AddColumn(string columnName)
        {

        }

        public void RemoveColumn(string columnName)
        {

        }

        public DataTable LoadData(string tableName)
        {
            return new DataTable();
        }

        public string LoadFieldData(string tableName, string fieldName)
        {
            return "";
        }

        public bool UpdateFieldData(string tableName, int id, string fieldName, string value)
        {
            return true;
        }
    }
}
