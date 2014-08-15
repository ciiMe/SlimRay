using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Store
{
    public interface IStoreProvider
    {
        string GetString(IData data, Expression expr);
    }
}
