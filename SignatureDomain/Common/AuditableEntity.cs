namespace SignatureDomain.Common
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
