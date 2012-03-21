
using System.Data;

using SR.Base.Types;

using SR.Base.Interface;

namespace SR.Data.DB.Helper
{
    public interface IDBHelper : IIndex, IName
    {
        ConvertibleObject GetResult(ISQLPlan plan);

        DataRow GetDataRow(ISQLPlan plan);
        DataTable GetDataTable(ISQLPlan plan);
        DataSet GetDataSet(ISQLPlan plan);

        int Execute(ISQLPlan plan);
    }
}
