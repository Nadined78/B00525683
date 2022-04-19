using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

// https://www.devtrends.co.uk/blog/hashing-encryption-and-random-in-asp.net-core
// Simple class to generate and verify a Hash

namespace SMS.Data.Security
{
    static class Hasher
    {    
        // Generated Salt and Hash returned
        public static string CalculateHash(string input)
        {
            var salt = GenerateSalt(16);
            var bytes = KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);
            return $"{ Convert.ToBase64String(salt) }:{ Convert.ToBase64String(bytes) }";
        }

        private static byte[] GenerateSalt(int length)
        {
            var salt = new byte[length];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }
            return salt;
        }

        // Combined Salt and Hash string verified against the input string
        public static bool ValidateHash(string hash, string input)
        {
            try
            {
                var parts = hash.Split(':');
                var salt = Convert.FromBase64String(parts[0]);
                var bytes = KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);
                return parts[1].Equals(Convert.ToBase64String(bytes));
            } catch { return false; }            
        }
    }
}