using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Binding
{
    public interface BindingAdapter
    {
        string FormatString { get; set; }

        string GetFieldValue();

    }
}
