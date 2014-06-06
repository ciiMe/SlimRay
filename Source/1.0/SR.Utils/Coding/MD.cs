using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SR.Utils.Coding
{
    class MD
    {
        public static string MD5(string str)
        {
            string re = "";

            using (MD5CryptoServiceProvider md5p = new MD5CryptoServiceProvider())
            {
                byte[] b = md5p.ComputeHash(Encoding.Default.GetBytes(str));

                foreach (byte i in b)
                {
                    re += i.ToString("x").PadLeft(2, '0').ToUpper();
                }
            }

            return re;
        }
    }
}
