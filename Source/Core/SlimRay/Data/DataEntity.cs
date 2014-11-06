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
        public DataEntity(ISimpleData data)
            : base(data.Name, data.Description)
        {
        }

        public void SetValue(ISimpleField filed, string value)
        {
            throw new NotImplementedException();
        }

        public byte ValueByte(ISimpleField field)
        {
            throw new NotImplementedException();
        }

        public int ValueInt32(ISimpleField field)
        {
            throw new NotImplementedException();
        }

        public long ValueInt64(ISimpleField field)
        {
            throw new NotImplementedException();
        }

        public char ValueChar(ISimpleField field)
        {
            throw new NotImplementedException();
        }

        public string ValueString(ISimpleField field)
        {
            throw new NotImplementedException();
        }

        public bool ValueBool(ISimpleField field)
        {
            throw new NotImplementedException();
        }
    }
}
