using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data
{
    public interface IData
    {
        int Key { get; set; }
        string Name { get; set; }
        string Description { get; set; }

        int Level { get; set; }

        List<IField> Fields { get; }

        void AddField(IField field);
        void RemoveFiled(int key);
    }
}
