using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data
{
    /// <summary>
    /// An object that can be compared with other.
    /// it keep only 1 pair of operator-value,
    /// the compare mothods change the operator and value.
    /// </summary>
    public interface IComparableItem
    {
        Expression Equal(string value);
        Expression NotEqual(string value);

        Expression Like(string value);

        Expression BiggerThan(string value);
        Expression SmallerThan(string value);
    }
}
