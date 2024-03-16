using Planet.Domain.SharedKernel;
using Planet.Domain.Users;
using System.Text.RegularExpressions;

namespace Planet.Domain.Shared
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

            if(IsInRange(email))
            {
                throw new DomainException("Email.InvalidRange", "E-posta adresi 100 karakterden uzun olamaz!");
            }

            return new Email(email);
        }

        private static bool IsInRange(string email)
        {
            return email.Length <= 100;
        }

        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

    }
}
