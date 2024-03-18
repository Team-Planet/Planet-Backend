//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Planet.Domain.Cards;
//using Planet.Domain.Users;

//namespace Planet.Persistence.Configurations
//{
//    internal class CardConfiguration : IEntityTypeConfiguration<Card>
//    {
//        public void Configure(EntityTypeBuilder<Card> builder)
//        {
//            builder.HasKey(c => c.Id);

//            builder.Property(c => c.Id)
//                .ValueGeneratedNever()
//                .IsRequired();

//            builder.Property(c => c.Title)
//                .HasColumnName("Title")
//                .HasMaxLength(100)
//                .HasConversion(
//                    t => t.Value,
//                    t => CardTitle.Create(t)
//                )
//                .IsRequired();

//            builder.Property(c => c.Description)
//                .HasColumnName("Description")
//                .HasMaxLength(200)
//                .HasConversion(
//                    d => d.Value,
//                    d => CardDescription.Create(d)
//                );

//            builder.HasOne<User>()
//                .WithMany()
//                .HasForeignKey(u => u.OwnerId)
//                .IsRequired();

//            //builder.HasMany(c => c.Mem)
//            //    .WithOne()
//            //    .HasForeignKey(c => c.CardId);

//            //builder.HasMany(c => c.CheckLists)
//            //    .WithOne()
//            //    .HasForeignKey(c => c.CardId);
                
//        }
//    }
//}
