using System.Text;
using System.Security.Cryptography;

namespace SlimRay.Utils.Coding
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
