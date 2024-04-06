using SignatureDomain.Common;
using static SignatureDomain.Common.Enums;

namespace SignatureDomain.Entities
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int IDNP { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public UserStatus Status { get; set; }

        public List<File> AssignetFiles { get; set; }
    }
}
