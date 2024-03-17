using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
    public record CardDescription
    {
        public string value { get; init; }

        private CardDescription() { }
        private CardDescription(string description)
        {
            value = description;
        }
        public static CardDescription Create(string description)
        {
            if (description.Length > 200)
            {
                throw new DomainException("CardDescription.NotInRange", "Açıklama 200 karakterden uzun olamaz!");
            }
            return new CardDescription(description);
        }
    }
}
