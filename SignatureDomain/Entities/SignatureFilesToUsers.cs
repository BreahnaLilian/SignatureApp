using SignatureDomain.Common;

namespace SignatureDomain.Entities
{
    public class SignatureFilesToUsers : AuditableEntity
    {
        public Guid UserId { get; set; }
        public Guid FileId { get; set; }

        public User User { get; set; }
        public File File { get; set; }
    }
}
