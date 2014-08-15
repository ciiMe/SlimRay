using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Data.DB.Common
{
    public static class Contants
    {
        public static class DataValue
        {
            /*
             * constants about null value to db
             */
            public static int NULLINT = -1;
            public static double NULLDOUBLE = -1;
            public static string NULLSTRING = "";

            public static bool NULLBOOL = false;

            public static DateTime NULLDATETIME = new DateTime(0);
        }

        /// <summary>
        /// 关于数据库命令的常量
        /// </summary>
        public static class DBCommand
        {
            public static int CommandTimeOut = 30;
        }
    }
}
