using LinqToDB.Mapping;

namespace SignatureDomain.Common
{
    public class BaseEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }
    }
}
