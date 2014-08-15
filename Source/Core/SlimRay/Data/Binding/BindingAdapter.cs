using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.Binding
{
    public interface BindingAdapter
    {
        string FormatString { get; set; }

        string GetFieldValue();

    }
}
