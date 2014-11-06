using System.Collections.Generic;

namespace SlimRay.Data
{
    public class FieldValueCollection
    {
        private Dictionary<ISimpleField, string> _fieldValues;

        public FieldValueCollection()
        {
            _fieldValues = new Dictionary<ISimpleField, string>();
        }

        public void Add(ISimpleField field, string value)
        {
            _fieldValues.Add(field, value);
        }

        public void Remove(ISimpleField field)
        {
            _fieldValues.Remove(field);
        }

        public void Clear()
        {
            _fieldValues.Clear();
        }
    }
}
