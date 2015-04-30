using SlimRay.UserData;
using System.Collections.Generic;

namespace SlimRay.Store
{
    public class FieldValueCollection
    {
        private Dictionary<IUserField, string> _fieldValues;

        public FieldValueCollection()
        {
            _fieldValues = new Dictionary<IUserField, string>();
        }

        public void Add(IUserField field, string value)
        {
            _fieldValues.Add(field, value);
        }

        public void Remove(IUserField field)
        {
            _fieldValues.Remove(field);
        }

        public void Clear()
        {
            _fieldValues.Clear();
        }
    }
}
