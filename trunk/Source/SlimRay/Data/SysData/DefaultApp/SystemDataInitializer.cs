
namespace SlimRay.Data.SysData.DefaultApp
{
    public class SystemDataInitializer : ISystemDataHelper
    {
        private DataHelper _dataHelper;

        public SystemDataInitializer()
        {
            _dataHelper = new DataHelper();
        }

        public string[] GetDataList()
        {
            return _dataHelper.LoadFieldValue(DataList.TableName, DataList.Fields.Name); 
        }

        public bool AddData(string name, string displayName)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveData(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateData(string dataName, string newDisplayName)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetFields(string dataName)
        {
            DataFilter filter = new DataFilter();
            filter.Add(new DataFilterItem { fieldName = FieldList.Fields.Name, value = dataName });

            return _dataHelper.LoadFieldValue(FieldList.TableName, FieldList.Fields.DisplayName, filter);
        }

        public bool AddField(string dataName, string name, string displayName, int type)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveField(string dataName, string name)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateField(string dataName, string name, string newDisplayName, int newType)
        {
            throw new System.NotImplementedException();
        }
    }
}
