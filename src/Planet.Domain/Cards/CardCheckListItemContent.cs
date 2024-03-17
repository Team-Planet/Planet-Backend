using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
    public record CardCheckListItemContent
    {
        public string value { get; init; }
        private CardCheckListItemContent() { }
        private CardCheckListItemContent(string content)
        {
            value = content;
        }
        public static CardCheckListItemContent Create (string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new DomainException("ItemContent.NullOrWhiteSpace", "Eklenecek olan öğe boş olamaz!");
            }
            if(content.Length > 200)
            {
                throw new DomainException("ItemContent.NotInRange", "Öğe 200 karakterden fazla olamaz!");
            }
            return new CardCheckListItemContent(content);
        }
    }
}
