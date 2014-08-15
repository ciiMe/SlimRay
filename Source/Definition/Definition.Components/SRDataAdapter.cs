using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SlimRay.Data;

namespace SlimRay.UI.Designtime.Components
{
    public class SRDataAdapter
    {
        private IField _field;

        public SRDataAdapter(IField field)
        {
            _field = field;
        }
    }
}
