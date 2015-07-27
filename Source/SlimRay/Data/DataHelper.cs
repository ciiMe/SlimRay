using SlimRay.Data.Utils;
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

        public string[] LoadFieldValue(string dataName, string fieldName)
        {
            DataRequest r = buildRequest(dataName);
            r.RequestFields = new string[] { fieldName };
            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(r.Address.DataKey);

            return DataTableHelper.GetFieldAsArray(app.GetTable(r), fieldName);
        }


        public string[] LoadFieldValue(string dataName, string fieldName, DataFilter filter)
        {
            DataRequest r = buildRequest(dataName);
            r.RequestFields = new string[] { fieldName };

            FieldValueCollection[] par = new FieldValueCollection[filter.Count];

            for (int i = 0; i < filter.Count; i++)
            {
                par[i] = new FieldValueCollection()
                {
                    FieldName = filter[i].fieldName,
                    Values = new string[] { filter[i].value }
                };
            }

            r.Parameters = par;

            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(r.Address.DataKey);

            return DataTableHelper.GetFieldAsArray(app.GetTable(r), fieldName);
        }

        public string LoadFieldValue(string dataName, string fieldName, int id)
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
