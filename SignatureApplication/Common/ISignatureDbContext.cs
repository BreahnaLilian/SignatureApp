using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SignatureDomain.Entities;
using File = SignatureDomain.Entities.File;

namespace SignatureApplication.Common
{
    public interface ISignatureDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<SignatureFilesToUsers> SignatureFilesToUsers { get; set; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
