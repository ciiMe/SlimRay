using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlimRay.Utils
{
    public class VersionHelper
    {
        public bool IsABigger(string a, string b, char split)
        {
            int[] va = ToInt(a.Split(split));
            int[] vb = ToInt(b.Split(split));

            if (vb.Length == 0 || va.Length == 0)
            {
                return true;
            }

            int len = va.Length > vb.Length ? va.Length : vb.Length;

            for (int i = 0; i < len; i++)
            {
                if (va[i] > vb[i])
                {
                    return true;
                }
                else if (va[i] < vb[i])
                {
                    return false;
                }
            }

            return va.Length > vb.Length;
        }

        public int[] ToInt(string[] data)
        {
            int[] result = new int[data.Length];

            int i = 0;
            foreach (string s in data)
            {
                result[i] = ToInt(s);
                i++;
            }

            return result;
        }

        public int ToInt(string data)
        {
            try
            {
                return Convert.ToInt32(data);
            }
            catch
            {
                return 0;
            }
        }
    }
}
