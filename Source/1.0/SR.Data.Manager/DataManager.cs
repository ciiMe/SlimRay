using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.Data.Manager
{
    public class DataManager : IDataManager
    {
        public System.Data.DataTable GetDataTable(IData data, IExpression expression)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataRow GetDataRow(IData data, IExpression expression)
        {
            throw new NotImplementedException();
        }
    }
}
