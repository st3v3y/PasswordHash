﻿using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace PasswordHash
{
    public class Rfc2898Hasher
    {
        public static string HashPassword(string password)
        {
            Contract.Requires(password != null);

            byte[] salt;
            byte[] buffer2;

            using (var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }

            byte[] dst = new byte[0x31];

            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);

            return Convert.ToBase64String(dst);
        }
    }
}
