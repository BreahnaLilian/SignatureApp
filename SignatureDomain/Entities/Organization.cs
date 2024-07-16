using SignatureDomain.Common;
using static SignatureCommon.Enums;

namespace SignatureDomain.Entities
{
    public class Organization : AuditableEntity
    {
        public string IDNO { get; set; }
        public string CommercialName { get; set; }
        public string JuridicalName { get; set; }
        public string JuridicalAddress { get; set; }
        public OrganizationStatus Status { get; set; }
        public string PhoneNumber { get; set; }
        public string ApiKey { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
