using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data
{
    public enum FieldDataType
    {
        /// <summary>
        /// Means not set.
        /// </summary>
        NotSet,

        Bit,
        Byte,
        Int32,
        UnInt32,
        Int64,
        UnInt64,

        Float,

        Char,
        String,

        Bool,

        Date,
        Time,
        DateTime,

        Emun
    }
}
