using System.Data;

namespace SlimRay.Data
{
    public class TableManager : ITableManager
    {
        public DataTable LoadData(string tableName)
        {
            throw new System.NotImplementedException();
        }

        public DataTable LoadData(string tableName, int[] id)
        {
            throw new System.NotImplementedException();
        }

        public string LoadField(string tableName, string fieldName, int id)
        {
            throw new System.NotImplementedException();
        }

        public bool ExecuteDataRequest(UpdateRequest[] request)
        {
            throw new System.NotImplementedException();
        }
    }
}
