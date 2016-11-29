using System;
using System.Diagnostics;

namespace PasswordHash
{
    class Program
    {
        private const string Password = "myPassword";

        static void Main(string[] args)
        {
            //one possible solution is the direct use of Rfc2898 which is just for generation
            GenerateRfc2898Hash();

            //an alternative is SHA256 where the hash can be validated
            GenerateSha256Hash();
        }

        private static void GenerateRfc2898Hash()
        {
            string hashedPassword = Rfc2898Hasher.HashPassword(Password);

            Debug.WriteLine("My Rfc2898 password hash is: " + hashedPassword);
        }

        private static void GenerateSha256Hash()
        {
            byte[] salt = SaltGenerator.GenerateRandomSalt();
            byte[] hashedPassword = Sha256Hasher.Hash(Password, salt);
            
            Debug.WriteLine("My Sha256 password hash is: " + Convert.ToBase64String(hashedPassword));
            
            var isValid = Sha256Hasher.ConfirmPassword(Password, hashedPassword, salt);

            Debug.WriteLine(isValid
                ? "My Sha256 password hash is valid!!"
                : "My Sha256 password hash is NOT valid!! :-(");
        }

    }
}
