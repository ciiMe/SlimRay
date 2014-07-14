using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace SR.Data.Entity
{
    public class SRDataEntity : SRData, IDataEntity
    {
        private DataTable _data;

        public SRDataEntity()
            : base(Constants.DataTypes.DATA_KEY_NULL, Constants.DataTypes.DATA_NAME_NULL)
        {
            _data = new DataTable();
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

        bool IDataEntity.ValueBool(IField field)
        {
            throw new NotImplementedException();
        }
    }
}
