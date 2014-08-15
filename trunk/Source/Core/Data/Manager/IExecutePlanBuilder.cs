using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.Data.DB;

namespace SlimRay.Data.Manager
{
    public interface IExecutePlanBuilder
    {
        IExecutePlan Build(IData data, Expression expression);
    }

}
