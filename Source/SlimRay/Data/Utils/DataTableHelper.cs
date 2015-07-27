using System.Collections.Generic;
using System.Data;

namespace SlimRay.Data.Utils
{
    public class DataTableHelper
    {
        public static string[] GetFieldAsArray(DataTable dt, string fieldName)
        {
            List<string> data = new List<string>();

            int index = dt.Columns.IndexOf(fieldName);

            if (index < 0)
            {
                return new string[] { };
            }

            foreach (DataRow row in dt.Rows)
            {
                data.Add(row[index].ToString());
            }

            return data.ToArray();
        }
    }
}
