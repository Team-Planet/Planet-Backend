using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;
using Planet.Domain.Shared;
using Planet.Domain.Users;

namespace Planet.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName(nameof(Email))
                .HasMaxLength(100)
                .HasConversion(
                    e => e.Value,
                    e => Email.Create(e));

            builder.Property(u => u.FirstName)
                .HasColumnName(nameof(FirstName))
                .HasMaxLength(50)
                .HasConversion(
                    n => n.Value,
                    n => FirstName.Create(n));

            builder.Property(u => u.LastName)
                .HasColumnName(nameof(LastName))
                .HasMaxLength(50)
                .HasConversion(
                    n => n.Value,
                    n => LastName.Create(n));

            builder.HasOne<BoardMember>()
                .WithOne()
                .HasForeignKey<BoardMember>(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
