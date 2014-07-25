using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data.DB;

namespace SR.Data.Manager
{
    public interface IExecutePlanBuilder
    {
        IExecutePlan Build(IData data, Expression expression);
    }

}
