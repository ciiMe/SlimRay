using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data
{
    public interface IData
    {
        string Name { get; set; }
        string Description { get; set; }

        IField[] Fields { get; }

        void AddField(IField field);
        void RemoveFiled(int index);
    }
}
