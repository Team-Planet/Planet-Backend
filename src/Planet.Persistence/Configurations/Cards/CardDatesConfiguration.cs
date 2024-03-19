using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Cards;

namespace Planet.Persistence.Configurations.Cards
{
    internal class CardDatesConfiguration : IEntityTypeConfiguration<CardDates>
    {
        public void Configure(EntityTypeBuilder<CardDates> builder)
        {
            builder.ToTable("CardDates");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.HasOne(cd => cd.Card)
                .WithOne(c => c.Dates)
                .HasForeignKey<CardDates>(cd => cd.CardId)
                .IsRequired();
        }
    }
}