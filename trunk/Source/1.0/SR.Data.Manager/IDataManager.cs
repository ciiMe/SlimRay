using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using SR.Data;

namespace SR.Data.Manager
{
    /*
     * The interface is designed for user-ui,
     * any data is input as string,
     * so,only string value is used for compareing.
     */
    public interface IDataManager
    {
        DataTable GetDataTable(IData data, IExpression expression);
        DataRow GetDataRow(IData data, IExpression expression);

        IDataEntity GetEntity(IData data, IExpression expression);
    }
}
