using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;
using Planet.Domain.Cards;
using Planet.Domain.Users;

namespace Planet.Persistence.Configurations
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(c => c.Title, titleBuilder =>
            {
                titleBuilder.Property(t => t.Value)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();
            });
            builder.Navigation(c => c.Title).IsRequired();

            builder.OwnsOne(c => c.Description, titleBuilder =>
            {
                titleBuilder.Property(t => t.Value)
                    .HasColumnName("Description")
                    .HasMaxLength(200)
                    .IsRequired();
            });
            builder.Navigation(c => c.Description).IsRequired();

            builder.OwnsMany(builder => builder.Labels, labelBuilder =>
            {
                labelBuilder.HasKey(l => new { l.BoardLabelId, l.CardId });
            });

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.OwnerId)
                .IsRequired();

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(u => u.AssignedToId);

            builder.HasMany(c => c.CheckLists)
                .WithOne()
                .HasForeignKey(c => c.CardId)
                .IsRequired();

            builder.HasMany(c => c.Labels)
                .WithOne()
                .HasForeignKey(c => c.CardId)
                .IsRequired();

            builder.HasOne<BoardList>()
                .WithMany()
                .HasForeignKey(b => b.ListId)
                .IsRequired();
        }
    }
}
