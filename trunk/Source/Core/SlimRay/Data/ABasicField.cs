
namespace SlimRay.Data
{
    public abstract class ABasicField : IField
    {
        protected IData _data;
        protected FieldType _type;

        protected string _name;
        protected string _description;

        protected IData _linkedData;
        protected FieldLinkRelation _linkRelation;

        public IData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public FieldType Type
        {
            get { return _type; }
            set { _type = value; }
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

        public void Link(IData data, FieldLinkRelation relation)
        {
            _linkedData = data;
            _linkRelation = relation;
        }

    }
}
