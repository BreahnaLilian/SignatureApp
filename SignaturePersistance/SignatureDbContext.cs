using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureDomain.Common;
using SignatureDomain.Entities;

namespace SignaturePersistance
{
    public class SignatureDbContext : DbContext, ISignatureDbContext
    {
        public SignatureDbContext(DbContextOptions<SignatureDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<SignatureDomain.Entities.File> Files { get; set; }
        public DbSet<SignatureFilesToUsers> SignatureFilesToUsers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.Entity is AuditableEntity auditable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditable.CreateDate = DateTime.Now;
                            break;

                        case EntityState.Modified:
                            auditable.LastModified = DateTime.Now;
                            break;
                    }
                }

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Id = Guid.NewGuid();
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SignatureDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}
