using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static SignatureCommon.Enums;

namespace SignaturePersistance.Configurations
{
    public class FileConfigurations : IEntityTypeConfiguration<SignatureDomain.Entities.File>
    {
        public void Configure(EntityTypeBuilder<SignatureDomain.Entities.File> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.Property(x => x.FileName)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Property(x => x.Path)
                .IsRequired(true)
                .HasMaxLength(1024);

            builder.Property(x => x.Type)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Size)
                .IsRequired(true)
                .HasMaxLength(1024);

            builder.Property(x => x.Commentary)
                .HasMaxLength(1024);

            builder.Property(x => x.Stauts)
                .IsRequired(true)
                .HasDefaultValue(FileStatus.New);

            //builder.HasData();
        }
    }
}
