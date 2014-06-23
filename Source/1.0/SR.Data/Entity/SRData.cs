using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Entity
{
    public class SRData : IData
    {
        protected int _key;
        protected string _name;
        protected string _description;

        protected int _level;

        /*
         * this is a copy of _fields,
         * this copy is created to isolate the real data,
         */
        protected readonly List<IField> _fieldsCache;
        protected List<IField> _fields;

        public SRData(int key, string name)
        {
            _key = key;
            _name = name;
            _description = "";
            _level = -1;

            _fields = new List<IField>();
            _fieldsCache = new List<IField>();
        }

        public SRData(int key, int level, string name, string description)
        {
            _key = key;
            _name = name;
            _description = description;
            _level = level;

            _fields = new List<IField>();
            _fieldsCache = new List<IField>();
        }

        public int Key
        {
            get { return _key; }
            set { _key = value; }
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

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        List<IField> IData.Fields
        {
            get { return _fieldsCache; }
        }

        protected bool isFieldExists(IField field)
        {
            return getFieldIndex(field.Key) >= 0;
        }

        protected int getFieldIndex(int key)
        {
            for (int i = 0; i < _fields.Count; i++)
            {
                if (_fields[i].Key == key)
                {
                    return i;
                }
            }

            return -1;
        }

        public void AddField(IField field)
        {
            if (isFieldExists(field))
            {
                return;
            }

            field.Data = this;

            _fields.Add(field);
            lock (_fieldsCache)
            {
                _fieldsCache.Add(field);
            }
        }

        public void RemoveFiled(int key)
        {
            int index = getFieldIndex(key);

            if (index >= 0 && index < _fields.Count)
            {
                _fields[index].Data = null;
                _fields.RemoveAt(index);
            }

            lock (_fieldsCache)
            {
                _fieldsCache.Clear();
                _fieldsCache.AddRange(_fields);
            }
        }
    }
}
