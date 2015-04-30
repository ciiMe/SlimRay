using SlimRay.UserData;
using System;

namespace SlimRay.Store
{
    /*
        * the DataEntity stores all data in DataRow,
        * Field name of data is Column name in datarow.
        */
    public class DataEntity : SlimRay.UserData.Entities.UserDataEntity, IDataEntity
    {
        public DataEntity(IUserData data)
            : base(data.Name, data.Description)
        {
        }

        public void SetValue(IUserField filed, string value)
        {
            throw new NotImplementedException();
        }

        public byte ValueByte(IUserField field)
        {
            throw new NotImplementedException();
        }

        public int ValueInt32(IUserField field)
        {
            throw new NotImplementedException();
        }

        public long ValueInt64(IUserField field)
        {
            throw new NotImplementedException();
        }

        public char ValueChar(IUserField field)
        {
            throw new NotImplementedException();
        }

        public string ValueString(IUserField field)
        {
            throw new NotImplementedException();
        }

        public bool ValueBool(IUserField field)
        {
            throw new NotImplementedException();
        }
    }
}
