using System;

namespace SlimRay.UserData.Mapping
{
    public class MappedUserField : UserFieldEntiry, IMappedUserField
    {
        private DataMapPointer _source;

        public DataMapPointer Source
        {
            get { return _source; }
            set { _source = value; }
        }

        public MappedUserField(string name, UserFieldType t)
            : base(name, t)
        {

        }

        public MappedUserField(string name, UserFieldType t, string description)
            : base(name, description, t)
        { }
    }
}
