using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data
{
    /// <summary>
    /// The relationship between field and data.
    /// </summary>
    public enum FieldLinkRelation
    {
        /// <summary>
        /// The data is detail records of field.
        /// </summary>
        Detail,

        /// <summary>
        /// the data is external information of field.
        /// </summary>
        External
    }
}
