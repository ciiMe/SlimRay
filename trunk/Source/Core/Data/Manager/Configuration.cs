using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.Data;
using SlimRay.Data.Entity;

namespace SlimRay.Data.Manager
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
