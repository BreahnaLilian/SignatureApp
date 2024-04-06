using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureDomain.Entities;

namespace SignaturePersistance.Configurations
{
    public class SignatureDBContext : DbContext, ISignatureDbContext
    {
        public SignatureDBContext(DbContextOptions<SignatureDBContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<SignatureDomain.Entities.File> Files { get; set; }
        public DbSet<SignatureFilesToUsers> SignatureFilesToUsers { get; set; }
    }
}
