using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Planet.Persistence.Configurations.Cards
{
    internal class CardCheckListConfiguration : IEntityTypeConfiguration<CardCheckListConfiguration>
    {
        public void Configure(EntityTypeBuilder<CardCheckListConfiguration> builder)
        {
            builder.ToTable("CardCheckLists");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(c => c.CardTitle, titleBuilder =>
            {
                titleBuilder.Property(ct => ct.Value)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.Navigation(c => c.CardTitle).IsRequired();
        }
    }
}
