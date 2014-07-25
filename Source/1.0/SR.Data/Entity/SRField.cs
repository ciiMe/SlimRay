using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Entity
{
    public class SRField : AComparableField
    {
        public SRField(string name, FieldDataType type)
        {
            _name = name;
            _type = type;
            _description = "";
        }

        public SRField(string name, FieldDataType type, string description)
        {
            _name = name;
            _type = type;
            _description = description;
        }
    }
}
