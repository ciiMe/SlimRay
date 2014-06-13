using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Data.Manager
{
    public enum DataCompareType
    {
        Int,
        Float,
        String,
        DateTime
    }

    public enum DataCompareMethod
    { 
        Equal,
        NotEqual,
        LargerThan,
        SmallerThan,
        Like
    }
}
