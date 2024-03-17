using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;
using Planet.Domain.Users;

namespace Planet.Persistence.Configurations
{
    internal class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(b => b.Title)
                .HasColumnName("Title")
                .HasMaxLength(100)
                .HasConversion(
                    t => t.Value,
                    t => BoardTitle.Create(t)
                )
                .IsRequired();

            builder.Property(b => b.Modules)
                .HasColumnName("Modules")
                .HasConversion(
                    t => (byte)t,
                    t => (BoardModules)t
                )
                .IsRequired();

            builder.Property(b => b.Description)
                .HasColumnName("Description")
                .HasMaxLength(200)
                .HasConversion(
                    d => d.Value,
                    d => BoardDescription.Create(d)
                );

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(b => b.OwnerId)
                .IsRequired();

            builder.HasMany(b => b.Members)
                .WithOne()
                .HasForeignKey(b => b.BoardId);
        }
    }
}
