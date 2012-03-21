/* 
 * 提供最底层的数据类型转换，
 * 
 */
using System;

namespace SR.Base.Types
{
    public static class ConvertibleObjectException
    {
        public static string _ERR_NULLVALUE = "null value in ConvertibleObject.";
    }

    /// <summary>
    /// 可进行数据转换的对象。其使用GaeaCoding.Base.Types.Converts进行拆箱操作。
    /// </summary>
    public class ConvertibleObject
    {
        private object _value;

        public object value
        {
            get { return _value; }
            set { _value = value; }
        }

        public ConvertibleObject(object val)
        {
            //if (null == val)
            //{
            //    GException.CreateException(ConvertibleObjectException._ERR_NULLVALUE);
            //}

            _value = val;
        }

        public bool ToBoolean()
        {
            return Converts.objectToBool(_value);
        }

        public DateTime ToDateTime()
        {
            return Converts.objectToDatetime(_value);
        }

        public double ToDouble()
        {
            return Converts.objectToDouble(_value);
        }

        public int ToInt()
        {
            return Converts.objectToInt(_value);
        }

        public override string ToString()
        {
            return Converts.objectToString(_value);
        }
    }

}