using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planet.Domain.Boards;

namespace Planet.Persistence.Configurations.Boards
{
    internal class BoardMemberConfiguration : IEntityTypeConfiguration<BoardMember>
    {
        public void Configure(EntityTypeBuilder<BoardMember> builder)
        {
            builder.ToTable("BoardMembers");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.HasIndex(b => new { b.UserId, b.BoardId })
                .IsUnique();
        }
    }
}
