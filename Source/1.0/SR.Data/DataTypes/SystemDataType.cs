using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.DataTypes
{
    internal abstract class SystemDataType : IDataType
    {
        public int Level
        {
            get { return Constants.DataTypes.DATA_TYPE_LEVEL_SYSTEM; }
        }

        public abstract int Key { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
    }

    [Serializable]
    internal class SRInt : SystemDataType
    {
        private const string _name = "Int";
        private const string _description = "Default data types of SR,int.";

        public override int Key
        {
            get { return (int)DataTypeKeys.SRInt; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override string Description
        {
            get { return _description; }
        }
    }

    [Serializable]
    internal class SRString : SystemDataType
    {
        private const string _name = "String";
        private const string _description = "Default data types of SR,String.";

        public override int Key
        {
            get { return (int)DataTypeKeys.SRString; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override string Description
        {
            get { return _description; }
        }
    }
}
