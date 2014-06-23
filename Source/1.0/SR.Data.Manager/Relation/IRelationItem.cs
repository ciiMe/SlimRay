using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Manager.Relation
{
    public interface IRelationItem
    {
        void Link(IField field, Relations relation);
    }
}
