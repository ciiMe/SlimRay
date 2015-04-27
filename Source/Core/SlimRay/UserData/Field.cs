
namespace SlimRay.UserData
{
    public class Field : IField
    {
        private IData _data;

        private int _id;
        private string _name;
        private string _description;
        private FieldType _type;
        private FieldDisplayType _displayType;
        private DataValueFormat _displayFormat;

        public IData Data
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

        public FieldType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Field(string name, FieldType type)
        {
            _name = name;
            _type = type;
        }

        public Field(string name, string description, FieldType type)
        {
            _name = name;
            _description = description;
            _type = type;
        }
    }
}
