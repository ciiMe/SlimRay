using System;


namespace SR.Base.Types
{
    public static class ConstValue
    {
        /// <summary>
        /// 差额小于此值的两个浮点数被认为相等。
        /// </summary>
        public const double FLOAT_DIFF = 0.01;

        #region Null values for each type

        public static int NULLINT = -1;
        public static double NULLDOUBLE = 0;
        public static string NULLSTRING = "";

        public static DateTime NULLDATETIME = Convert.ToDateTime("1900-1-1");
        public static object NULLOBJECT = null;

        public static bool NULLBOOL = false;

        #endregion

        public static string FLAG_OK = "OK";

        #region 数据库中，0 1所代表的布尔值

        public static int INT_BOOL_TRUE = 1;
        public static int INT_BOOL_FALSE = 0;

        #endregion
    }
}
