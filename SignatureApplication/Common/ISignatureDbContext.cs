using Microsoft.EntityFrameworkCore;
using SignatureDomain.Entities;
using File = SignatureDomain.Entities.File;

namespace SignatureApplication.Common
{
    public interface ISignatureDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<SignatureFilesToUsers> SignatureFilesToUsers { get; set; }
    }
}
