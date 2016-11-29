using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHash
{
    class Sha256Hasher
    {
        public static byte[] Hash(string value, byte[] salt)
        {
            return Hash(Encoding.UTF8.GetBytes(value), salt);
        }

        public static byte[] Hash(byte[] value, byte[] salt)
        {
            byte[] saltedValue = value.Concat(salt).ToArray();

            return new SHA256Managed().ComputeHash(saltedValue);
        }

        public static bool ConfirmPassword(string password, byte[] hashedPassword, byte[] salt)
        {
            byte[] passwordHash = Hash(password, salt);

            return hashedPassword.SequenceEqual(passwordHash);
        }
    }
}
