using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Entity
{
    public class SRField : IField
    {
        protected int _key;
        protected string _name;
        protected IDataType _type;

        protected string _description;
        protected IData _data;
        protected IData _linkedData;

        private CompareMethod _expression;

        public SRField(int key, string name, IDataType type)
        {
            _key = key;
            _name = name;
            _type = type;

            _description = "";

            init();
        }

        public SRField(int key, string name, IDataType type, string description)
        {
            _key = key;
            _name = name;
            _type = type;

            _description = description;

            init();
        }

        private void init()
        {
            _data = null;
            _linkedData = null;

            _expression = new CompareMethod();
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

        public void Link(IData data, FieldLinkRelation relation)
        {
            throw new NotImplementedException();
        }

        public ICompareMethod Expression
        {
            get { return _expression; }
        }
    }
}
