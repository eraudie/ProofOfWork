using System;
using System.Security.Cryptography;
using System.Text;

namespace ProofOfWork.Core.Generators
{
    public class Sha256Generator
    {
        public static string GenerateSha256String(string inputString)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            //return GetStringFromHash(hash);
            return Convert.ToBase64String(hash);

        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            foreach (byte t in hash)
                result.Append(t.ToString("X2"));
            return result.ToString();
        }
    }
}
