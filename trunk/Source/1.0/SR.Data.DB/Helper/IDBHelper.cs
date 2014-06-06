﻿
using System.Data;

namespace SR.Data.DB.Helper
{
    public interface IDBHelper 
    {
        object GetResult(ISQLPlan plan);

        DataRow GetDataRow(ISQLPlan plan);
        DataTable GetDataTable(ISQLPlan plan);
        DataSet GetDataSet(ISQLPlan plan);

        int Execute(ISQLPlan plan);
    }
}
