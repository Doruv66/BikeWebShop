using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL
{
    public static class HashHelper
    {
        public static byte[] HashPassword(string password, byte[] salt, int iterations)
        {
            try
            {
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))

                    return pbkdf2.GetBytes(20);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    

        public static bool CompareByteArrays(byte[] a, byte[] b)
        {

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        public static bool VerifyPassword(string password, byte[] salt, byte[] hashedPassword, int iterations)
        {
            byte[] passwordHash = HashPassword(password, salt, iterations);
            return CompareByteArrays(hashedPassword, passwordHash);
        }
    }
}
