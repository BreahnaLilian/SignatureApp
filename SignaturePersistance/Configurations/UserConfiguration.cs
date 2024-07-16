using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureDomain.Entities;
using static SignatureCommon.Enums;

namespace SignaturePersistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public delegate void ResultCallback(int response);
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Id)
                .IsUnique();
            
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.Property(x => x.FirstName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.PhoneNumber)
                .IsRequired(true)
                .HasMaxLength(8);

            builder.Property(x => x.IDNP)
                .IsRequired(true)
                .HasMaxLength(14);

            builder.Property(x => x.Password)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(x => x.Address)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.DateOfBirth)
                .IsRequired(true)
                .HasDefaultValue(new DateTime());

            builder.Property(x => x.Gender)
                .IsRequired();
            
            builder.Property(x => x.Status)
                .IsRequired()
                .HasDefaultValue(UserStatus.Active);

            builder.HasData(SeedConfiguration.User1,
                SeedConfiguration.User2,
                SeedConfiguration.User3);
        }
    }
}
