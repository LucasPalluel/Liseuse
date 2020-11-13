using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace PPE
{
    public class Hachage
    {
        public static string FileToHashMD5(string chemin_fichier)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(chemin_fichier))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static string StringToHashMD5(string str)
        {
            using(var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(System.Text.Encoding.ASCII.GetBytes(str));
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

    }
}
