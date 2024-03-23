using Planet.Domain.SharedKernel;
using System.Text.RegularExpressions;

namespace Planet.Domain.Users
{
    public record Email
    {
        public string Value { get; init; }

        private Email(string email)
        {
            Value = email;
        }

        private Email() { }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException("Email.NullOrWhiteSpace", "E-posta adresi boş olamaz!");
            }

            if (!IsValidEmail(email))
            {
                throw new DomainException("Email.NotValid", "E-posta adresi geçerli değil!");
            }

            if (!IsInRange(email))
            {
                throw new DomainException("Email.InvalidRange", "E-posta adresi 250 karakterden uzun olamaz!");
            }

            return new Email(email);
        }

        private static bool IsInRange(string email)
        {
            return email.Length <= 250;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

    }
}
