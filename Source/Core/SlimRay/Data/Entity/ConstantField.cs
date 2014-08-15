using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Entity
{
    public class ConstantField : ABasicField
    {
        public ConstantField(string value, FieldDataType type)
        {
            _value = value;
            _type = type;
        }

        public ConstantField(string value)
        {
            _value = value;
            _type = FieldDataType.NotSet;
        }
    }
}
