using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Entity
{
    public class DataTypes
    {
        public readonly IDataType SRInt;
        public readonly IDataType SRString;

        public DataTypes()
        {
            SRInt = DataProvider.Instance.GetDataType((int)DataTypeKeys.SRInt);
            SRString = DataProvider.Instance.GetDataType((int)DataTypeKeys.SRString);
        }
    }
}
