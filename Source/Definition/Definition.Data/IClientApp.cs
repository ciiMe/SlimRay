using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Definition.Data
{
    public interface IClientApp
    {
        Dictionary<string, object> Cache { get; set; }
    }
}
