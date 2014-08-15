using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Entity
{
    public abstract class ABasicField : IBasicField
    {
        protected IData _data;
        protected FieldDataType _type;

        protected string _name;
        protected string _description;

        protected string _value;

        protected IData _linkedData;
        protected FieldLinkRelation _linkRelation;

        public IData Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public FieldDataType Type
        {
            get { return _type; }
            set { _type = value; }
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

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void Link(IData data, FieldLinkRelation relation)
        {
            _linkedData = data;
            _linkRelation = relation;
        }
    }
}
