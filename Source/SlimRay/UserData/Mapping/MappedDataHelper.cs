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

            DataHelper tm = new DataHelper();

            //load data from db, and get id from table's data.
            //todo: data can be cached.
            tm.LoadData(mappedDataTableName);
            int id = 0;

            tm.LoadData(mappedDataTableName, new string[] { id.ToString() });

            //convert result to entity
            IMappedUserField[] result = new IMappedUserField[] { };

            return result;
        }
    }
}
