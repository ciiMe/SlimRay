using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using SR.Data.Entity;

namespace SR.Data.Manager.Entity
{
    public class DataEntity : SRData, IDataEntity
    {
        private DataTable _data;

        public DataEntity(DataTable data)
            : base(Constants.DataTypes.DATA_TYPE_NULL, Constants.DataTypes.DATA_NAME_NULL)
        {
            _data = data;
        }

        public byte ValueByte(IField field)
        {
            return Convert.ToByte(_data.Rows[0][field.Name]);
        }

        public int ValueInt32(IField field)
        {
            return Convert.ToInt32(_data.Rows[0][field.Name]);
        }

        public long ValueInt64(IField field)
        {
            return Convert.ToInt64(_data.Rows[0][field.Name]);
        }

        public char ValueChar(IField field)
        {
            return Convert.ToChar(_data.Rows[0][field.Name]);
        }

        public string ValueString(IField field)
        {
            return Convert.ToString(_data.Rows[0][field.Name]);
        }

        public bool ValueBool(IField field)
        {
            return Convert.ToBoolean(_data.Rows[0][field.Name]);
        }
    }
}
