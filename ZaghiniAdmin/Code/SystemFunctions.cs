using System;
using System.Security.Cryptography;
using System.Text;

namespace ZaghiniAdmin.Code
{
    public static class SystemFunctions
    {
        public static string Encrypt(this string data)
        {
            HashAlgorithm algorithm = new SHA1CryptoServiceProvider();

            var value = Encoding.UTF8.GetBytes(data);
            var encrypted = algorithm.ComputeHash(value);

            var sb = new StringBuilder();

            foreach (var c in encrypted)
            {
                sb.Append(c.ToString("X2"));
            }

            return sb.ToString();
        }

        public static bool VerifyHash(string typedPassword, string dataBasePassword)
        {
            HashAlgorithm algorithm = new SHA1CryptoServiceProvider();
            if (string.IsNullOrEmpty(typedPassword))
                throw new NullReferenceException(typedPassword);

            var encrypted = algorithm.ComputeHash(Encoding.UTF8.GetBytes(typedPassword));

            var sb = new StringBuilder();

            foreach (var c in encrypted)
            {
                sb.Append(c.ToString("X2"));
            }

            return sb.ToString() == dataBasePassword;
        }
    }
}