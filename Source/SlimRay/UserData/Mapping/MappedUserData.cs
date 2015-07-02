
namespace SlimRay.UserData.Mapping
{
    public class MappedUserData : UserDataEntity, IMappedUserData
    {
        private IMappedUserField[] _mapping;

        public IMappedUserField[] Mapping
        {
            get { return _mapping; }
            set { _mapping = value; }
        }

        public MappedUserData(string name)
            : base(name)
        { }

        public MappedUserData(string name, string description)
            : base(name, description)
        { }
    }
}
