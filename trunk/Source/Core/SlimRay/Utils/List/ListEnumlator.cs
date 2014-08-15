using System;
using System.Collections.Generic;
using System.Text;

namespace SlimRay.Utils.List
{
    /// <summary>
    /// 循环检索List中的数据
    /// </summary>
    /// <typeparam name="T">List中保存的类型</typeparam>
    public class ListEnumlator<T> where T : class
    {
        private List<T> _List;
        private int _LastIndex;

        private object _CompareItemValue;

        public object CompareItemValue
        {
            get { return _CompareItemValue; }
            set
            {
                if (value is string)
                {
                    _CompareItemValue = value.ToString().Trim().ToUpper();
                }
                else
                {
                    _CompareItemValue = value;
                }
            }
        }

        public delegate bool ListEnumLatorCompareHandler(ListEnumlator<T> sender, T currentListItem);

        public event ListEnumLatorCompareHandler OnListEnumLatorCompare;

        public ListEnumlator(List<T> list)
        {
            if (null == list) return;

            _List = list;

            _LastIndex = -1;
        }

        public T Locate()
        {
            if (null == _List || null == OnListEnumLatorCompare) return null;

            for (int i = 0; i < _List.Count; i++)
            {
                if (i >= _LastIndex && OnListEnumLatorCompare(this, _List[i]))
                {
                    _LastIndex = i;
                    return _List[i];
                }
            }

            return null;
        }

        public bool Exists()
        {
            return null != First(false);
        }

        private T First(bool isResetLocateIndex)
        {
            if (isResetLocateIndex) _LastIndex = -1;
            return Locate();
        }

        public T First()
        {
            return First(true);
        }

        public T Next()
        {
            return Locate();
        }
    }
}
