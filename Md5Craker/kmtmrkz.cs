using System.Security.Cryptography;
using System.Text;

namespace Md5Craker
{
    public class kmtmrkz
    {
        public static string Sha256(string mesaj)
        {
            string returnstring = string.Empty;
            var MesajBytes = Encoding.ASCII.GetBytes(mesaj);
            var Sha = new SHA256Managed();
            var Has = Sha.ComputeHash(MesajBytes);
            foreach (byte b in Has)
            {
                returnstring += b.ToString("x2");
            }
            return returnstring;
        }
        public static string Sha1(string mesaj)
        {
            string returnstring = string.Empty;
            var MesajBytes = Encoding.ASCII.GetBytes(mesaj);
            var Sha1 = new SHA1Managed();
            var Has = Sha1.ComputeHash(MesajBytes);
            foreach (byte b in Has)
            {
                returnstring += b.ToString("x2");
            }
            return returnstring;
        }
        public static string MD5Sifrele(string sifrelenecekMetin)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
