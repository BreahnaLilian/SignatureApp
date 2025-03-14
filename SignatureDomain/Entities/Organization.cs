using LinqToDB.Mapping;
using SignatureDomain.Common;
using static SignatureCommon.Enums;

namespace SignatureDomain.Entities
{
    [Table("Organizations")]
    public class Organization : AuditableEntity
    {
        [Column("IDNO")]
        public string IDNO { get; set; }
        [Column("CommercialName")]
        public string CommercialName { get; set; }
        [Column("JuridicalName")]
        public string JuridicalName { get; set; }
        [Column("JuridicalAddress")]
        public string JuridicalAddress { get; set; }
        [Column("Status")]
        public OrganizationStatus Status { get; set; }
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Column("ApiKey")]
        public string ApiKey { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
