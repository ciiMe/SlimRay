
namespace SlimRay.UserData
{
    public class UserFieldEntiry : IUserField
    {
        private IUserData _data;

        private int _id;
        private string _name;
        private string _description;
        private UserFieldType _type;

        public IUserData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public UserFieldType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public UserFieldEntiry(string name, UserFieldType type)
        {
            _name = name;
            _type = type;
        }

        public UserFieldEntiry(string name, string description, UserFieldType type)
        {
            _name = name;
            _description = description;
            _type = type;
        }
    }
}
