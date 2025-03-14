using LinqToDB;
using LinqToDB.Data;
using SignatureApplication.Common;
using SignatureDomain.Common;
using SignatureDomain.Entities;
using File = SignatureDomain.Entities.File;

namespace SignaturePersistance
{
    public class SignatureDbContext(DataOptions<SignatureDbContext> options)
        : DataConnection(options.Options), ISignatureDbContext
    {
        public ITable<User> Users => this.GetTable<User>();
        public ITable<File> Files => this.GetTable<File>();
        public ITable<Organization> Organizations => this.GetTable<Organization>();
        public ITable<SignatureFilesToUsers> SignatureFilesToUsers => this.GetTable<SignatureFilesToUsers>();
        public async Task<int> InsertAsync<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            HandleAuditableEntity(entity, true, cancellationToken);
            return await this.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class
        {
            HandleAuditableEntity(entity, false, cancellationToken);
            return await this.UpdateAsync(entity);
        }
        
        private void HandleAuditableEntity<T>(T entity, bool isInsert, CancellationToken cancellationToken) where T : class
        {
            if (entity is AuditableEntity auditable)
            {
                if (isInsert)
                {
                    auditable.CreateDate = DateTime.UtcNow;
                    auditable.Id = Guid.NewGuid();
                }
                else
                {
                    auditable.LastModified = DateTime.UtcNow;
                }
            }
        }
    }
}
