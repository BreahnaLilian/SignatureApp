using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureDomain.Entities;

namespace SignaturePersistance.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public delegate void OrganizationChangedEventHandler(int response);
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasIndex(x => x.Id)
                .IsUnique();
            
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.Property(x => x.IDNO)
                .IsRequired(true)
                .HasMaxLength(13);

            builder.Property(x => x.CommercialName)
                .HasMaxLength(50);

            builder.Property(x => x.JuridicalName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.JuridicalAddress)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(8);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Organization)
                .HasForeignKey(x => x.OrganizationId);

            builder.HasData(SeedConfiguration.Organization1);
        }
    }
}
