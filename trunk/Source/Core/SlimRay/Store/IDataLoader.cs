using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Store
{
    public interface IDataLoader
    {
        IDataEntity GetEntity();
    }
}
