using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SlimRay.Data;

namespace SlimRay.Data.Manager.Operators
{
    public interface IOperatorParser
    {
        string Parse(ExpressionOperator op);
    }
}
