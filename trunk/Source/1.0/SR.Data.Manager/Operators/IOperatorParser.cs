using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SR.Data;

namespace SR.Data.Manager.Operators
{
    public interface IOperatorParser
    {
        string Parse(ExpressionOperator op);
    }
}
