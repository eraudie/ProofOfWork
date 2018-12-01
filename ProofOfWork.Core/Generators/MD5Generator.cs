using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProofOfWork.Core.Generators
{
    public class Md5Generator
    {
        public static string GenerateMd5String(string inputString)
        {
            var md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = md5.ComputeHash(bytes);
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
