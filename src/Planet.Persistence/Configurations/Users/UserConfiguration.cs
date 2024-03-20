using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;
using Planet.Domain.Shared;
using Planet.Domain.Users;

namespace Planet.Persistence.Configurations.Users
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.OwnsOne(u => u.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Value)
                    .HasColumnName("Email")
                    .HasMaxLength(250)
                    .IsRequired();
            });
            builder.Navigation(u => u.Email).IsRequired();

            builder.OwnsOne(u => u.FirstName, firstNameBuilder =>
            {
                firstNameBuilder.Property(n => n.Value)
                    .HasColumnName("FirstName")
                    .HasMaxLength(50)
                    .IsRequired();
            });
            builder.Navigation(u => u.FirstName).IsRequired();

            builder.OwnsOne(u => u.LastName, lastNameBuilder =>
            {
                lastNameBuilder.Property(n => n.Value)
                    .HasColumnName("LastName")
                    .HasMaxLength(50)
                    .IsRequired();
            });
            builder.Navigation(u => u.LastName).IsRequired();

            builder.HasMany<BoardMember>()
                .WithOne()
                .HasForeignKey(m => m.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
