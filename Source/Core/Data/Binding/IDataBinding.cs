using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Binding
{
    /// <summary>
    /// An object that bind to data source,
    /// to provide data.
    /// </summary>
    public interface IDataBinding
    {
        IData Data { get; set; }
        IField Field { get; set; }

        string GetValue(string format);

        /// <summary>
        /// Check the data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ProcessResult Check(string data);
    }
}
