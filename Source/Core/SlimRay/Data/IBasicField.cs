using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data
{
    public interface IBasicField
    {
        /// <summary>
        /// The data that this filed belongs to.
        /// </summary>
        IData Data { get; set; }

        FieldDataType Type { get; set; }

        string Name { get; set; }
        string Description { get; set; }

        string Value { get; set; }

        /// <summary>
        /// Link another data,the data is always used to record detail,external infomation.
        /// </summary>
        /// <param name="data">The data of this field links.</param>
        /// <param name="relation">The relationship of data links to this field.</param>
        void Link(IData data, FieldLinkRelation relation);
    }
}
