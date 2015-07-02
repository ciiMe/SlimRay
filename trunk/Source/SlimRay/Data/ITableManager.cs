using System.Data;

namespace SlimRay.Data
{
    public interface ITableManager
    {
        DataTable LoadData(string tableName);
        DataTable LoadData(string tableName, int[] id);
        string LoadField(string tableName, string fieldName, int id);
        
        bool ExecuteDataRequest(UpdateRequest[] request);
    }
}
