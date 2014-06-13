using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataType
    {
        /// <summary>
        /// Key is the unique code of this data type,
        /// </summary>
        int Key { get; }
        int Level { get; }
        string Name { get; }
        string Description { get; }
    }
}
