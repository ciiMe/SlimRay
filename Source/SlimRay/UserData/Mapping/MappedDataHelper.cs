using SlimRay.Data;

namespace SlimRay.UserData.Mapping
{
    public class MappedDataHelper : IMappedDataHelper
    {
        public IMappedUserField[] GetMappedField(string dataName)
        {
            string mappedDataTableName = "sys_DataMapping";
            string dataNameField = "DataName";
            string realDataNameField = "RealDataName";
            string fieldNameField = "MappedFieldName";
            string realFieldNameField = "RealFieldName";

            int id = 0;

            TableManager tm = new TableManager();
            tm.LoadData(mappedDataTableName, new int[] { id });

            return  ;
        }
    }
}
