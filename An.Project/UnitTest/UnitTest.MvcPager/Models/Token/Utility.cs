using System.Security.Cryptography;
using System.Text;

namespace UnitTest.MvcPager.Models.Token
{
    public class Utility
    {
        public static string Encrypt(string plaintext)
        {
            string cl1 = plaintext;
            string pwd = string.Empty;
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(cl1));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
    }
}