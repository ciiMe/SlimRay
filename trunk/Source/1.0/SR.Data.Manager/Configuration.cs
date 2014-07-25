using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data;
using SR.Data.Entity;

namespace SR.Data.Manager
{
    public class Configuration
    {
    }

    public class ConfigurationItem : SRField
    {
        public ConfigurationItem(string name, string description)
            : base(name, FieldDataType.String, description)
        {

        }
    }
}
