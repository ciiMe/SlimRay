using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.DB.Factory
{
    public interface IExecutorCreator
    {
        IExecutor New();
    }
}
