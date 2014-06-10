using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.DataTypes
{
    public struct SRInt : IDataType
    {
        private const string _name = "Int";
        private const string _description = "Default data types of SR,int.";

        public int Key
        {
            get { return (int)DataTypeKeys.SRInt; }
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
