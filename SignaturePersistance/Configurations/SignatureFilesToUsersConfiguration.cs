using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureDomain.Entities;

namespace SignaturePersistance.Configurations
{
    public class SignatureFilesToUsersConfiguration : IEntityTypeConfiguration<SignatureFilesToUsers>
    {
        public void Configure(EntityTypeBuilder<SignatureFilesToUsers> builder)
        {
            builder.HasKey(x => new { x.UserId, x.FileId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.SignatureFilesToUsers)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.File)
                .WithMany(x => x.SignatureFilesToUsers)
                .HasForeignKey(x => x.FileId);

        }
    }
}
