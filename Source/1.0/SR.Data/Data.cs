using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data
{
    public interface IData
    {
        int Key { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        int Level { get; set; }

        List<IField> Fields { get; }

        void AddField(IField field);
        void RemoveFiled(int key);
    }

    public interface IField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        IData Data { get; set; }

        IDataType Type { get; set; }

        int Key { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }

    [Serializable]
    public class SRData : IData
    {
        private int _key;
        private string _name;
        private string _description;

        private int _level;

        /*
         * this is a copy of _fields,
         * this copy is created to isolate the real data,
         */
        private readonly List<IField> _fieldsCache;
        private List<IField> _fields;

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

        private bool isFieldExists(IField field)
        {
            return getFieldIndex(field.Key) >= 0;
        }

        private int getFieldIndex(int key)
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

    [Serializable]
    public class SRField : IField
    {
        private int _key;
        private string _name;
        private IDataType _type;

        private string _description;
        private IData _data;

        public SRField(int key, string name, IDataType type)
        {
            _key = key;
            _name = name;
            _type = type;

            _description = "";
            _data = null;
        }

        public SRField(int key, string name, IDataType type, string description)
        {
            _key = key;
            _name = name;
            _type = type;

            _description = description;
            _data = null;
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

        public IDataType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public IData Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
