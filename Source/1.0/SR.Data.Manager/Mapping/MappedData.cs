using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data.Entity;

namespace SR.Data.Manager.Mapping
{
    public class MappedData : SRData, IMapped
    {
        private string _bindingName;

        public string BindingName
        {
            get { return _bindingName; }
            set { _bindingName = value; }
        }

        public MappedData(string name)
            : base(name)
        { }

        public MappedData(string name, string description)
            : base(name, description)
        { }
    }
}
