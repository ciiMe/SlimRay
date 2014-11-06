using System;
using System.Data;

namespace SlimRay.Data
{
    /*
     * the DataEntity stores all data in DataRow,
     * Field name of data is Column name in datarow.
     */
    public class DataEntity : SimpleData, IDataEntity
    {
        private DataRow _data;

        public DataEntity(DataRow data)
            : base("")
        {
            _data = data;
        }

        public byte ValueByte(ISimpleField field)
        {
            return Convert.ToByte(_data[field.Name]);
        }

        public int ValueInt32(ISimpleField field)
        {
            return Convert.ToInt32(_data[field.Name]);
        }

        public long ValueInt64(ISimpleField field)
        {
            return Convert.ToInt64(_data[field.Name]);
        }

        public char ValueChar(ISimpleField field)
        {
            return Convert.ToChar(_data[field.Name]);
        }

        public string ValueString(ISimpleField field)
        {
            return Convert.ToString(_data[field.Name]);
        }

        public bool ValueBool(ISimpleField field)
        {
            return Convert.ToBoolean(_data[field.Name]);
        }
    }
}
