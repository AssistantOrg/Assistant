using System;
using System.Security.Cryptography;
using System.Text;

namespace Rovecode.Assistant.Application.Helpers
{
    public static class SecureHelper
    {
        public static string SHA512(string data)
        {
            var crypt = new SHA512Managed();
            string hash = String.Empty;

            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(data));

            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }

            return hash;
        }
    }
}
