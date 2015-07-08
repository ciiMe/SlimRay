using System.Data;

namespace SlimRay.Data
{
    public class DataHelper
    {
        private DataRequest buildRequest(string dataName)
        {
            StorageHelper shelper = new StorageHelper();
            StorageAddress address = shelper.GetStorageAddress(dataName);

            return new DataRequest
             {
                 Action = DataAction.Get,
                 Address = address,
                 DataName = dataName
             };
        }

        private string[] getDataFields()
        {
            throw new System.NotImplementedException();
        }

        private string getIdFieldName()
        {
            throw new System.NotImplementedException();
        }

        public DataTable LoadData(string dataName)
        {
            DataRequest request = buildRequest(dataName);
            request.RequestFields = getDataFields();

            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(request.Address.DataKey);

            return app.GetTable(request);
        }

        public DataTable LoadData(string dataName, string[] id)
        {
            DataRequest request = buildRequest(dataName);
            request.RequestFields = getDataFields();
            request.Parameters = new FieldValueCollection[] { 
            new FieldValueCollection {
                FieldName = getIdFieldName(),
                Type = FieldType.Int,
                Values =id
            }
            };
            //todo: attatch id and other parameters.
            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(request.Address.DataKey);

            return app.GetTable(request);
        }

        public string LoadField(string dataName, string fieldName, int id)
        {
            DataRequest request = buildRequest(dataName);
            request.RequestFields = new string[] { fieldName };
            request.Parameters = new FieldValueCollection[] 
            { 
                new FieldValueCollection{
                FieldName = getIdFieldName(),
                Type = FieldType.Int,
                Values = new string[]{id.ToString()}
                }
            };
            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(request.Address.DataKey);

            return app.GetValue(request);
        }

        public bool ExecuteDataRequest(DataRequest request)
        {
            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(request.Address.DataKey);

            return app.Execute(request);
        }

    }
}
