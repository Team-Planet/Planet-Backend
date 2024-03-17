using Planet.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Domain.Cards
{
       public record CardTitle
        {
            public string Value { get; init; }

            private CardTitle() { }

            private CardTitle(string title)
            {
                Value = title;
            }

            public static CardTitle Create(string title)
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    throw new DomainException("BoardTitle.NullOrWhiteSpace", "Başlık boş olamaz!");
                }

                return new CardTitle(title);
            }
        }
}
