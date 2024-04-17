using Microsoft.EntityFrameworkCore;
using SignatureApplication.Common;
using SignatureDomain.Entities;
using SignaturePersistance.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignaturePersistance
{
    public class SignatureDbContext : DbContext, ISignatureDbContext
    {
        public SignatureDbContext(DbContextOptions<SignatureDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<SignatureDomain.Entities.File> Files { get; set; }
        public DbSet<SignatureFilesToUsers> SignatureFilesToUsers { get; set; }

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
