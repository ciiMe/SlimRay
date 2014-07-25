using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Entity
{
    public class SRData : IData
    {
        protected string _name;
        protected string _description;

        protected List<IField> _fields;

        public SRData(string name)
        {
            _name = name;
            _description = "";
            _fields = new List<IField>();
        }

        public SRData(string name, string description)
        {
            _name = name;
            _description = description;
            _fields = new List<IField>();
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
            get { return _fields.ToArray(); }
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
    }
}
