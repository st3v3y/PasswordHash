using System;
using System.Security.Cryptography;

namespace PasswordHash
{
    public class SaltGenerator
    {
        private const int MaxSaltLength = 32;

        //Generate a random password salt
        public static byte[] GenerateRandomSalt()
        {
            byte[] salt = new byte[MaxSaltLength];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetNonZeroBytes(salt);
            }

            return salt;
        }
    }
}
