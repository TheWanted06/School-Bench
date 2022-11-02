using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace School_Bench.Classes
{
    public class Encrypt
    {
        public static string HashPassword(string password)
        {
            SHA256 Hash = SHA256.Create();
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashedPassword = Hash.ComputeHash(passwordBytes);
            return Convert.ToHexString(hashedPassword);
        }
    }
}
