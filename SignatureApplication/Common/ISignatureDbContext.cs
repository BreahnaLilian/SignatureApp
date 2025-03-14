using LinqToDB;
using SignatureDomain.Entities;
using File = SignatureDomain.Entities.File;

namespace SignatureApplication.Common
{
    public interface ISignatureDbContext
    {
        public ITable<User> Users { get; }
        public ITable<File> Files { get; }
        public ITable<Organization> Organizations { get; }
        public ITable<SignatureFilesToUsers> SignatureFilesToUsers { get; }
        
        Task<int> InsertAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
        Task<int> UpdateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    }
}
