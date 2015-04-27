using System.Collections.Generic;

namespace SlimRay.UserData
{
    public class Data : IData
    {
        protected int _id;
        protected string _name;
        protected string _description;

        protected List<IField> _fields;
        protected List<LinkedField> _linkedFields;

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

        public IField[] Fields
        {
            //todo: shoule be cached.
            get { return _fields.ToArray(); }
        }

        public Data(string name)
        {
            _name = name;
            _description = "";
            _fields = new List<IField>();
            _linkedFields = new List<LinkedField>();
        }

        public Data(string name, string description)
        {
            _name = name;
            _description = description;
            _fields = new List<IField>();
            _linkedFields = new List<LinkedField>();
        }

        protected bool isFieldExists(IField field)
        {
            return getFieldIndex(field) >= 0;
        }

        protected int getFieldIndex(IField field)
        {
            return _fields.IndexOf(field);
        }

        public void AddField(IField field)
        {
            if (isFieldExists(field))
            {
                return;
            }

            field.Data = this;

            _fields.Add(field);
        }

        public void RemoveFiled(int index)
        {
            if (index >= 0 && index < _fields.Count)
            {
                _fields[index].Data = null;
                _fields.RemoveAt(index);
            }
        }

        public LinkedField[] LinkedFields
        {
            get { return _linkedFields.ToArray(); }
        }

        public void Link(IField field, FieldLinkRelation relation)
        {
            LinkedField lf = new LinkedField
            {
                Field = field,
                Relation = relation
            };

            _linkedFields.Add(lf);
        }

        public void UnLink(string fieldName)
        {
            throw new System.NotImplementedException();
        }
    }
}
