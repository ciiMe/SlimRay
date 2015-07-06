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
                 Target = DataTarget.Data,
                 Address = address,
                 DataName = dataName
             };
        }

        public DataTable LoadData(string dataName)
        {
            DataRequest request = buildRequest(dataName);
            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(request.Address.DataKey);

            return app.GetTable(request);
        }

        public DataTable LoadData(string dataName, int[] id)
        {
            DataRequest request = buildRequest(dataName);
            //todo: attatch id and other parameters.
            IDataAccessApp app = DataHelperGate.Instance.GetDataAccessApp(request.Address.DataKey);

            return app.GetTable(request);
        }

        public string LoadField(string dataName, string fieldName, int id)
        {
            DataRequest request = buildRequest(dataName);
            //todo: attatch id and other parameters.
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
