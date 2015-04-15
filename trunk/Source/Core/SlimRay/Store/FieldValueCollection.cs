using SlimRay.UserData;
using System.Collections.Generic;

namespace SlimRay.Store
{
    public class FieldValueCollection
    {
        private Dictionary<IField, string> _fieldValues;

        public FieldValueCollection()
        {
            _fieldValues = new Dictionary<IField, string>();
        }

        public void Add(IField field, string value)
        {
            _fieldValues.Add(field, value);
        }

        public void Remove(IField field)
        {
            _fieldValues.Remove(field);
        }

        public void Clear()
        {
            _fieldValues.Clear();
        }
    }
}
