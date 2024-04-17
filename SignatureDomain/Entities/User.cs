using SignatureDomain.Common;
using static SignatureCommon.Enums;

namespace SignatureDomain.Entities
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IDNP { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public UserStatus Status { get; set; }

        public ICollection<SignatureFilesToUsers> SignatureFilesToUsers { get; set; } = new HashSet<SignatureFilesToUsers>();
    }
}
