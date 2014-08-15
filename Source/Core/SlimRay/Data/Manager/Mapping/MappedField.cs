using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.Data.Entity;

namespace SlimRay.Data.Manager.Mapping
{
    public class MappedField : SRField, IMapped
    {
        private string _bindingName;

        public string BindingName
        {
            get { return _bindingName; }
            set { _bindingName = value; }
        }

        public MappedField(string name, FieldDataType type)
            : base(name, type)
        { }

        public MappedField(string name, FieldDataType type, string description)
            : base(name, type, description)
        { }
    }
}
