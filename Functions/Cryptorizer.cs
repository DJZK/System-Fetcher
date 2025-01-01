using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System_Fetcher.Functions
{
    internal class Cryptorizer
    {
        // Food because.. it will be digested
        public static string CalculateHash(string food)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(food));
                StringBuilder hashStringBuilder = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2")); // Convert each byte to hexadecimal
                }

                // Return the hashed unique ID as a string
                return hashStringBuilder.ToString();
            }
        }
    }
}
