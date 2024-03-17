using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
    public record CardCommentDescription
    {
        public string value { get; init; }

        private CardCommentDescription() { }
        private CardCommentDescription(string description)
        {
            value = description;
        }
        public static CardCommentDescription Create(string description)
        {
            if (description.Length > 200)
            {
                throw new DomainException("CardDescription.NotInRange", "Açıklama 200 karakterden uzun olamaz!");
            }
            return new CardCommentDescription(description);
        }
    }
}
