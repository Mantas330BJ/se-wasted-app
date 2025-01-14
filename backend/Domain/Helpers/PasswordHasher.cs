﻿using System;
using System.Security.Cryptography;

namespace Domain.Helpers
{
    public static class PasswordHasher
    {

        private const int SALT_SIZE = 16;

        private const int HASH_SIZE = 20;

        private const int ITERATIONS = 10000;

        /// Creates a hash from a password.
        public static string Hash(string password)
        {
            // Create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SALT_SIZE]);

            // Create hash
            var hash = new Rfc2898DeriveBytes(password, salt, ITERATIONS).GetBytes(HASH_SIZE);

            // Combine salt and hash
            var hashBytes = new byte[SALT_SIZE + HASH_SIZE];
            Array.Copy(salt, 0, hashBytes, 0, SALT_SIZE);
            Array.Copy(hash, 0, hashBytes, SALT_SIZE, HASH_SIZE);

            // Convert to string
            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }

        // Verifies a password against a hash.
        public static bool Verify(string password, string hashedPassword)
        {

            // Get hash bytes
            var hashBytes = Convert.FromBase64String(hashedPassword);

            // Get salt
            var salt = new byte[SALT_SIZE];
            Array.Copy(hashBytes, 0, salt, 0, SALT_SIZE);

            // Create hash with given salt
            byte[] hash = new Rfc2898DeriveBytes(password, salt, ITERATIONS).GetBytes(HASH_SIZE);

            // Check if hashes match
            for (var i = 0; i < HASH_SIZE; i++)
            {
                if (hashBytes[i + SALT_SIZE] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
