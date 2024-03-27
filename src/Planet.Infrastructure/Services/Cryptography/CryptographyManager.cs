using Planet.Application.Services.Cryptography;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Planet.Infrastructure.Services.Cryptography
{
    public class CryptographyManager : ICryptographyService
    {
        public (string, string) HashPassword(string password)
        {
            byte[] saltBytes = GenerateSalt();
            string salt = Convert.ToBase64String(saltBytes);
            string hashed = Hash(password, saltBytes);

            return (hashed, salt);
        }


        public bool VerifyPassword(string password, string salt, string hashedPassword)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            return hashedPassword == Hash(password, saltBytes);
        }

        private string Hash(string password, byte[] saltBytes)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password,
                            salt: saltBytes,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 10000,
                            numBytesRequested: 256 / 8));
        }

        private byte[] GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();

            byte[] bytes = new byte[16];
            rng.GetBytes(bytes);

            return bytes;
        }
    }
}
