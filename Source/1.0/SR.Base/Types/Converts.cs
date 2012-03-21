using System;

namespace SR.Base.Types
{
    /// <summary>
    /// 类型之间的转换 
    /// </summary>
    public static class Converts
    {
        /// <summary>
        /// 所有转换操作放到try...catch语句中，屏蔽异常返回默认值。
        /// </summary>
        public static bool IsInTryCatch = false;

        public static int StringToInt(string val)
        {
            string ts = val.Trim();

            if (val == "")
            {
                return ConstValue.NULLINT;
            }

            if (IsInTryCatch)
            {
                try
                {
                    return Convert.ToInt32(val);
                }
                catch
                {
                    return ConstValue.NULLINT;
                }
            }
            return Convert.ToInt32(val);
        }

        public static double StringToDouble(string val)
        {
            string ts = val.Trim();

            if (val == "")
            {
                return ConstValue.NULLDOUBLE;
            }

            if (IsInTryCatch)
            {
                try
                {
                    return Convert.ToDouble(val);
                }
                catch
                {
                    return ConstValue.NULLDOUBLE;
                }
            }
            return Convert.ToDouble(val);
        }

        public static bool IntToBool(int val)
        {
            return val == ConstValue.INT_BOOL_TRUE;
        }

        public static int BoolToInt(bool val)
        {
            if (val)
            {
                return ConstValue.INT_BOOL_TRUE;
            }
            else
            {
                return ConstValue.INT_BOOL_FALSE;
            }
        }


        #region T Convert

        #endregion

        #region 拆箱操作

        public static int objectToInt(object val)
        {
            return objectToInt(val, ConstValue.NULLINT);
        }
        public static int objectToInt(object val, int defaultValue)
        {
            if (val == null)
            {
                return defaultValue;
            }

            if (IsInTryCatch)
            {
                try
                {
                    return Convert.ToInt32(val);
                }
                catch
                {
                    return defaultValue;
                }
            }
            return Convert.ToInt32(val);
        }

        public static double objectToDouble(object val)
        {
            return objectToDouble(val, ConstValue.NULLDOUBLE);
        }
        public static double objectToDouble(object val, double defaultValue)
        {
            if (val == null)
            {
                return defaultValue;
            }

            try
            {
                return Convert.ToDouble(val);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static DateTime objectToDatetime(object val)
        {
            return objectToDatetime(val, ConstValue.NULLDATETIME);
        }
        public static DateTime objectToDatetime(object val, DateTime defaultValue)
        {
            if (val == null)
            {
                return defaultValue;
            }

            if (IsInTryCatch)
            {
                try
                {
                    return Convert.ToDateTime(val);
                }
                catch
                {
                    return defaultValue;
                }
            }

            return Convert.ToDateTime(val);
        }

        public static string objectToString(object val)
        {
            return objectToString(val, ConstValue.NULLSTRING);
        }
        public static string objectToString(object val, string defaultValue)
        {
            if (val == null)
            {
                return defaultValue;
            }

            return val.ToString();
        }

        public static bool objectToBool(object val)
        {
            return objectToBool(val, ConstValue.NULLBOOL);
        }
        public static bool objectToBool(object val, bool defaultValue)
        {
            if (IsInTryCatch)
            {
                try
                {
                    return Convert.ToBoolean(val);
                }
                catch
                {
                    return defaultValue;
                }
            }

            return Convert.ToBoolean(val);
        }

        public static Int64 objectToInt64(object val)
        {
            return objectToInt64(val, ConstValue.NULLINT);
        }
        public static Int64 objectToInt64(object val, Int64 defaultValue)
        {
            if (IsInTryCatch)
            {
                try
                {
                    return Convert.ToInt64(val);
                }
                catch
                {
                    return defaultValue;
                }
            }
            return Convert.ToInt64(val);
        }

        #endregion

        public static bool isFloatSame(float val1, float val2)
        {
            return Math.Abs(val1 - val2) < ConstValue.FLOAT_DIFF;
        }
    }
}
