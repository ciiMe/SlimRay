using SlimRay.DB.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.DB.Helpers.MSSQL
{
    public class MSSQLExecutorCreator:IExecutorCreator
    {
        public IExecutor New()
        {
            return new MSSQLHelper();
        }
    }
}
