using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SR.Data.Entity;

namespace SR.Data.Manager.Entity
{
    /*
     * the DataEntity stores all data in DataRow,
     * Field name of data is Column name in datarow.
     */
    public class DataEntity : SRData, IDataEntity
    {
        private DataRow _data;

        public DataEntity(DataRow data)
            : base("")
        {
            _data = data;
        }

        public byte ValueByte(IField field)
        {
            return Convert.ToByte(_data[field.Name]);
        }

        public int ValueInt32(IField field)
        {
            return Convert.ToInt32(_data[field.Name]);
        }

        public long ValueInt64(IField field)
        {
            return Convert.ToInt64(_data[field.Name]);
        }

        public char ValueChar(IField field)
        {
            return Convert.ToChar(_data[field.Name]);
        }

        public string ValueString(IField field)
        {
            return Convert.ToString(_data[field.Name]);
        }

        public bool ValueBool(IField field)
        {
            return Convert.ToBoolean(_data[field.Name]);
        }
    }
}
