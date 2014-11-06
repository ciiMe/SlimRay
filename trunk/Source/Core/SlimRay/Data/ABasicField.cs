
namespace SlimRay.Data
{
    public abstract class ABasicField : ISimpleField
    {
        protected ISimpleData _data;
        protected DataType _type;

        protected string _name;
        protected string _description;

        protected string _value;

        protected ISimpleData _linkedData;
        protected FieldLinkRelation _linkRelation;

        public ISimpleData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public DataType Type
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

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void Link(ISimpleData data, FieldLinkRelation relation)
        {
            _linkedData = data;
            _linkRelation = relation;
        }
    }
}
