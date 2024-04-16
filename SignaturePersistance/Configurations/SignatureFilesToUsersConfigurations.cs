using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SignatureDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignaturePersistance.Configurations
{
    public class SignatureFilesToUsersConfigurations : IEntityTypeConfiguration<SignatureFilesToUsers>
    {
        public void Configure(EntityTypeBuilder<SignatureFilesToUsers> builder)
        {
            builder.HasKey(x => new { x.UserId, x.FileId });

        }
    }
}
