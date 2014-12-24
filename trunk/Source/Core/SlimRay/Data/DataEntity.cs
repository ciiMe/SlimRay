using System;
using System.Data;

namespace SlimRay.Data
{
    /*
     * the DataEntity stores all data in DataRow,
     * Field name of data is Column name in datarow.
     */
    public class DataEntity : Data, IDataEntity
    {
        public DataEntity(IData data)
            : base(data.Name, data.Description)
        {
        }

        public void SetValue(IField filed, string value)
        {
            throw new NotImplementedException();
        }

        public byte ValueByte(IField field)
        {
            throw new NotImplementedException();
        }

        public int ValueInt32(IField field)
        {
            throw new NotImplementedException();
        }

        public long ValueInt64(IField field)
        {
            throw new NotImplementedException();
        }

        public char ValueChar(IField field)
        {
            throw new NotImplementedException();
        }

        public string ValueString(IField field)
        {
            throw new NotImplementedException();
        }

        public bool ValueBool(IField field)
        {
            throw new NotImplementedException();
        }
    }
}
