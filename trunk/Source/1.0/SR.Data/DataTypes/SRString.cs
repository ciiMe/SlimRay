using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.DataTypes
{
    public struct SRString : IDataType
    {
        private const string _name = "String";
        private const string _description = "Default data types of SR,String.";

        public int Key
        {
            get { return (int)DataTypeKeys.SRString; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }
    }
}
