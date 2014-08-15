using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using SlimRay.Data;

namespace SlimRay.Data.Manager
{
    /*
     * The interface is designed for user-ui,
     * any data is input as string,
     * so,only string value is used for compareing.
     */
    public interface IDataManager
    {
        DataTable GetDataTable(IData data, Expression expression);
        DataRow GetDataRow(IData data, Expression expression);

        IDataEntity GetEntity(IData data, Expression expression);
    }
}
