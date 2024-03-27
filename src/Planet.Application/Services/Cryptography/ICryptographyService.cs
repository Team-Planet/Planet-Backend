namespace Planet.Application.Services.Cryptography
{
    public interface ICryptographyService
    {
        (string, string) HashPassword(string password);
        bool VerifyPassword(string password, string salt, string hashedPassword);
    }
}
