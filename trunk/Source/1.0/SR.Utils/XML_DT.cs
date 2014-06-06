using System;
using System.Text;
using System.Data;

namespace SR.Data.DB.Tools
{
    public static class XML_DT
    {
        //public static object GetEnumFromRow(DataRow row, string columnName, System.Type enumType)
        //{
        //    object result = Enum.Parse(enumType, row[columnName].ToString(), true);
        //    if (!Enum.IsDefined(enumType, result))
        //    {
        //        throw new System.ArgumentOutOfRangeException(columnName, result, "枚举值未定义");
        //    }
        //    return result;
        //}

        /// <summary>
        /// 将datatable转换为xml格式
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToXML(DataTable dt)
        {
            if (null == dt)
                dt = new DataTable();

            System.IO.StringWriter writer = new System.IO.StringWriter();

            dt.WriteXml(writer);

            return writer.ToString();
        }

        /// <summary>
        /// 将datatable转换为分栏的xml，节点取名采用系统默认规则
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="colCount">分栏数量</param>
        /// <returns></returns>
        public static string DataTableToXML(DataTable dt, int colCount)
        {
            if (null == dt)
                dt = new DataTable();

            string tn;
            if (dt.TableName == "")
                tn = "NewDataTable";
            else
                tn = dt.TableName;

            string sn;
            if (dt.DataSet == null || dt.DataSet.DataSetName == "")
                sn = "NewDataSet";
            else
                sn = dt.DataSet.DataSetName;

            return DataTableToXML(dt, sn, tn, colCount, "col");
        }

        /// <summary>
        /// 将dt转化为分栏的xml
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="DataSetName">根节点名称</param>
        /// <param name="DataTableName">行根节点名称</param>
        /// <param name="colCount">分栏数量</param>
        /// <param name="colName">每一个分栏的基础名称。比如结果为：col1、col2、col3、col4，那么colName传入“col”</param>
        /// <returns></returns>
        public static string DataTableToXML(DataTable dt, string DataSetName, string DataTableName, int colCount, string colName)
        {
            if (null == dt)
                dt = new DataTable();

            int i = 0, mod = 0;

            StringBuilder b = new StringBuilder();

            b.AppendFormat("<{0}>", DataSetName);
            foreach (DataRow row in dt.Rows)
            {
                i++;

                mod = i % colCount;

                if (mod == 1)
                {
                    b.AppendFormat("<{0}>", DataTableName);
                }

                if (mod == 0)
                {
                    b.AppendFormat("<{0}{1}>", colName, colCount);
                }
                else
                {
                    b.AppendFormat("<{0}{1}>", colName, mod);
                }

                foreach (DataColumn column in dt.Columns)
                {
                    b.AppendFormat("<{0}>{1}</{0}>", column.ColumnName, row[column.ColumnName]);
                }

                if (mod == 0)
                {
                    b.AppendFormat("</{0}{1}>", colName, colCount);
                }
                else
                {
                    b.AppendFormat("</{0}{1}>", colName, mod);
                }

                if (mod == 0)
                {
                    b.AppendFormat("</{0}>", DataTableName);
                }
            }
            //如果最后不足，那么补充空白节点，将每一栏补齐。
            if (i % colCount != 0)
            {
                //空数据也要生成一个空的节点，补充第一个节点名称
                if (dt.Rows.Count == 0)
                {
                    b.AppendFormat("<{0}>", DataTableName);
                }

                i++;

                //补充剩余分栏
                while (i % colCount != 0)
                {
                    b.AppendFormat("<{0}{1}></{0}{1}>", colName, i % colCount);
                    i++;
                }

                //插入最后一个分栏
                b.AppendFormat("<{0}{1}></{0}{1}>", colName, colCount);

                //插入对应前面的结束符
                b.AppendFormat("</{0}>", DataTableName);
            }
            b.AppendFormat("</{0}>", DataSetName);

            return b.ToString();
        }
    }
}
