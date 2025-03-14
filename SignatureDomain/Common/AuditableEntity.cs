using LinqToDB.Mapping;

namespace SignatureDomain.Common
{
    public class AuditableEntity : BaseEntity
    {
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }
        [Column("LastModified")]
        public DateTime? LastModified { get; set; }
    }
}
