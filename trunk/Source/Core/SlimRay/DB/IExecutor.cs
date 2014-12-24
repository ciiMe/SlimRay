using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace SlimRay.DB
{
    public interface IExecutor
    {
        object GetResult(Request plan);

        DataTable GetDataTable(Request plan);

        int Execute(Request plan);
    }
}
