using System.Collections.Generic;

namespace SlimRay.Data
{
    public class SimpleData : ISimpleData
    {
        protected string _name;
        protected string _description;

        protected List<ISimpleField> _fields;

        public SimpleData(string name)
        {
            _name = name;
            _description = "";
            _fields = new List<ISimpleField>();
        }

        public SimpleData(string name, string description)
        {
            _name = name;
            _description = description;
            _fields = new List<ISimpleField>();
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

        public ISimpleField[] Fields
        {
            get { return _fields.ToArray(); }
        }

        protected bool isFieldExists(ISimpleField field)
        {
            return getFieldIndex(field) >= 0;
        }

        protected int getFieldIndex(ISimpleField field)
        {
            return _fields.IndexOf(field);
        }

        public void AddField(ISimpleField field)
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
    }
}
