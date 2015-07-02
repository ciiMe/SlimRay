using SlimRay.DB;
using System.Collections.Generic;

namespace SlimRay.UserData
{
    public class UserDataEntity : IUserData
    {
        protected int _id;
        protected string _name;
        protected string _description;

        protected List<IUserField> _fields;
        protected List<LinkedUserField> _linkedFields;

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

        public IUserField[] Fields
        {
            //todo: shoule be cached.
            get { return _fields.ToArray(); }
        }

        public UserDataEntity(string name)
        {
            _name = name;
            _description = "";
            _fields = new List<IUserField>();
            _linkedFields = new List<LinkedUserField>();
        }

        public UserDataEntity(string name, string description)
        {
            _name = name;
            _description = description;
            _fields = new List<IUserField>();
            _linkedFields = new List<LinkedUserField>();
        }

        protected bool isFieldExists(IUserField field)
        {
            return getFieldIndex(field) >= 0;
        }

        protected int getFieldIndex(IUserField field)
        {
            return _fields.IndexOf(field);
        }

        public void AddField(IUserField field)
        {
            if (isFieldExists(field))
            {
                return;
            }

            field.Data = this;

            _fields.Add(field);
        }

        public void RemoveFiled(string name)
        {
            int index = -1;
            foreach (IUserField field in _fields)
            {
                index++;
                if (field.Name == name)
                {
                    break;
                }
            }

            if (index >= 0 && index < _fields.Count)
            {
                _fields[index].Data = null;
                _fields.RemoveAt(index);
            }
        }

        public LinkedUserField[] LinkedFields
        {
            get { return _linkedFields.ToArray(); }
        }

        public void Link(IUserField field, UserFieldLinkRelation relation)
        {
            LinkedUserField lf = new LinkedUserField
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

        public IUserField Field(string name)
        {
            name = name.Trim().ToUpper();
            foreach (IUserField field in _fields)
            {
                if (field.Name.ToUpper() == name)
                {
                    return field;
                }
            }

            return null;
        }
    }
}
