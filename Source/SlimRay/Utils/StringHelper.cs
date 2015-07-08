using System;
using System.Text;

namespace SlimRay.Utils
{
    public static class StringHelper
    {
        /// <summary>
        /// 取str中，subStr之前的字符，没有subStr返回""。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="subStr"></param>
        /// <returns></returns>
        public static string Before(string str, string subStr)
        {
            int d = str.IndexOf(subStr);
            return d < 0 ? "" : str.Substring(0, d);
        }

        /// <summary>
        /// 取str中，subStr之后的字符，没有subStr返回""。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="subStr"></param>
        /// <returns></returns>
        public static string After(string str, string subStr)
        {
            int d = str.IndexOf(subStr);
            return d < 0 ? "" : str.Substring(d + subStr.Length);
        }

        /// <summary>
        /// 将pstr 中的第pos个str替换为newstr
        /// </summary>
        /// <param name="pstr">原始字符串</param>
        /// <param name="str">旧字符串</param>
        /// <param name="newstr">新字符串</param>
        /// <param name="pos">替换位置</param>
        /// <returns></returns>
        public static string Replace(string pstr, string str, string newstr, int pos)
        {
            int found = 0;

            string re = "";

            for (int i = 0; i < pstr.Length - str.Length; i++)
            {
                if (pstr.Substring(i, str.Length) != str)
                {
                    continue;
                }

                found++;

                if (found == pos)
                {
                    re = pstr.Substring(0, i) + newstr + pstr.Substring(i + 1 + str.Length, pstr.Length - i - 1 - str.Length);

                    return re;
                }
            }

            return pstr;
        }

        /// <summary>
        /// 获取字符串str中leftStr和rightStr号之内的内容。比如Between("1212123456","12","56")返回"34"。
        /// </summary>
        public static string Between(string data, string left, string right)
        {
            if (null == data || data.Length <= left.Length || data.Length <= right.Length) return "";

            if (data.IndexOf(right) < 0)
            {
                return "";
            }

            data = Before(data, right);

            int start = data.LastIndexOf(left);

            return start < 0 ? "" : data.Substring(start + left.Length);
        }

        /// <summary>
        /// 返回str的左边len个字符
        /// </summary>
        /// <returns></returns>
        public static string Left(string str, int len)
        {
            return str.Substring(0, len);
        }

        /// <summary>
        /// 返回str右边的len个字符。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string Right(string str, int len)
        {
            if (len >= str.Length) return str;

            return str.Substring(str.Length - len, len);
        }

        /// <summary>
        /// 检查：a的每一个字符都在b中
        /// </summary>
        /// <param name="a">待检测的字符串</param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsAllIn(string a, string b)
        {
            foreach (char i in a)
            {
                if (b.IndexOf(i) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 检查：a的某一个字符在b中
        /// </summary>
        /// <param name="a">待检测的字符串</param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool HasCharIn(string a, string b)
        {
            foreach (char i in a)
            {
                if (b.IndexOf(i) >= 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 只比较字符，忽略空格、大小写的比较。在这情况下：" a b cdef"=="abc de f"是成立的
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool CharCompare(string s1, string s2)
        {
            return
            (s1 != null && s2 != null)
            &&
            s1.Replace(" ", "").ToUpper() == s2.Replace(" ", "").ToUpper();
        }

        /// <summary>
        /// replace the first found part of data between left and right by new-data.
        /// original data will be returned as default.
        /// </summary>
        public static string ReplaceBetween(string data, string left, string right, string newData)
        {
            if (string.IsNullOrEmpty(data))
            {
                return data;
            }
            int lp = data.IndexOf(left);
            int rp = data.IndexOf(right);

            if (rp <= lp)
            {
                return data;
            }

            return data.Substring(0, lp) + newData + data.Substring(rp + right.Length);
        }

        public static string[] SplitToArray(string data)
        {
            return SplitToArray(data, ',');
        }

        public static string[] SplitToArray(string data, char spltor)
        {
            if (data == null || data == "")
            {
                return new string[] { };
            }

            return data.IndexOf(spltor) > 0 ? data.Split(spltor) : new string[] { data };
        }

        public static string ArrayToString(string[] data)
        {
            if (data == null)
            {
                return "";
            }

            string result = "";

            for (int i = 0; i < data.Length; i++)
            {
                if (i == 0)
                {
                    result += data[i];
                }
                else
                {
                    result += ("," + data[i]);
                }
            }

            return result;
        }

        public static string Left(string data, string splitor)
        {
            if (data == null)
            {
                return "";
            }

            int i = data.IndexOf(splitor);

            return i >= 0 ? data.Substring(0, i) : data;
        }

        public static string RemoveStart(string data, string start)
        {
            if (string.IsNullOrEmpty(start) || data == null || start.Length > data.Length)
            {
                return data;
            }

            return data.Substring(0, start.Length).ToUpper() == start.ToUpper() ? data.Substring(start.Length) : data;
        }

        public static string RemoveEnd(string data, string end)
        {
            if (string.IsNullOrEmpty(end) || data == null || end.Length > data.Length)
            {
                return data;
            }

            return data.Substring(data.Length - end.Length).ToUpper() == end.ToUpper() ? data.Substring(0, data.Length - end.Length) : data;
        }

        public static bool BoolFromYN(string data)
        {
            return data == "Y" || data == "y";
        }

    }
}
